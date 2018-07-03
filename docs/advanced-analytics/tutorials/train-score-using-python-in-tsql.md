---
title: Use Python model in SQL for training and scoring | Microsoft Docs
ms.prod: sql
ms.technology: machine-learning

ms.date: 04/15/2018  
ms.topic: tutorial
author: HeidiSteen
ms.author: heidist
manager: cgronlun
---
# Use Python model in SQL for training and scoring
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md-winonly](../../includes/appliesto-ss-xxxx-xxxx-xxx-md-winonly.md)]

In the [previous lesson](wrap-python-in-tsql-stored-procedure.md), you learned the common pattern for using Python together with SQL. You learned that your Python code should output one clearly defined data.frame, and can optionally output multiple scalar or binary variables. You've learned that the SQL stored procedure should be designed to pass the right type of data into Python, and handle the results.

In this section, you use this same pattern to train a model on the data you've added to SQL Server, and save the model to a SQL Server table:

+ You design a stored procedure that calls a Python machine learning function.
+ The stored procedure needs data from SQL Server to use in training the model.
+ The stored procedure outputs a trained model as a binary variable. 
+ You save the trained model by inserting the variable model into a table. 

## Create the stored procedure and train a Python model

1. Run the following code in SQL Server Management Studio to create the stored procedure that builds a model.

    ```sql
    CREATE PROCEDURE generate_iris_model (@trained_model varbinary(max) OUTPUT)
    AS
    BEGIN
    EXEC sp_execute_external_script @language = N'Python',
    @script = N'
    import pickle
    from sklearn.naive_bayes import GaussianNB
    GNB = GaussianNB()
    trained_model = pickle.dumps(GNB.fit(iris_data[[0,1,2,3]], iris_data[[4]]))
    '
    , @input_data_1 = N'select "Sepal.Length", "Sepal.Width", "Petal.Length", "Petal.Width", "SpeciesId" from iris_data'
    , @input_data_1_name = N'iris_data'
    , @params = N'@trained_model varbinary(max) OUTPUT'
    , @trained_model = @trained_model OUTPUT;
    END;
    GO
    ```

2. If this command runs without error, a new stored procedure is created and added to the database. You can find stored procedures in Management Studio's **Object Explorer**, under **Programmability**.

3. Now run the stored procedure.

    ```sql
    EXEC generate_iris_model
    ```

    You should get an error, because you haven't provided the input the stored procedure requires.

    "Procedure or function 'generate_iris_model' expects parameter '@trained_model', which was not supplied."

4. To generate the model with the required inputs and save it to a table requires some additional statements:

    ```sql
    DECLARE @model varbinary(max);
    EXEC generate_iris_model @model OUTPUT;
    INSERT INTO iris_models (model_name, model) values('Naive Bayes', @model);
    ```

5. Now, try running the model generation code once more. 

    You should get the error: "Violation of PRIMARY KEY constraint Cannot insert duplicate key in object 'dbo.iris_models'. The duplicate key value is (Naive Bayes)".

    That's because the model name was provided by manually typing in "Naive Bayes" as part of the INSERT statement. Assuming you plan to create lots of models, using different parameters or different algorithms on each run, you should consider setting up a metadata scheme so that you can automatically name models and more easily identify them.

6. To get around this error, you can make some minor modifications to the SQL wrapper. This example generates a unique model name by appending the current date and time:

    ```sql
    DECLARE @model varbinary(max);
    DECLARE @new_model_name varchar(50)
    SET @new_model_name = 'Naive Bayes ' + CAST(GETDATE()as varchar)
    SELECT @new_model_name 
    EXEC generate_iris_model @model OUTPUT;
    INSERT INTO iris_models (model_name, model) values(@new_model_name, @model);
    ```

7. To view the models, run a simple SELECT statement.

    ```sql
    SELECT * FROM iris_models;
    GO
    ```

    **Results**

    |model_name	| model |
    |------|------|
    | Naive Bayes | 0x800363736B6C656172... |
    | Naive Bayes Jan 01 2018  9:39AM | 0x800363736B6C656172... |
    | Naive Bayes Feb 01 2018  10:51AM | 0x800363736B6C656172... |

## Generate scores from the model

Finally, let's load this model from the table into a variable, and pass it back to Python to generate scores.

1. Run the following code to create the stored procedure that performs scoring. 

    ```sql
    CREATE PROCEDURE predict_species (@model varchar(100))
    AS
    BEGIN
    DECLARE @nb_model varbinary(max) = (SELECT model FROM iris_models WHERE model_name = @model);
    EXEC sp_execute_external_script @language = N'Python', 
    @script = N'
    import pickle
    irismodel = pickle.loads(nb_model)
    species_pred = irismodel.predict(iris_data[[1,2,3,4]])
    iris_data["PredictedSpecies"] = species_pred
    OutputDataSet = iris_data.query( ''PredictedSpecies != SpeciesId'' )[[0, 5, 6]]
    print(OutputDataSet)
    '
    , @input_data_1 = N'select id, "Sepal.Length", "Sepal.Width", "Petal.Length", "Petal.Width", "SpeciesId" from iris_data'
    , @input_data_1_name = N'iris_data'
    , @params = N'@nb_model varbinary(max)'
    , @nb_model = @nb_model
    WITH RESULT SETS ( ("id" int, "SpeciesId" int, "SpeciesId.Predicted" int));
    END;
    GO
    ```

    The stored procedure gets the Naïve Bayes model from the table and uses the functions associated with the model to generate scores. In this example, the stored procedure gets the model from the table using the model name. However, depending on what kind of metadata you are saving with the model, you could also get the most recent model, or the model with the highest accuracy.

2. Run the following lines to pass the model name "Naive Bayes" to the stored procedure that executes the scoring code. 

    ```sql
    EXEC predict_species 'Naive Bayes';
    GO
    ```

    When you run the stored procedure, it returns a Python data.frame. This line of T-SQL specifies the schema for the returned results: `WITH RESULT SETS ( ("id" int, "SpeciesId" int, "SpeciesId.Predicted" int));`

    You can insert the results into a new table, or return them to an application.

    This example has been made simple by using the data from the Python iris dataset for scoring. (See the line `iris_data[[1,2,3,4]])`.) However, more typically you would run a SQL query to get the new data, and pass that into Python as `InputDataSet`. 

### Remarks

If you are used to working in Python, you might be accustomed to loading data, creating some summaries and graphs, then training a model and generating some scores all in the same 250 lines of code.

However, if your goal is to operationalize the process (model creation, scoring, etc.) in SQL Server, it is important to consider ways that you can separate the process into repeatable steps that can be modified using parameters. As much as possible, you want the Python code that you run in a stored procedure to have clearly defined inputs and outputs that map to stored procedure inputs and outputs.

Moreover, you can generally improve performance by separating the data exploration process from the processes of training a model or generating scores. 

Scoring and training processes can often be optimized by leveraging features of SQL Server, such as parallel processing, or by using algorithms in [revoscalepy](../python/what-is-revoscalepy.md) or [MicrosoftML](https://docs.microsoft.com/machine-learning-server/python-reference/microsoftml/microsoftml-package) that support streaming and parallel execution, rather than using standard Python libraries. 

## Next lesson

In the final lesson, you run Python code from a remote client, using SQL Server as the compute context. This step is optional, if you don't have a Python client, or don't intend to run Python outside a stored procedure.

+ [Create a revoscalepy model from a Python client](use-python-revoscalepy-to-create-model.md)

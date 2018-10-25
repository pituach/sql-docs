---
title: Use Python with revoscalepy to create a model in SQL Server | Microsoft Docs
description: Write Python script using revoscalepy functions to create data science models in SQL Server.
ms.prod: sql
ms.technology: machine-learning

ms.date: 10/22/2018  
ms.topic: tutorial
author: HeidiSteen
ms.author: heidist
manager: cgronlun
---
# Use Python with revoscalepy to create a model
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md-winonly](../../includes/appliesto-ss-xxxx-xxxx-xxx-md-winonly.md)]

The [revoscalepy](https://docs.microsoft.com/machine-learning-server/python-reference/revoscalepy/revoscalepy-package) Python library from Microsoft provides data science algorithms for data exploration, visualization, transformations, and analysis. You can find this library in SQL Server with [machine learning services](../install/sql-machine-learning-services-windows-install.md), in the non-SQL standalone [Microsoft Machine Learning Server](https://docs.microsoft.com/machine-learning-server/index), and as a [client-side Python library](https://docs.microsoft.com/machine-learning-server/install/python-libraries-interpreter) used for development on a workstation. From a workstation, you can call revoscalepy functions that shift code execution from the local system to a remote SQL Server or Machine Learning Server.

This exercise demonstrates how to create a linear regression model. It also covers shifting code execution from a local to remote computing environment, enabled by revoscalepy functions that set a remote compute context.

By completing this tutorial, you will learn how to:

> [!div class="checklist"]
> * Use revoscalepy to create a linear model
> * Shift operations from local to remote compute context

## Prerequisites

Sample data used in this exercise is the [**flightdata**](demo-data-airlinedemo-in-sql.md) database.

You need an IDE to run the sample code in this article, and the IDE must be linked to the Python executable.

To practice a compute context shift, you need a [local workstation](../r/set-up-a-data-science-client.md) and a SQL Server database engine instance with [Machine Learning Services](../install/sql-machine-learning-services-windows-install.md)) and Python enabled. 

> [!Tip]
> If you don't have two computers, you can simulate a remote compute context on one physical computer by installing relevant applications. First, an installation of SQL Server Machine Learning Services operates as the "remote" instance. Second, an installation of the Python client libraries operates as the client. You will have two copies of the same Python distribution and Microsoft Python libraries on the same machine. You will have to keep track of file paths and which copy of the exe you are using to complete the exercise successfully.

## Remote compute contexts and revoscalepy

This sample demonstrates the process of creating a Python model in a remote compute context, which lets you work from a client, but choose a remote environment, such as SQL Server, Spark, or Machine Learning Server, where the operations are actually performed. Using compute contexts makes it easier to write code once and deploy it to any supported environment.

To execute Python code in SQL Server requires the **revoscalepy** package. This is a special Python package provided by Microsoft, similar to the **RevoScaleR** package for the R language. The **revoscalepy** package supports the creation of compute contexts, and provides the infrastructure for passing data and models between a local workstation and a remote server. The **revoscalepy** function that supports in-database code execution is [RxInSqlServer](https://docs.microsoft.com/machine-learning-server/python-reference/revoscalepy/rxinsqlserver).

In this lesson, you use data in SQL Server to train a linear model based on [rx_lin_mod](https://docs.microsoft.com/machine-learning-server/python-reference/revoscalepy/rx-lin-mod), a function in **revoscalepy** that supports regression over very large datasets. 

This lesson also demonstrates the basics of how to set up and then use a **SQL Server compute context** in Python. For a discussion of how compute contexts work with other platforms, and which compute contexts are supported, see [Compute context for script execution in Machine Learning Server](https://docs.microsoft.com/machine-learning-server/r/concept-what-is-compute-context).


## Run the sample code

After you have prepared the database and have the data for training stored in a table, open a Python development environment and run the code sample.

The code performs the following steps:

1. Imports the required libraries and functions.
2. Creates a connection to SQL Server. Creates **data source** objects for working with the data.
3. Modifies the data using **transformations** so that it can be used by the logistic regression algorithm.
4. Calls `rx_lin_mod` and defines the formula used to fit the model.
5. Generates a set of predictions based on the original data.
6. Creates a summary based on the predicted values.

All operations are performed using an instance of SQL Server as the compute context.

> [!NOTE]
> For a demonstration of this sample running from the command line, see this video: [SQL Server 2017 Advanced Analytics with Python](https://www.youtube.com/watch?v=FcoY795jTcc)

### Sample code

```python
from revoscalepy import RxComputeContext, RxInSqlServer, RxSqlServerData
from revoscalepy import rx_lin_mod, rx_predict, rx_summary
from revoscalepy import RxOptions, rx_import

import os

def test_linmod_sql():
    sql_server = os.getenv('PYTEST_SQL_SERVER', '.')
    
    sql_connection_string = 'Driver=SQL Server;Server=' + sqlServer + ';Database=sqlpy;Trusted_Connection=True;'
    print("connectionString={0!s}".format(sql_connection_string))

    data_source = RxSqlServerData(
        sql_query = "select top 10 * from airlinedemosmall",
        connection_string = sql_connection_string,

        column_info = {
            "ArrDelay" : { "type" : "integer" },
            "DayOfWeek" : {
                "type" : "factor",
                "levels" : [ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" ]
            }
        })

    sql_compute_context = RxInSqlServer(
        connection_string = sql_connection_string,
        num_tasks = 4,
        auto_cleanup = False
        )

    #
    # Run linmod locally
    #
    linmod_local = rx_lin_mod("ArrDelay ~ DayOfWeek", data = data_source)
    #
    # Run linmod remotely
    #
    linmod = rx_lin_mod("ArrDelay ~ DayOfWeek", data = data_source, compute_context = sql_compute_context)

    # Predict results
    # 
    predict = rx_predict(linmod, data = rx_import(input_data = data_source))
    summary = rx_summary("ArrDelay ~ DayOfWeek", data = data_source, compute_context = sql_compute_context)
```

### Defining a data source vs. defining a compute context

A data source is different from a compute context. The _data source_ defines the data used in your code. The compute context defines where the code will be executed. However, they use some of the same information:

+ Python variables, such as `sql_query` and `sql_connection_string`, define the source of the data. 

    Pass these variables to the [RxSqlServerData](https://docs.microsoft.com/r-server/python-reference/revoscalepy/rxsqlserverdata) constructor to implement the **data source object** named `data_source`.

+ You create a **compute context object** by using the [RxInSqlServer](https://docs.microsoft.com/r-server/python-reference/revoscalepy/rxinsqlserverdata) constructor. The resulting **compute context object** is named `sql_cc`.

    This example re-uses the same connection string that you used in the data source, on the assumption that the data is on the same SQL Server instance that you will be using as the compute context. 
    
    However, the data source and the compute context could be on different servers.
 
### Changing compute contexts

After you define a compute context, you must set the **active compute context**. 

By default, most operations are run locally, which means that if you don't specify a different compute context, the data will be fetched from the data source, and the code will run in your current Python environment.

There are two ways to set the active compute context:
+ As an argument of a method or function
+ By calling `rx_set_computecontext`

#### Set compute context as an argument of a method or function

In this example, you set the compute context by using an argument of the individual **rx** function.
    
`linmod = rx_lin_mod_ex("ArrDelay ~ DayOfWeek", data = data, compute_context = sql_compute_context)`

This compute context is reused in the call to [rxsummary](https://docs.microsoft.com/machine-learning-server/python-reference/revoscalepy/rx-summary):.

`summary = rx_summary("ArrDelay ~ DayOfWeek", data = data_source, compute_context = sql_compute_context)`

#### Set a compute context explicitly using rx_set_compute_context

The function [rx_set_compute_context](https://docs.microsoft.com/machine-learning-server/python-reference/revoscalepy/rx-set-compute-context) lets you toggle between compute contexts that have already been defined.

After you have set the active compute context, it remains active until you change it.

### Using parallel processing and streaming

When you define the compute context, you can also set parameters that control how the data is handled by the compute context. These parameters differ depending on the data source type.

For SQL Server compute contexts, you can set the batch size, or provide hints about the degree of parallelism to use in running tasks.

+ The sample was run on a computer with four processors, so the `num_tasks` parameter is set to 4 to allow maximum use of resources. 
+ If you set this value to 0, SQL Server uses the default, which is to run as many tasks in parallel as possible, under the current MAXDOP settings for the server. However, the exact number of tasks that might be allocated depends on many other factors, such as server settings, and other jobs that are running.

## Next steps

These additional Python samples and tutorials demonstrate end-to-end scenarios using more complex data sources, as well as the use of remote compute contexts.

+ [In-Database Python for SQL developers](sqldev-in-database-python-for-sql-developers.md)
+ [Build a predictive model using Python and SQL Server](https://microsoft.github.io/sql-ml-tutorials/python/rentalprediction/)
+ [Build a predictive model using Python and SQL Server](https://microsoft.github.io/sql-ml-tutorials/python/rentalprediction/)

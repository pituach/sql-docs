---
title: "sp_execute_external_script (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "01/22/2018"
ms.prod: sql
ms.prod_service: "database-engine"
ms.component: "system-stored-procedures"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: system-objects
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords: 
  - "sp_execute_external_script_TSQL"
  - "sys.sp_execute_external_script"
  - "sys.sp_execute_external_script_TSQL"
  - "sp_execute_external_script"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "sp_execute_external_script"
ms.assetid: de4e1fcd-0e1a-4af3-97ee-d1becc7f04df
caps.latest.revision: 34
author: edmacauley
ms.author: edmaca
manager: craigg
---
# sp_execute_external_script (Transact-SQL)
[!INCLUDE[tsql-appliesto-ss2016-xxxx-xxxx-xxx-md](../../includes/tsql-appliesto-ss2016-xxxx-xxxx-xxx-md.md)]

  Executes the script provided as argument at an external location. The script must be written in a supported and registered language. To execute **sp_execute_external_script**, you must first enable external scripts by using the statement, `sp_configure 'external scripts enabled', 1;`.  
  
 ![Topic link icon](../../database-engine/configure-windows/media/topic-link.gif "Topic link icon") [Transact-SQL Syntax Conventions](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md)  
  
## Syntax

```
sp_execute_external_script   
    @language = N'language',   
    @script = N'script'  
    [ , @input_data_1 = N'input_data_1' ]   
    [ , @input_data_1_name = N'input_data_1_name' ]   
    [ , @output_data_1_name = N'output_data_1_name' ]  
    [ , @parallel = 0 | 1 ]  
    [ , @params = N'@parameter_name data_type [ OUT | OUTPUT ] [ ,...n ]' ] 
    [ , @parameter1 = 'value1' [ OUT | OUTPUT ] [ ,...n ] ]
```

## Arguments
 @language = N'*language*'  
 Indicates the script language. *language* is **sysname**.  

 Valid values are `Python` or `R`. 
  
 @script = N'*script*'  
 External language  script specified as a literal or variable input. *script* is **nvarchar(max)**.  
  
 [ @input_data_1_name = N'*input_data_1_name*' ]  
 Specifies the name of the variable used to represent the query defined by @input_data_1. The data type of the variable in the external script depends on the language. In case of R, the input variable is a data frame. In the case of Python, input must be tabular. *input_data_1_name* is **sysname**.  
  
 Default value is `InputDataSet`.  
  
 [ @input_data_1 =  N'*input_data_1*' ]  
 Specifies the input data used by the external script in the form of a [!INCLUDE[tsql](../../includes/tsql-md.md)] query. The data type of *input_data_1* is **nvarchar(max)**.
  
 [ @output_data_1_name =  N'*output_data_1_name*' ]  
 Specifies the name of the variable in the external script that contains the data to be returned to [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] upon completion of the stored procedure call. The data type of the variable in the external script depends on the language. For R, the output must be a data frame. For Python, the output must be a pandas data frame. *output_data_1_name* is **sysname**.  
  
 Default value is "OutputDataSet".  
  
 [ @parallel = 0 | 1 ]
 Enable parallel execution of R scripts by setting the `@parallel` parameter to 1. The default for this parameter is 0 (no parallelism).  
  
 For R scripts that do not use RevoScaleR functions, using the  `@parallel` parameter can be beneficial for processing large datasets, assuming the script can be trivially parallelized. For example, when using the R `predict` function with a model to generate new predictions, set `@parallel = 1` as a hint to the query engine. If the query can be parallelized, rows are distributed according to the **MAXDOP** setting.  
  
 If `@parallel = 1` and the output is being streamed directly to the client machine, then the `WITH RESULTS SETS` clause is required and an output schema must be specified.  
  
 For R scripts that use RevoScaleR functions, parallel processing is handled automatically and you should not specify `@parallel = 1` to the **sp_execute_external_script** call.  
  
 [ @params = N'*@parameter_name data_type* [ OUT | OUTPUT ] [ ,...n ]' ]  
 A list of input parameter declarations that are used in the external script.  
  
 [ @parameter1 = '*value1*'  [ OUT | OUTPUT ] [ ,...n ] ]  
 A list of values for the input parameters used by the external script.  

## Remarks

Use **sp_execute_external_script** to execute scripts written in a supported language. Currently, supported languages are R for SQL Server 2016, and Python and R for SQL Server 2017. 

> [!IMPORTANT]
> The query tree is controlled by [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] and users cannot perform arbitrary operations on the query. 

By default, result sets returned by this stored procedure are output with unnamed columns. Column names used within a script are local to the scripting environment and are not reflected in the outputted result set. To name result set columns, use the `WITH RESULTS SET` clause of [`EXECUTE`](../../t-sql/language-elements/execute-transact-sql.md).
  
 In addition to returning a result set, you can return scalar values to [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] by using OUTPUT parameters. The following example shows the use of the OUTPUT parameter to return the serialized R model that was used as input to the script:  

In [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)], [!INCLUDE[rsql_productname](../../includes/rsql-productname-md.md)] is comprised of a server component installed with [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)], and a set of workstation tools and connectivity libraries that connect the data scientist to the high-performance environment of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)]. You must install the machine learning components during [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] setup to enable the execution of external scripts. For more information, see [Set up SQL Server Machine Learning Services](../../advanced-analytics/r/set-up-sql-server-r-services-in-database.md).  
  
You can control the resources used by external scripts by configuring an external resource pool. For more information, see [CREATE EXTERNAL RESOURCE POOL &#40;Transact-SQL&#41;](../../t-sql/statements/create-external-resource-pool-transact-sql.md). Information about the workload can be obtained from the resource governor catalog views, DMV's, and counters. For more information, see [Resource Governor Catalog Views &#40;Transact-SQL&#41;](../../relational-databases/system-catalog-views/resource-governor-catalog-views-transact-sql.md), [Resource Governor Related Dynamic Management Views &#40;Transact-SQL&#41;](../../relational-databases/system-dynamic-management-views/resource-governor-related-dynamic-management-views-transact-sql.md), and [SQL Server, External Scripts Object](../../relational-databases/performance-monitor/sql-server-external-scripts-object.md).  

Monitor script execution using [sys.dm_external_script_requests](../../relational-databases/system-dynamic-management-views/sys-dm-external-script-requests.md) and [sys.dm_external_script_execution_stats](../../relational-databases/system-dynamic-management-views/sys-dm-external-script-execution-stats.md). 

## Streaming execution for R and Python scripts  

Streaming allows the R or Python script to work with more data than can fit in memory. To control the number of rows passed during streaming, specify an integer value for the parameter, `@r_rowsPerRead` in the `@params` collection.  For example, if you are training a model that uses very wide data, you could adjust the value to read fewer rows, to ensure that all rows can be sent in one chunk of data. You might also use this parameter to manage the number of rows being read and processed at one time, to mitigate server performance issues. 
  
Both the `@r_rowsPerRead` parameter for streaming and the `@parallel` argument should be considered hints. For the hint to be applied, it must be possible to generate a SQL query plan that includes parallel processing. If this is not possible, parallel processing cannot be enabled.  
  
> [!NOTE]  
>  Streaming and parallel processing are supported only in Enterprise Edition. You can include the parameters in your queries in Standard Edition without raising an error, but the parameters have no effect and R scripts run in a single process.  
  
## Restrictions  


### Data types

The following data types are not supported when used in the input query or parameters of `sp_execute_external_script` procedure, and return an unsupported type error.  

As a workaround, **CAST** the column or value to a supported type in [!INCLUDE[tsql](../../includes/tsql-md.md)] before sending it to the external script.  
  
-   **cursor**  
  
-   **timestamp**  
  
-   **datetime2**, **datetimeoffset**, **time**  
  
-   **sql_variant**  
  
-   **text**, **image**  
  
-   **xml**  
  
-   **hierarchyid**, **geometry**, **geography**  
  
-   CLR user-defined types

In general, any result set that cannot be mapped to a [!INCLUDE[tsql](../../includes/tsql-md.md)] data type, is output as NULL.  

### Restrictions specific to R

If the input includes **datetime** values that do not fit the permissible range of values in R, values are converted to **NA**. This is required because [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] permits a larger range of values than is supported in the R language.

Float values (for example, `+Inf`, `-Inf`, `NaN`) are not supported in [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] even though both languages use IEEE 754. Current behavior just sends the values to [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] directly; as a result, the SQL client in [!INCLUDE[ssManStudio](../../includes/ssmanstudio-md.md)] throws an error. Therefore, these values are converted to **NULL**.

## Permissions

Requires **EXECUTE ANY EXTERNAL SCRIPT** database permission.  

## Examples

This section contains examples of how this stored procedure can be used to execute R or Python scripts using [!INCLUDE[tsql](../../includes/tsql-md.md)].

### A. Return an R data set to SQL Server  

The following example creates a stored procedure that uses **sp_execute_external_script** to return the Iris dataset included with R to [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)].  

```sql
DROP PROC IF EXISTS get_iris_dataset;  
go  
CREATE PROC get_iris_dataset
AS  
BEGIN  
 EXEC   sp_execute_external_script  
       @language = N'R'  
     , @script = N'iris_data <- iris;'
     , @input_data_1 = N''  
     , @output_data_1_name = N'iris_data'
     WITH RESULT SETS (("Sepal.Length" float not null,   
           "Sepal.Width" float not null,  
        "Petal.Length" float not null,   
        "Petal.Width" float not null, "Species" varchar(100)));  
END;
GO
```

### B. Generate an R model based on data from SQL Server  

The following example creates a stored procedure that uses **sp_execute_external_script** to generate an iris model and return the model to [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)].  

> [!NOTE]
>  This example requires advance installation of the e1071 package. For more information, see [Install additional R packages on SQL Server](../../advanced-analytics/r/install-additional-r-packages-on-sql-server.md).

```sql
DROP PROC IF EXISTS generate_iris_model;
GO
CREATE PROC generate_iris_model
AS
BEGIN
 EXEC sp_execute_external_script  
      @language = N'R'  
     , @script = N'  
          library(e1071);  
          irismodel <-naiveBayes(iris_data[,1:4], iris_data[,5]);  
          trained_model <- data.frame(payload = as.raw(serialize(irismodel, connection=NULL)));  
'  
     , @input_data_1 = N'select "Sepal.Length", "Sepal.Width", "Petal.Length", "Petal.Width", "Species" from iris_data'  
     , @input_data_1_name = N'iris_data'  
     , @output_data_1_name = N'trained_model'  
    WITH RESULT SETS ((model varbinary(max)));  
END;
GO
```

To generate a similar model using Python, you would change the language identifier from `@language=N'R'` to `@language = N'Python'`, and make necessary modifications to the `@script` argument. Otherwise, all parameters function the same way as for R.

### C. Create a Python model and generate scores from it

This example illustrates how to use sp\_execute\_external\_script to generate scores on a simple Python model. 

```sql
CREATE PROCEDURE [dbo].[py_generate_customer_scores]
AS
BEGIN

-- Input query to generate the customer data
DECLARE @input_query NVARCHAR(MAX) = N'SELECT customer, orders, items, cost FROM dbo.Sales.Orders'

EXEC sp_execute_external_script @language = N'Python', @script = N'
import pandas as pd
from sklearn.cluster import KMeans

# Get data from input query
customer_data = my_input_data

# Define the model
n_clusters = 4
est = KMeans(n_clusters=n_clusters, random_state=111).fit(customer_data[["orders","items","cost"]])
clusters = est.labels_
customer_data["cluster"] = clusters

OutputDataSet = customer_data
'
, @input_data_1 = @input_query
, @input_data_1_name = N'my_input_data'
WITH RESULT SETS (("CustomerID" int, "Orders" float,"Items" float,"Cost" float,"ClusterResult" float));
END;
GO
```

Column headings used in Python code are not output to SQL Server; therefore, use the WITH RESULTS statement to specify the column names and data types for SQL to use.

For scoring, you can also use the native [PREDICT](../../t-sql/queries/predict-transact-sql.md) function, which is typically faster because it avoids calling the Python or R runtime.

## See also

 [System Stored Procedures &#40;Transact-SQL&#41;](../../relational-databases/system-stored-procedures/system-stored-procedures-transact-sql.md)   
 [Python Libraries and Data Types](../../advanced-analytics/python/python-libraries-and-data-types.md)  
 [R Libraries and R Data Types](../../advanced-analytics/r/r-libraries-and-data-types.md)  
 [SQL Server R Services](../../advanced-analytics/r/sql-server-r-services.md)   
 [Known Issues for SQL Server Machine Learning Services](../../advanced-analytics/known-issues-for-sql-server-machine-learning-services.md)   
 [CREATE EXTERNAL LIBRARY &#40;Transact-SQL&#41;](../../t-sql/statements/create-external-library-transact-sql.md)  
 [sp_prepare &#40;Transact SQL&#41;](../../relational-databases/system-stored-procedures/sp-prepare-transact-sql.md)   
 [sp_configure &#40;Transact-SQL&#41;](../../relational-databases/system-stored-procedures/sp-configure-transact-sql.md)   
 [external scripts enabled Server Configuration Option](../../database-engine/configure-windows/external-scripts-enabled-server-configuration-option.md)   
 [SERVERPROPERTY &#40;Transact-SQL&#41;](../../t-sql/functions/serverproperty-transact-sql.md)   
 [SQL Server, External Scripts Object](../../relational-databases/performance-monitor/sql-server-external-scripts-object.md)  
[sys.dm_external_script_requests](../../relational-databases/system-dynamic-management-views/sys-dm-external-script-requests.md)  
[sys.dm_external_script_execution_stats](../../relational-databases/system-dynamic-management-views/sys-dm-external-script-execution-stats.md) 

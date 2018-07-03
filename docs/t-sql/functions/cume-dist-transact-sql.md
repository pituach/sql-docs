---
title: "CUME_DIST (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "07/24/2017"
ms.prod: sql
ms.prod_service: "sql-data-warehouse, database-engine, sql-database"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: t-sql
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords: 
  - "CUME_DIST"
  - "CUME_DIST_TSQL"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "CUME_DIST function"
  - "analytic functions, CUME_DIST"
ms.assetid: 491b07f3-9ffd-4cdd-93e5-5abb636fc5ef
caps.latest.revision: 19
author: edmacauley
ms.author: edmaca
manager: craigg
monikerRange: "= azuresqldb-current || = azure-sqldw-latest || >= sql-server-2016 || = sqlallproducts-allversions"
---
# CUME_DIST (Transact-SQL)
[!INCLUDE[tsql-appliesto-ss2012-asdb-asdw-xxx-md](../../includes/tsql-appliesto-ss2012-asdb-asdw-xxx-md.md)]

For [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)], this function calculates the cumulative distribution of a value within a group of values. In other words, `CUME_DIST` calculates the relative position of a specified value in a group of values. Assuming ascending ordering, the `CUME_DIST` of a value in row *r* is defined as the number of rows with values less than or equal to that value in row *r*, divided by the number of rows evaluated in the partition or query result set. `CUME_DIST` is similar to the `PERCENT_RANK` function.
  
![Topic link icon](../../database-engine/configure-windows/media/topic-link.gif "Topic link icon") [Transact-SQL Syntax Conventions](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md)
  
## Syntax  
  
```sql
CUME_DIST( )  
    OVER ( [ partition_by_clause ] order_by_clause )  
  
```  
  
## Arguments  
OVER **(** [ *partition_by_clause* ] *order_by_clause*)  

The *partition_by_clause* divides the FROM clause result set into partitions, to which the function is applied. If the *partition_by_clause* argument is not specified, `CUME_DIST` treats all query result set rows as a single group. The *order_by_clause* determines the logical order in which the operation occurs. `CUME_DIST` requires the *order_by_clause*. `CUME_DIST` will not accept the \<rows or range clause> of the OVER syntax. See [OVER Clause &#40;Transact-SQL&#41;](../../t-sql/queries/select-over-clause-transact-sql.md) for more information.
  
## Return types
**float(53)**
  
## Remarks  
`CUME_DIST` returns a range of values greater tnan 0 and less than or equal to 1. Tie values always evaluate to the same cumulative distribution value. `CUME_DIST` includes NULL values by default and treats these values as the lowest possible values.
  
`CUME_DIST` is nondeterministic. See [Deterministic and Nondeterministic Functions](../../relational-databases/user-defined-functions/deterministic-and-nondeterministic-functions.md) for more information.
  
## Examples  
This example uses the `CUME_DIST` function to calculate the salary percentile for each employee within a given department. `CUME_DIST` returns a value that represents the percent of employees with a salary less than or equal to the current employee in the same department. The `PERCENT_RANK` function calculates the percent rank of the employee's salary within a department. To partition the result set rows by department, the example specifies the *partition_by_clause* value. The ORDER BY clause of the OVER clause logically orders the rows in each partition. The ORDER BY clause of the SELECT statement determines the display order of the result set.
  
```sql
USE AdventureWorks2012;  
GO  
SELECT Department, LastName, Rate,   
       CUME_DIST () OVER (PARTITION BY Department ORDER BY Rate) AS CumeDist,   
       PERCENT_RANK() OVER (PARTITION BY Department ORDER BY Rate ) AS PctRank  
FROM HumanResources.vEmployeeDepartmentHistory AS edh  
    INNER JOIN HumanResources.EmployeePayHistory AS e    
    ON e.BusinessEntityID = edh.BusinessEntityID  
WHERE Department IN (N'Information Services',N'Document Control')   
ORDER BY Department, Rate DESC;  
```  
  
[!INCLUDE[ssResult](../../includes/ssresult-md.md)]
  
```sql
  
Department             LastName               Rate                  CumeDist               PctRank  
---------------------- ---------------------- --------------------- ---------------------- ----------------------  
Document Control       Arifin                 17.7885               1                      1  
Document Control       Norred                 16.8269               0.8                    0.5  
Document Control       Kharatishvili          16.8269               0.8                    0.5  
Document Control       Chai                   10.25                 0.4                    0  
Document Control       Berge                  10.25                 0.4                    0  
Information Services   Trenary                50.4808               1                      1  
Information Services   Conroy                 39.6635               0.9                    0.888888888888889  
Information Services   Ajenstat               38.4615               0.8                    0.666666666666667  
Information Services   Wilson                 38.4615               0.8                    0.666666666666667  
Information Services   Sharma                 32.4519               0.6                    0.444444444444444  
Information Services   Connelly               32.4519               0.6                    0.444444444444444  
Information Services   Berg                   27.4038               0.4                    0  
Information Services   Meyyappan              27.4038               0.4                    0  
Information Services   Bacon                  27.4038               0.4                    0  
Information Services   Bueno                  27.4038               0.4                    0  
(15 row(s) affected)  
```  
  
## See also
[PERCENT_RANK &#40;Transact-SQL&#41;](../../t-sql/functions/percent-rank-transact-sql.md)
  
  

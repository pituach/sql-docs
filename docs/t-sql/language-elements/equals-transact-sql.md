---
title: "= (Equals) (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "12/06/2016"
ms.prod: sql
ms.prod_service: "database-engine, sql-database, sql-data-warehouse, pdw"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: t-sql
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords: 
  - "="
  - "= (Equals)"
  - "Equals"
  - "=_TSQL"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "equals operator (=)"
  - "= (equals operator)"
ms.assetid: 18885245-5f55-4831-8f0b-7f2a3e82e246
caps.latest.revision: 40
author: "douglaslMS"
ms.author: "douglasl"
manager: craigg
monikerRange: ">= aps-pdw-2016 || = azuresqldb-current || = azure-sqldw-latest || >= sql-server-2016 || = sqlallproducts-allversions"
---
# = (Equals) (Transact-SQL)
[!INCLUDE[tsql-appliesto-ss2008-all-md](../../includes/tsql-appliesto-ss2008-all-md.md)]

  Compares the equality of two expressions (a comparison operator) in [!INCLUDE[ssNoVersion_md](../../includes/ssnoversion-md.md)].  
  
 ![Topic link icon](../../database-engine/configure-windows/media/topic-link.gif "Topic link icon") [Transact-SQL Syntax Conventions](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md)  
  
## Syntax  
  
```  
expression = expression  
```  
  
## Arguments  
 *expression*  
 Is any valid [expression](../../t-sql/language-elements/expressions-transact-sql.md). If the expressions are not of the same data type, the data type for one expression must be implicitly convertible to the data type of the other. The conversion is based on the rules of [data type precedence](../../t-sql/data-types/data-type-precedence-transact-sql.md).  
  
## Result Types  
 Boolean  
  
## Remarks  
 When you compare using a NULL expression, the result depends on the `ANSI_NULLS` setting:  
  
-   If `ANSI_NULLS` is set to ON, the result of any comparison with NULL is UNKNOWN, following the ANSI convention that NULL is an unknown value and cannot be compared with any other value, including other NULLs.  
  
-   If `ANSI_NULLS` is set to OFF, the result of comparing NULL to NULL is TRUE, and the result of comparing NULL to any other value is FALSE.  

For more information, see [SET ANSI_NULLS &#40;Transact-SQL&#41;](../../t-sql/statements/set-ansi-nulls-transact-sql.md).
  
 A boolean expression resulting in UNKNOWN behaves similarly to FALSE in most, but not all cases. See [NULL and UNKNOWN &#40;Transact-SQL&#41;](../../t-sql/language-elements/null-and-unknown-transact-sql.md) and [NOT &#40;Transact-SQL&#41;](../../t-sql/language-elements/not-transact-sql.md) for more information.  
  
  
## Examples  
  
### A. Using = in a simple query  
 The following example uses the Equals operator to return all rows in the `HumanResources.Department` table in which the value in the `GroupName` column is equal to the word 'Manufacturing'.  
  
```  
-- Uses AdventureWorks  
  
SELECT DepartmentID, Name  
FROM HumanResources.Department  
WHERE GroupName = 'Manufacturing';  
  
```  
  
 [!INCLUDE[ssResult](../../includes/ssresult-md.md)]  
  
```  
  
DepartmentID Name  
------------ --------------------------------------------------  
7            Production  
8            Production Control  
  
(2 row(s) affected)  
  
```  
  
### B. Comparing NULL and non-NULL values  
 The following example uses the Equals (`=`) and Not Equal To (`<>`) comparison operators to make comparisons with `NULL` and nonnull values in a table. The example also shows that `IS NULL` is not affected by the `SET ANSI_NULLS` setting.  
  
```  
-- Create table t1 and insert 3 rows.  
CREATE TABLE dbo.t1 (a INT NULL);  
INSERT INTO dbo.t1 VALUES (NULL),(0),(1);  
GO  
  
-- Print message and perform SELECT statements.  
PRINT 'Testing default setting';  
DECLARE @varname int;   
SET @varname = NULL;  
  
SELECT a  
FROM t1   
WHERE a = @varname;  
  
SELECT a   
FROM t1   
WHERE a <> @varname;  
  
SELECT a   
FROM t1   
WHERE a IS NULL;  
GO  
  
-- SET ANSI_NULLS to ON and test.  
PRINT 'Testing ANSI_NULLS ON';  
SET ANSI_NULLS ON;  
GO  
DECLARE @varname int;  
SET @varname = NULL  
  
SELECT a   
FROM t1   
WHERE a = @varname;  
  
SELECT a   
FROM t1   
WHERE a <> @varname;  
  
SELECT a   
FROM t1   
WHERE a IS NULL;  
GO  
  
-- SET ANSI_NULLS to OFF and test.  
PRINT 'Testing SET ANSI_NULLS OFF';  
SET ANSI_NULLS OFF;  
GO  
DECLARE @varname int;  
SET @varname = NULL;  
SELECT a   
FROM t1   
WHERE a = @varname;  
  
SELECT a   
FROM t1   
WHERE a <> @varname;  
  
SELECT a   
FROM t1   
WHERE a IS NULL;  
GO  
  
-- Drop table t1.  
DROP TABLE dbo.t1;  
  
```  
  
 [!INCLUDE[ssResult](../../includes/ssresult-md.md)]  
  
```  
Testing default setting  
a  
-----------  
NULL  
  
(1 row(s) affected)  
  
a  
-----------  
0  
1  
  
(2 row(s) affected)  
  
a  
-----------  
NULL  
  
(1 row(s) affected)  
  
Testing ANSI_NULLS ON  
a  
-----------  
  
(0 row(s) affected)  
  
a  
-----------  
  
(0 row(s) affected)  
  
a  
-----------  
NULL  
  
(1 row(s) affected)  
  
Testing SET ANSI_NULLS OFF  
a  
-----------  
NULL  
  
(1 row(s) affected)  
  
a  
-----------  
0  
1  
  
(2 row(s) affected)  
  
a  
-----------  
NULL  
  
(1 row(s) affected)  
  
```  
  
## See Also  
 [Data Types &#40;Transact-SQL&#41;](../../t-sql/data-types/data-types-transact-sql.md)   
 [Expressions &#40;Transact-SQL&#41;](../../t-sql/language-elements/expressions-transact-sql.md)   
 [Operators &#40;Transact-SQL&#41;](../../t-sql/language-elements/operators-transact-sql.md)  
  
  

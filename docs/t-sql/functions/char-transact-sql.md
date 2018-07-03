﻿---
title: "CHAR (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "07/24/2017"
ms.prod: sql
ms.prod_service: "database-engine, sql-database, sql-data-warehouse, pdw"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: t-sql
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords: 
  - "char_TSQL"
  - "char"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "converting int ACSII code to character"
  - "control characters"
  - "tab"
  - "ASCII conversions"
  - "CHAR function"
  - "carriage return"
  - "inserting control characters"
  - "characters [SQL Server], control"
  - "line feed"
  - "printing ASCII values"
ms.assetid: 955afe94-539c-465d-af22-16ec45da432a
caps.latest.revision: 39
author: edmacauley
ms.author: edmaca
manager: craigg
monikerRange: ">= aps-pdw-2016 || = azuresqldb-current || = azure-sqldw-latest || >= sql-server-2016 || = sqlallproducts-allversions"
---
# CHAR (Transact-SQL)
[!INCLUDE[tsql-appliesto-ss2008-all-md](../../includes/tsql-appliesto-ss2008-all-md.md)]

This function converts an **int** ASCII code to a character value.
  
![Topic link icon](../../database-engine/configure-windows/media/topic-link.gif "Topic link icon") [Transact-SQL Syntax Conventions](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md)
  
## Syntax  
  
```sql
CHAR ( integer_expression )  
```  
  
## Arguments  
*integer_expression*  
An integer from 0 through 255. `CHAR` returns a `NULL` value for integer expressions outside this range.
  
## Return types
**char(1)**
  
## Remarks  
Use `CHAR` to insert control characters into character strings. This table shows some frequently used control characters.
  
|Control character|Value|  
|---|---|
|Tab|**char(9)**|  
|Line feed|**char(10)**|  
|Carriage return|**char(13)**|  
  
## Examples  
  
### A. Using ASCII and CHAR to print ASCII values from a string  
This example prints the ASCII value and character for each character in the string `New Moon`.
  
```sql
SET TEXTSIZE 0;  
-- Create variables for the character string and for the current   
-- position in the string.  
DECLARE @position int, @string char(8);  
-- Initialize the current position and the string variables.  
SET @position = 1;  
SET @string = 'New Moon';  
WHILE @position <= DATALENGTH(@string)  
   BEGIN  
   SELECT ASCII(SUBSTRING(@string, @position, 1)),   
      CHAR(ASCII(SUBSTRING(@string, @position, 1)))  
   SET @position = @position + 1  
   END;  
GO  
```  
  
[!INCLUDE[ssResult](../../includes/ssresult-md.md)]
  
```sql
----------- -
78          N  
----------- -  
101         e  
----------- -  
119         w  
----------- -  
32  
----------- -  
77          M  
----------- -  
111         o  
----------- -  
111         o  
----------- - 
110         n  
```
  
### B. Using CHAR to insert a control character  
This example uses `CHAR(13)` to print the name and e-mail address of an employee on separate lines, when the query returns its results as text. This example uses the [!INCLUDE[ssSampleDBnormal](../../includes/sssampledbnormal-md.md)] database.
  
```sql
SELECT p.FirstName + ' ' + p.LastName, + CHAR(13)  + pe.EmailAddress   
FROM Person.Person p JOIN Person.EmailAddress pe  
ON p.BusinessEntityID = pe.BusinessEntityID  
AND p.BusinessEntityID = 1;  
GO  
```
  
[!INCLUDE[ssResult](../../includes/ssresult-md.md)]
  
```
Ken Sanchez
ken0@adventure-works.com
  
(1 row(s) affected)
```
  
## Examples: [!INCLUDE[ssSDWfull](../../includes/sssdwfull-md.md)] and [!INCLUDE[ssPDW](../../includes/sspdw-md.md)]  
  
### C. Using ASCII and CHAR to print ASCII values from a string  
This example assumes an ASCII character set. It returns the character value for six different ASCII character number values.
  
```sql
SELECT CHAR(65) AS [65], CHAR(66) AS [66],   
CHAR(97) AS [97], CHAR(98) AS [98],   
CHAR(49) AS [49], CHAR(50) AS [50];  
```
  
[!INCLUDE[ssResult](../../includes/ssresult-md.md)]
  
```sql
65   66   97   98   49   50  
---- ---- ---- ---- ---- ----  
A    B    a    b    1    2  
```
  
### D. Using CHAR to insert a control character  
This example uses `CHAR(13)` to return information from sys.databases on separate lines, when the query returns its results as text.
  
```sql
SELECT name, 'was created on ', create_date, CHAR(13), name, 'is currently ', state_desc   
FROM sys.databases;  
GO  
```
  
[!INCLUDE[ssResult](../../includes/ssresult-md.md)]
  
```sql
name     create_date    name    state_desc  
------------------------------------------------------------  
master                   was created on  2003-04-08 09:13:36.390   
master                   is currently  ONLINE  
tempdb                   was created on  2014-01-10 17:24:24.023   
tempdb                   is currently  ONLINE  
AdventureWorksPDW2012    was created on  2014-05-07 09:05:07.083 
AdventureWorksPDW2012    is currently  ONLINE  
```
  
## See also
 [ASCII &#40;Transact-SQL&#41;](../../t-sql/functions/ascii-transact-sql.md)  
 [NCHAR &#40;Transact-SQL&#41;](../../t-sql/functions/nchar-transact-sql.md)  
 [UNICODE &#40;Transact-SQL&#41;](../../t-sql/functions/unicode-transact-sql.md)  
 [+ &#40;String Concatenation&#41; &#40;Transact-SQL&#41;](../../t-sql/language-elements/string-concatenation-transact-sql.md)  
 [String Functions &#40;Transact-SQL&#41;](../../t-sql/functions/string-functions-transact-sql.md)
  
  


﻿---
title: "sp_prepare (Transact SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "02/28/2018"
ms.prod: sql
ms.prod_service: "database-engine, sql-data-warehouse, pdw"
ms.component: "system-stored-procedures"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: system-objects
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords:
  - "sp_cursor_prepare_TSQL"
  - "sp_cursor_prepare"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "sp_prepare"
ms.assetid: f328c9eb-8211-4863-bafa-347e1bf7bb3f
caps.latest.revision: 9
author: edmacauley
ms.author: edmaca
manager: craigg
monikerRange: ">= aps-pdw-2016 || = azure-sqldw-latest || >= sql-server-2016 || = sqlallproducts-allversions"
---
# sp_prepare (Transact SQL)
[!INCLUDE[tsql-appliesto-ss2008-xxxx-asdw-pdw-md](../../includes/tsql-appliesto-ss2008-xxxx-asdw-pdw-md.md)]

  Prepares a parameterized [!INCLUDE[tsql](../../includes/tsql-md.md)] statement and returns a statement *handle* for execution. sp_prepare is invoked by specifying ID = 11 in a tabular data stream (TDS) packet.  
  
 ![Article link icon](../../database-engine/configure-windows/media/topic-link.gif "Topic link icon") [Transact-SQL Syntax Conventions](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md)  
  
## Syntax  
  
```  
  
sp_prepare handle OUTPUT, params, stmt, options  
```  
  
## Arguments  
 *handle*  
 Is a SQL Server-generated *prepared handle* identifier. *handle* is a required parameter with an **int** return value.  
  
 *params*  
 Identifies parameterized statements. The *params* definition of variables is substituted for parameter markers in the statement. *params* is a required parameter that calls for an **ntext**, **nchar**, or **nvarchar** input value. Input a NULL value if the statement is not parameterized.  
  
 *stmt*  
 Defines the cursor result set. The *stmt* parameter is required and calls for an **ntext**, **nchar**, or **nvarchar** input value.  
  
 *options*  
 An optional parameter that returns a description of the cursor result set columns. *options* requires the following int input value:  
  
|Value|Description|  
|-----------|-----------------|  
|0x0001|RETURN_METADATA|  
  
## Examples  
 The following example prepares and executes a simple statement.  
  
```  
Declare @P1 int;  
Exec sp_prepare @P1 output,   
    N'@P1 nvarchar(128), @P2 nvarchar(100)',  
    N'SELECT database_id, name FROM sys.databases WHERE name=@P1 AND state_desc = @P2';  
Exec sp_execute @P1, N'tempdb', N'ONLINE';  
EXEC sp_unprepare @P1;  
```  

  
## See Also  
 [System Stored Procedures &#40;Transact-SQL&#41;](../../relational-databases/system-stored-procedures/system-stored-procedures-transact-sql.md)  
  
  


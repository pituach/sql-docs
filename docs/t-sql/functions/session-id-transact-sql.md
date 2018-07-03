﻿---
title: "SESSION_ID (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "02/23/2018"
ms.prod: sql
ms.prod_service: "sql-data-warehouse, pdw"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: t-sql
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
dev_langs: 
  - "TSQL"
author: edmacauley
ms.author: edmaca
manager: craigg
monikerRange: ">= aps-pdw-2016 || = azure-sqldw-latest || = sqlallproducts-allversions"
---
# SESSION_ID (Transact-SQL)
[!INCLUDE[tsql-appliesto-xxxxxx-xxxx-asdw-pdw-md](../../includes/tsql-appliesto-xxxxxx-xxxx-asdw-pdw-md.md)]

  Returns the ID of the current [!INCLUDE[ssSDW](../../includes/sssdw-md.md)] or [!INCLUDE[ssPDW_md](../../includes/sspdw-md.md)] session.  
  
 ![Topic link icon](../../database-engine/configure-windows/media/topic-link.gif "Topic link icon") [Transact-SQL Syntax Conventions &#40;Transact-SQL&#41;](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md)  
  
## Syntax  
  
```  
-- Azure SQL Data Warehouse and Parallel Data Warehouse  
SESSION_ID ( )  
```  
  
## Return Value  
 Returns an **nvarchar(32)** value.  
  
## General Remarks  
 The session ID is assigned to each user connection when the connection is made. It persists for the duration of the connection. When the connection ends, the session ID is released.  
  
 The session ID begins with the alphabetical characters 'SID'. These are case-sensitive and must be capitalized when session ID is used in [!INCLUDE[DWsql](../../includes/dwsql-md.md)] commands.  
  
 You can query the view [sys.dm_pdw_exec_sessions](../../relational-databases/system-dynamic-management-views/sys-dm-pdw-exec-sessions-transact-sql.md) to retrieve the same information as this function.  
  
## Examples  
 The following example returns the current session ID.  
  
```  
SELECT SESSION_ID();  
```  
  
## See Also  
 [DB_NAME &#40;Transact-SQL&#41;](../../t-sql/functions/db-name-transact-sql.md)   
 [VERSION &#40;SQL Data Warehouse&#41;](../../t-sql/functions/version-transact-sql-configuration-functions.md)
  
  

﻿---
title: "SQLCloseCursor | Microsoft Docs"
ms.custom: ""
ms.date: "03/14/2017"
ms.prod: sql
ms.prod_service: "database-engine, sql-database, sql-data-warehouse, pdw"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: 

ms.tgt_pltfrm: ""
ms.topic: "reference"
apitype: "DLLExport"
helpviewer_keywords: 
  - "SQLCloseCursor function"
ms.assetid: e7134d65-5c1c-4ae2-b119-d9b4b9a42483
caps.latest.revision: 31
author: MightyPen
ms.author: genemi
manager: craigg
monikerRange: ">= aps-pdw-2016 || = azuresqldb-current || = azure-sqldw-latest || >= sql-server-2016 || = sqlallproducts-allversions"
---
# SQLCloseCursor
[!INCLUDE[appliesto-ss-asdb-asdw-pdw-md](../../includes/appliesto-ss-asdb-asdw-pdw-md.md)]
[!INCLUDE[SNAC_Deprecated](../../includes/snac-deprecated.md)]

  **SQLCloseCursor** replaces [SQLFreeStmt](../../relational-databases/native-client-odbc-api/sqlfreestmt.md) with an *Option* value of SQL_CLOSE. On receipt of **SQLCloseCursor**, the [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Native Client ODBC driver discards pending result set rows. Note that the statement's column and parameter bindings (if any exist) are left unaltered by **SQLCloseCursor**.  
  
## See Also  
 [SQLCloseCursor](http://go.microsoft.com/fwlink/?LinkId=59331)   
 [ODBC API Implementation Details](../../relational-databases/native-client-odbc-api/odbc-api-implementation-details.md)  
  
  

---
title: "SQLExecDirect | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "database-engine"
  - "docset-sql-devref"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "SQLExecDirect function"
ms.assetid: e7c2a5b5-83f4-4c72-9aca-7b9fb4748b11
caps.latest.revision: 13
author: MightyPen
ms.author: genemi
manager: craigg
---
# SQLExecDirect
  If the statement attribute SQL_SOPT_SS_PARAM_FOCUS is not 0, SQLExecDirect will return SQL_ERROR and generate a diagnostic record with SQLSTATE=HY024 and the message "Invalid attribute value, SQL_SOPT_SS_PARAM_FOCUS (must be zero at execution time)". For more information about SQL_SOPT_SS_PARAM_FOCUS, see [SQLSetStmtAttr](sqlsetstmtattr.md).  
  
 For more information about table-valued parameters, see [Table-Valued Parameters &#40;ODBC&#41;](../native-client-odbc-table-valued-parameters/table-valued-parameters-odbc.md).  
  
## See Also  
 [SQLExecDirect](http://go.microsoft.com/fwlink/?LinkId=80709)   
 [ODBC API Implementation Details](odbc-api-implementation-details.md)  
  
  

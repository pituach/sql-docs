---
title: "getApplicationName Method (SQLServerDataSource) | Microsoft Docs"
ms.custom: ""
ms.date: "01/19/2017"
ms.prod: sql
ms.prod_service: connectivity
ms.reviewer: ""
ms.suite: "sql"
ms.technology: connectivity
ms.tgt_pltfrm: ""
ms.topic: conceptual
apiname: 
  - "SQLServerDataSource.getApplicationName"
apilocation: 
  - "sqljdbc.jar"
apitype: "Assembly"
ms.assetid: f71e501c-ccd7-4a1e-b6ea-4d47a81c18c6
caps.latest.revision: 13
author: MightyPen
ms.author: genemi
manager: craigg
---
# getApplicationName Method (SQLServerDataSource)
[!INCLUDE[Driver_JDBC_Download](../../../includes/driver_jdbc_download.md)]

  Returns the application name.  
  
## Syntax  
  
```  
  
public java.lang.String getApplicationName()  
```  
  
## Return Value  
 A **String** that contains the application name, or "[!INCLUDE[jdbcNoVersion](../../../includes/jdbcnoversion_md.md)]" if no value is set.  
  
## Remarks  
 The application name is used to identify the specific application in various [!INCLUDE[ssNoVersion](../../../includes/ssnoversion_md.md)] profiling and logging tools. If the application name is not set, the getApplicationName method returns the non-localized string "[!INCLUDE[jdbcNoVersion](../../../includes/jdbcnoversion_md.md)]".  
  
## See Also  
 [SQLServerDataSource Members](../../../connect/jdbc/reference/sqlserverdatasource-members.md)   
 [SQLServerDataSource Class](../../../connect/jdbc/reference/sqlserverdatasource-class.md)  
  
  

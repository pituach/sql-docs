---
title: "getServerPreparedStatementDiscardThreshold Method (SQLServerConnection) | Microsoft Docs"
ms.custom: ""
ms.date: "01/19/2018"
ms.prod: sql
ms.prod_service: connectivity
ms.reviewer: ""
ms.suite: "sql"
ms.technology: connectivity
ms.tgt_pltfrm: ""
ms.topic: conceptual
apiname: 
  - "SQLServerConnection.getServerPreparedStatementDiscardThreshold"
apilocation: 
  - "sqljdbc.jar"
apitype: "Assembly"
ms.assetid:
caps.latest.revision: 1
author: MightyPen
ms.author: genemi
manager: craigg
---
# getServerPreparedStatementDiscardThreshold Method (SQLServerConnection)
[!INCLUDE[Driver_JDBC_Download](../../../includes/driver_jdbc_download.md)]

 Returns the value of **serverPreparedStatementDiscardThreshold** connection property. This setting controls how many outstanding prepared statement discard actions (sp_unprepare) can be outstanding per connection before a call to clean up the outstanding handles on the server is executed. If the setting is <= 1, unprepare actions are executed immediately on prepared statement close. If it's set to > 1, these calls are batched together to avoid overhead of calling sp_unprepare too often. The default for this option can be changed by calling getDefaultServerPreparedStatementDiscardThreshold().

## Syntax  
  
```  
  
public int getServerPreparedStatementDiscardThreshold()  
```  

## Return Value
 An **int** that contains the value of **serverPreparedStatementDiscardThreshold** connection property.

## Exceptions  
 [SQLServerException](../../../connect/jdbc/reference/sqlserverexception-class.md)  
 
## Remarks  
 This method is available from JDBC driver version 6.4 and onward.
 
## See Also  
 [SQLServerConnection Members](../../../connect/jdbc/reference/sqlserverconnection-members.md)   
 [SQLServerConnection Class](../../../connect/jdbc/reference/sqlserverconnection-class.md)  
  
  

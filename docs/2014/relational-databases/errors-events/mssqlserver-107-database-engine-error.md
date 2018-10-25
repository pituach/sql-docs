---
title: "MSSQLSERVER_107 | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: supportability
ms.topic: conceptual
helpviewer_keywords: 
  - "107 (Database Engine error)"
ms.assetid: f33f514c-56aa-42e2-841b-e91244da90e2
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# MSSQLSERVER_107
    
## Details  
  
|||  
|-|-|  
|Product Name|SQL Server|  
|Event ID|107|  
|Event Source|MSSQLSERVER|  
|Component|SQLEngine|  
|Symbolic Name|P_NOCORRMATCH|  
|Message Text|The column prefix '%.*ls' does not match with a table name or alias name used in the query.|  
  
## Explanation  
 The select list of the query contains an asterisk (*) that is incorrectly qualified with a column prefix. This error can be returned under the following conditions:  
  
-   The column prefix does not correspond to any table or alias name used in the query. For example, the following statement uses an alias name (`T1`) as a column prefix, but the alias is not defined in the FROM clause.  
  
    ```  
    SELECT T1.* FROM dbo.ErrorLog;  
    ```  
  
-   A table name is specified as a column prefix when an alias name for the table is supplied in the FROM clause. For example, the following statement uses the table name `ErrorLog` as the column prefix; however, the table has an alias (`T1`) defined in the FROM clause.  
  
    ```  
    SELECT ErrorLog.* FROM dbo.ErrorLog AS T1;  
    ```  
  
     If an alias has been provided for a table name in the FROM clause, you can only use the alias to prefix columns from the table.  
  
## User Action  
 Match the column prefixes against the table names or alias names specified in the FROM clause of the query. For example, the statements above can be corrected as follows:  
  
```  
SELECT T1.* FROM dbo.ErrorLog AS T1;  
```  
  
 or  
  
```  
SELECT ErrorLog.* FROM dbo.ErrorLog;  
```  
  
## See Also  
 [MSSQLSERVER_4104](mssqlserver-4104-database-engine-error.md)  
  
  

﻿---
title: "Include Null Values in JSON - INCLUDE_NULL_VALUES Option | Microsoft Docs"
ms.custom: ""
ms.date: "06/02/2016"
ms.prod: sql
ms.prod_service: "database-engine, sql-database"
ms.component: "json"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: 
  - "dbe-json"
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "INCLUDE_NULL_VALUES (FOR JSON)"
ms.assetid: 06873768-3778-4ed8-a1db-61758726bda0
caps.latest.revision: 14
author: "jovanpop-msft"
ms.author: "jovanpop"
ms.reviewer: douglasl
manager: craigg
monikerRange: "= azuresqldb-current || >= sql-server-2016 || = sqlallproducts-allversions"
---
# Include Null Values in JSON - INCLUDE_NULL_VALUES Option
[!INCLUDE[appliesto-ss-asdb-xxxx-xxx-md](../../includes/appliesto-ss-asdb-xxxx-xxx-md.md)]

  To include null values in the JSON output of the **FOR JSON** clause, specify the **INCLUDE_NULL_VALUES** option.  
  
 If you don't specify the **INCLUDE_NULL_VALUES** option, the JSON output doesn't include properties for values that are null in the query results.  
  
## Examples  
 The following example shows the output of the **FOR JSON** clause with and without the **INCLUDE_NULL_VALUES** option.  
  
|Without the **INCLUDE_NULL_VALUES** option|With the **INCLUDE_NULL_VALUES** option|  
|--------------------------------------------------|-----------------------------------------------|  
|`{    "name": "John",    "surname": "Doe" }`|`{    "name": "John",    "surname": "Doe",    "age": null,    "phone": null }`|  
  
 Here's another example of a **FOR JSON** clause with the **INCLUDE_NULL_VALUES** option.  
  
 **Query**  
  
```sql  
SELECT name, surname  
FROM emp  
FOR JSON AUTO, INCLUDE_NULL_VALUES    
```  
  
 **Result**  
  
```json  
[{
	"name": "John",
	"surname": null
}, {
	"name": "Jane",
	"surname": "Doe"
}] 
```  

## Learn more about JSON in SQL Server and Azure SQL Database  
  
### Microsoft blog posts  
  
For specific solutions, use cases, and recommendations, see these [blog posts](http://blogs.msdn.com/b/sqlserverstorageengine/archive/tags/json/) about the built-in JSON support in SQL Server and Azure SQL Database.  

### Microsoft videos

For a visual introduction to the built-in JSON support in SQL Server and Azure SQL Database, see the following videos:

-   [SQL Server 2016 and JSON Support](https://channel9.msdn.com/Shows/Data-Exposed/SQL-Server-2016-and-JSON-Support)

-   [Using JSON in SQL Server 2016 and Azure SQL Database](https://channel9.msdn.com/Shows/Data-Exposed/Using-JSON-in-SQL-Server-2016-and-Azure-SQL-Database)

-   [JSON as a bridge between NoSQL and relational worlds](https://channel9.msdn.com/events/DataDriven/SQLServer2016/JSON-as-a-bridge-betwen-NoSQL-and-relational-worlds)

## See Also  
 [FOR Clause &#40;Transact-SQL&#41;](../../t-sql/queries/select-for-clause-transact-sql.md)  
  
  

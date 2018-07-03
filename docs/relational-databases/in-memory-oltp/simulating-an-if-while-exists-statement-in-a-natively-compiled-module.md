﻿---
title: "Simulating an IF-WHILE EXISTS Statement in a Natively Compiled Module | Microsoft Docs"
ms.custom: ""
ms.date: "03/01/2017"
ms.prod: sql
ms.prod_service: "database-engine, sql-database"
ms.component: "in-memory-oltp"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: in-memory-oltp
ms.tgt_pltfrm: ""
ms.topic: conceptual
ms.assetid: c0e187c1-cbd9-463c-b417-8a734574f102
caps.latest.revision: 8
author: MightyPen
ms.author: genemi
manager: craigg
monikerRange: "= azuresqldb-current || >= sql-server-2016 || = sqlallproducts-allversions"
---
# Simulating an IF-WHILE EXISTS Statement in a Natively Compiled Module
[!INCLUDE[appliesto-ss-asdb-xxxx-xxx-md](../../includes/appliesto-ss-asdb-xxxx-xxx-md.md)]

  Natively compiled stored procedures do not support the **EXISTS** clause in conditional statements such as IF and WHILE.  
  
 The following example illustrates a workaround using a BIT variable with a SELECT statement to simulate an EXISTS clause:  
  
```sql  
DECLARE @exists BIT = 0  
SELECT TOP 1 @exists = 1 FROM MyTable WHERE …  
IF @exists = 1  
```  
  
## See Also  
 [Migration Issues for Natively Compiled Stored Procedures](../../relational-databases/in-memory-oltp/migration-issues-for-natively-compiled-stored-procedures.md)   
 [Transact-SQL Constructs Not Supported by In-Memory OLTP](../../relational-databases/in-memory-oltp/transact-sql-constructs-not-supported-by-in-memory-oltp.md)  
  
  

﻿---
title: "sys.database_scoped_configurations (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "05/14/2018"
ms.prod: sql
ms.prod_service: "database-engine, sql-database"
ms.component: "system-catalog-views"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: system-objects
ms.tgt_pltfrm: ""
ms.topic: conceptual
f1_keywords: 
  - "database_scoped_configurations"
  - "database_scoped_configurations_TSQL"
  - "sys.database_scoped_configurations"
  - "sys.database_scoped_configurations_TSQL"
helpviewer_keywords: 
  - "sys.database_scoped_configurations catalog view"
ms.assetid: 8899310a-3464-4d38-9f2f-88396c4e7dc2
caps.latest.revision: 13
author: "CarlRabeler"
ms.author: "carlrab"
manager: craigg
monikerRange: "= azuresqldb-current || >= sql-server-2016 || = sqlallproducts-allversions"
---
# sys.database_scoped_configurations (Transact-SQL)
[!INCLUDE[tsql-appliesto-ss2016-asdb-xxxx-xxx-md](../../includes/tsql-appliesto-ss2016-asdb-xxxx-xxx-md.md)]

  Contains one row per configuration. 
  
|Column name|Data type|Description|  
|-----------------|---------------|-----------------|  
|**configuration_id**|**int**|ID of the configuration option.|  
|**name**|**nvarchar(60)**|The name of the configuration option. For information about the possible configurations, see [ALTER DATABASE SCOPED CONFIGURATION &#40;Transact-SQL&#41;](../../t-sql/statements/alter-database-scoped-configuration-transact-sql.md).|  
|**value**|**sqlvariant**|The value set for this configuration option for the primary replica.|  
|**value_for_secondary**|**sqlvariant**|The value set for this configuration option for the secondary replicas.|  
|**elevate_online**|**nvarchar(60)** |The db scoped default set for the online option for index operations |
|**elevate_resumable**|nvarchar(60)|The db scoped default set for the resumable option for index operations| 
  
##  <a name="Permissions"></a> Permissions  
 Requires membership in the **public** role.  
  
## Remarks  
 When NULL is returned as the value for **value_for_secondary**, this means that the secondary is set to PRIMARY.  
 
 Database scoped configuration settings will be carried over with the database. This means that when a given database is restored or attached, the existing configuration settings remain.
  
## See Also  
 [ALTER DATABASE SCOPED CONFIGURATION &#40;Transact-SQL&#41;](../../t-sql/statements/alter-database-scoped-configuration-transact-sql.md)  
  
  

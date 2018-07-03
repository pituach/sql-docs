---
title: "sys.dm_resource_governor_external_resource_pools (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "05/02/2018"
ms.suite: "sql"
ms.prod: sql
ms.technology: machine-learning
ms.reviewer: ""
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords: 
  - "sys.dm_resource_governor_external_resource_pools_TSQL"
  - "sys.dm_resource_governor_external_resource_pools"
  - "dm_resource_governor_external_resource_pools"
  - "dm_resource_governor_external_resource_pools_TSQL"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "dm_resource_governor_external_resource_pools"
  - "sys.dm_resource_governor_external_resource_pools"
author: "HeidiSteen"
ms.author: "heidist"
manager: "cgronlun"
---
# sys.dm_resource_governor_external_resource_pools (Transact-SQL)
[!INCLUDE[tsql-appliesto-ss2016-xxxx-xxxx-xxx-md](../../includes/tsql-appliesto-ss2016-xxxx-xxxx-xxx-md.md)]

Returns information about the current external resource pool state, the current configuration of resource pools, and resource pool statistics. 
  
 ![Topic link icon](../../database-engine/configure-windows/media/topic-link.gif "Topic link icon") [Transact-SQL Syntax Conventions](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md).  
  
|Colmn name      |Data type      |Description|  
|----------------|---------------|-----------------| 
| external_pool_id|**int**|The ID of the resource pool. Is not nullable. |
| name|**sysname**|The name of the resource pool. Is not nullable. 
| pool_version|**int**|nternal version number.|
| max_cpu_percent|**int**|The current configuration for the maximum average CPU bandwidth allowed for all requests in the resource pool when there is CPU contention. Is not nullable. |
| max_processes|**int**|Maximum number of concurrent external processes. The default value, 0, specifies no limit. Is not nullable.|
| max_memory_percent|**int**|The current configuration for the percentage of total server memory that can be used by requests in this resource pool. Is not nullable. |
| statistics_start_time|**datetime**|The time when statistics was reset for this pool. Is not nullable. 
| peak_memory_kb|**bigint**|he maximum amount of memory used, in kilobytes, for the resource pool. Is not nullable. |
| write_io_count|**int**|The total write IOs issued since the Resource Govenor statistics were reset. Is not nullable. |
| read_io_count|**int**|The total read IOs issued since the Resource Govenor statistics were reset. Is not nullable. |
| total_cpu_kernel_ms|**bigint**|The cumulative CPU user time in milliseconds since the Resource Govenor statistics were reset. Is not nullable. |
| total_cpu_user_ms|**bigint**|The cumulative CPU user time in milliseconds since the Resource Govenor statistics were reset. Is not nullable. |
| active_processes_count|**int**|The number of external processes running at the moment of the request. Is not nullable. |

 
## Permissions

Requires `VIEW SERVER STATE` permission.

## See Also  
 [sys.dm_resource_governor_external_resource_pool_affinity &#40;Transact-SQL&#41;](../../relational-databases/system-dynamic-management-views/sys-dm-resource-governor-external-resource-pool-affinity-transact-sql.md)  
  
  

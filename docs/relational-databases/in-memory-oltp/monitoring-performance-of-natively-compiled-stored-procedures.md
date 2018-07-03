﻿---
title: "Monitoring Performance of Natively Compiled Stored Procedures | Microsoft Docs"
ms.custom: ""
ms.date: "04/03/2018"
ms.prod: sql
ms.prod_service: "database-engine, sql-database"
ms.component: "in-memory-oltp"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: in-memory-oltp
ms.tgt_pltfrm: ""
ms.topic: conceptual
ms.assetid: 55548cb2-77a8-4953-8b5a-f2778a4f13cf
caps.latest.revision: 11
author: "CarlRabeler"
ms.author: "carlrab"
manager: craigg
monikerRange: "= azuresqldb-current || >= sql-server-2016 || = sqlallproducts-allversions"
---
# Monitoring Performance of Natively Compiled Stored Procedures
[!INCLUDE[appliesto-ss-asdb-xxxx-xxx-md](../../includes/appliesto-ss-asdb-xxxx-xxx-md.md)]
  This article discusses how you can monitor the performance of natively compiled stored procedures and other natively compiled T-SQL modules.  
  
## Using Extended Events  
 Use the **sp_statement_completed** extended event to trace execution of a query. Create an extended event session with this event, optionally with a filter on object_id for a particular natively compiled stored procedure. The extended event is raised after the execution of each query. The CPU time and duration reported by the extended event indicate how much CPU the query used and the execution time. A natively compiled stored procedure that uses a lot of CPU time may have performance problems.  
  
 **line_number**, along with the **object_id** in the extended event can be used to investigate the query. The following query can be used to retrieve the procedure definition. The line number can be used to identify the query within the definition:  
  
```sql  
select [definition] from sys.sql_modules where object_id=object_id  
```  
  
 For more information about the **sp_statement_completed** extended event, see [How to retrieve the statement that caused an event](http://blogs.msdn.com/b/extended_events/archive/2010/05/07/making-a-statement-how-to-retrieve-the-t-sql-statement-that-caused-an-event.aspx).  
  
## Using Data Management Views and Query Store
 [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] and [!INCLUDE[ssSDS](../../includes/sssds-md.md)] support collecting execution statistics for natively compiled stored procedures, both on the procedure level and the query level. Collecting execution statistics is not enabled by default due to performance impact.  

Execution statistics are reflected in the system views [sys.dm_exec_procedure_stats](../../relational-databases/system-dynamic-management-views/sys-dm-exec-procedure-stats-transact-sql.md) and [sys.dm_exec_query_stats](../../relational-databases/system-dynamic-management-views/sys-dm-exec-query-stats-transact-sql.md), as well as in [Query Store](../../relational-databases/performance/monitoring-performance-by-using-the-query-store.md).

### Enabling Procedure-Level Execution Statistics Collection

**[!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)]**: Enable or disable statistics collection on natively compiled stored procedures at the procedure-level using [sys.sp_xtp_control_proc_exec_stats &#40;Transact-SQL&#41;](../../relational-databases/system-stored-procedures/sys-sp-xtp-control-proc-exec-stats-transact-sql.md).  The following statement enables collection of procedure-level execution statistics for all natively compiled T-SQL modules on the current instance:
```sql
EXEC sys.sp_xtp_control_proc_exec_stats 1
```

**[!INCLUDE[ssSDSFull](../../includes/sssdsfull-md.md)]**: Enable or disable statistics collection on natively compiled stored procedures at the procedure level using the [database-scoped configuration](../../t-sql/statements/alter-database-scoped-configuration-transact-sql.md) option `XTP_PROCEDURE_EXECUTION_STATISTICS`. The following statement enables collection of procedure-level execution statistics for all natively compiled T-SQL modules in the current database:
```sql
ALTER DATABASE SCOPED CONFIGURATION SET XTP_PROCEDURE_EXECUTION_STATISTICS = ON
```

### Enabling Query-Level Execution Statistics Collection

**[!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)]**: Enable or disable statistics collection on natively compiled stored procedures at the query-level using [sys.sp_xtp_control_query_exec_stats &#40;Transact-SQL&#41;](../../relational-databases/system-stored-procedures/sys-sp-xtp-control-query-exec-stats-transact-sql.md).  The following statement enables collection of query-level execution statistics for all natively compiled T-SQL modules on the current instance:
```sql
EXEC sys.sp_xtp_control_query_exec_stats 1
```

**[!INCLUDE[ssSDSFull](../../includes/sssdsfull-md.md)]**: Enable or disable statistics collection on natively compiled stored procedures at the statement level using the [database-scoped configuration](../../t-sql/statements/alter-database-scoped-configuration-transact-sql.md) option `XTP_QUERY_EXECUTION_STATISTICS`. The following statement enables collection of query-level execution statistics for all natively compiled T-SQL modules in the current database:
```sql
ALTER DATABASE SCOPED CONFIGURATION SET XTP_QUERY_EXECUTION_STATISTICS = ON
```

## Sample Queries

 After you collect statistics, the execution statistics for natively compiled stored procedures can be queried for a procedure with [sys.dm_exec_procedure_stats &#40;Transact-SQL&#41;](../../relational-databases/system-dynamic-management-views/sys-dm-exec-procedure-stats-transact-sql.md), and for queries with [sys.dm_exec_query_stats &#40;Transact-SQL&#41;](../../relational-databases/system-dynamic-management-views/sys-dm-exec-query-stats-transact-sql.md).  
 
  
 The following query returns the procedure names and execution statistics for natively compiled stored procedures in the current database, after statistics collection:  
  
```sql  
select object_id,  
       object_name(object_id) as 'object name',  
       cached_time,  
       last_execution_time,  
       execution_count,  
       total_worker_time,  
       last_worker_time,  
       min_worker_time,  
       max_worker_time,  
       total_elapsed_time,  
       last_elapsed_time,  
       min_elapsed_time,  
       max_elapsed_time   
from sys.dm_exec_procedure_stats  
where database_id=db_id() and object_id in (select object_id   
from sys.sql_modules where uses_native_compilation=1)  
order by total_worker_time desc  
```  
  
 The following query returns the query text as well as execution statistics for all queries in natively compiled stored procedures in the current database for which statistics have been collected, ordered by total worker time, in descending order:  
  
```sql  
select st.objectid,   
       object_name(st.objectid) as 'object name',   
       SUBSTRING(st.text, (qs.statement_start_offset/2) + 1, ((qs.statement_end_offset-qs.statement_start_offset)/2) + 1) as 'query text',   
       qs.creation_time,  
       qs.last_execution_time,  
       qs.execution_count,  
       qs.total_worker_time,  
       qs.last_worker_time,  
       qs.min_worker_time,  
       qs.max_worker_time,  
       qs.total_elapsed_time,  
       qs.last_elapsed_time,  
       qs.min_elapsed_time,  
       qs.max_elapsed_time  
from sys.dm_exec_query_stats qs cross apply sys.dm_exec_sql_text(sql_handle) st  
where  st.dbid=db_id() and st.objectid in (select object_id   
from sys.sql_modules where uses_native_compilation=1)  
order by qs.total_worker_time desc  
```  

## Query Execution Plans

 Natively compiled stored procedures support SHOWPLAN_XML (estimated execution plan). The estimated execution plan can be used to inspect the query plan, to find any bad plan issues. Common reasons for bad plans are:  
  
-   Stats were not updated before the procedure was created.  
  
-   Missing indexes  
  
 Showplan XML is obtained by executing the following [!INCLUDE[tsql](../../includes/tsql-md.md)]:  
  
```sql  
SET SHOWPLAN_XML ON  
GO  
EXEC my_proc   
GO  
SET SHOWPLAN_XML OFF  
GO  
```  
  
 Alternatively, in [!INCLUDE[ssManStudioFull](../../includes/ssmanstudiofull-md.md)], select the procedure name and click **Display Estimated Execution Plan**.  
  
 The estimated execution plan for natively compiled stored procedures shows the query operators and expressions for the queries in the procedure. [!INCLUDE[ssSQL14](../../includes/sssql14-md.md)] does not support all SHOWPLAN_XML attributes for natively compiled stored procedures. For example, attributes related to query optimizer costing are not part of the SHOWPLAN_XML for the procedure.  
  
## See Also  
 [Natively Compiled Stored Procedures](../../relational-databases/in-memory-oltp/natively-compiled-stored-procedures.md)  
  
  

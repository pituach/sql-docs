---
title: "Database Checkpoints (SQL Server) | Microsoft Docs"
ms.custom: ""
ms.date: "10/13/2015"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "database-engine"
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "automatic checkpoints"
  - "transaction logs [SQL Server], checkpoints"
  - "logs [SQL Server], active"
  - "pages [SQL Server], dirty"
  - "MinLSN"
  - "checkpoints [SQL Server]"
  - "pages [SQL Server], flushing"
  - "dirty pages"
  - "transaction logs [SQL Server], active logs"
  - "recovery interval option [SQL Server]"
  - "buffer cache [SQL Server]"
  - "logs [SQL Server], checkpoints"
  - "Minimum Recovery LSN"
  - "flushing pages"
  - "active logs"
ms.assetid: 98a80238-7409-4708-8a7d-5defd9957185
caps.latest.revision: 65
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# Database Checkpoints (SQL Server)
  This topic provides an overview of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] database checkpoints. A *checkpoint* creates a known good point from which the [!INCLUDE[ssDEnoversion](../../includes/ssdenoversion-md.md)] can start applying changes contained in the log during recovery after an unexpected shutdown or crash.  
  
  
##  <a name="Overview"></a> Overview of Checkpoints  
 For performance reasons, the [!INCLUDE[ssDE](../../includes/ssde-md.md)] performs modifications to database pages in memory—in the buffer cache—and does not write these pages to disk after every change. Rather, the [!INCLUDE[ssDE](../../includes/ssde-md.md)] periodically issues a checkpoint on each database. A *checkpoint* writes the current in-memory modified pages (known as *dirty pages*) and transaction log information from memory to disk and, also, records information about the transaction log.  
  
 The [!INCLUDE[ssDE](../../includes/ssde-md.md)] supports several types of checkpoints: automatic, indirect, manual, and internal. The following table summarizes the types of checkpoints.  
  
|Name|[!INCLUDE[tsql](../../includes/tsql-md.md)] Interface|Description|  
|----------|----------------------------------|-----------------|  
|Automatic|EXEC sp_configure **'`recovery interval`','*`seconds`*'**|Issued automatically in the background to meet the upper time limit suggested by the `recovery interval` server configuration option. Automatic checkpoints run to completion.  Automatic checkpoints are throttled based on the number of outstanding writes and whether the [!INCLUDE[ssDE](../../includes/ssde-md.md)] detects an increase in write latency above 20 milliseconds.<br /><br /> For more information, see [Configure the recovery interval Server Configuration Option](../../database-engine/configure-windows/configure-the-recovery-interval-server-configuration-option.md).|  
|Indirect|ALTER DATABASE … SET TARGET_RECOVERY_TIME **=***target_recovery_time* { SECONDS &#124; MINUTES }|Issued in the background to meet a user-specified target recovery time for a given database. The default target recovery time is 0, which causes automatic checkpoint heuristics to be used on the database. If you have used ALTER DATABASE to set TARGET_RECOVERY_TIME to >0, this value is used, rather than the recovery interval specified for the server instance.<br /><br /> For more information, see [Change the Target Recovery Time of a Database &#40;SQL Server&#41;](change-the-target-recovery-time-of-a-database-sql-server.md).|  
|Manual|CHECKPOINT [ *checkpoint_duration* ]|Issued when you execute a [!INCLUDE[tsql](../../includes/tsql-md.md)] CHECKPOINT command. The manual checkpoint occurs in the current database for your connection. By default, manual checkpoints run to completion. Throttling works the same way as for automatic checkpoints.  Optionally, the *checkpoint_duration* parameter specifies a requested amount of time, in seconds, for the checkpoint to complete.<br /><br /> For more information, see [CHECKPOINT &#40;Transact-SQL&#41;](/sql/t-sql/language-elements/checkpoint-transact-sql).|  
|Internal|None.|Issued by various server operations such as backup and database-snapshot creation to guarantee that disk images match the current state of the log.|  
  
> [!NOTE]  
>  The `-k`[!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] advanced setup option enables a database administrator to throttle checkpoint I/O behavior based on the throughput of the I/O subsystem for some types of checkpoints. The `-k` setup option applies to automatic checkpoints and any otherwise unthrottled manual and internal checkpoints.  
  
 For automatic, manual, and internal checkpoints, only modifications made after the latest checkpoint need to be rolled forward during database recovery. This reduces the time required to recover a database.  
  
> [!IMPORTANT]  
>  Long-running uncommitted transactions increase recovery time for all types of checkpoints.  
  
  
  
###  <a name="InteractionBwnSettings"></a> Interaction of the TARGET_RECOVERY_TIME and 'recovery interval' Options  
 The following table summarizes the interaction between the server-wide **sp_configure'`recovery interval`'** setting and the database-specific ALTER DATABASE … TARGET_RECOVERY_TIME setting.  
  
|TARGET_RECOVERY_TIME|'recovery interval'|Type of Checkpoint Used|  
|----------------------------|-------------------------|-----------------------------|  
|0|0|automatic checkpoints whose target recovery interval is 1 minute.|  
|0|>0|Automatic checkpoints whose target recovery interval is specified by the user defined setting of the **sp_configurerecovery interval** option.|  
|>0|Not applicable.|Indirect checkpoints whose target recovery time is determined by the TARGET_RECOVERY_TIME setting, expressed in seconds.|  
  
###  <a name="AutomaticChkpt"></a> Automatic Checkpoints  
 An automatic checkpoint occurs each time that  the number of log records reaches the number the [!INCLUDE[ssDE](../../includes/ssde-md.md)] estimates it can process during the time specified in the `recovery interval` server configuration option. In every database without a user-defined target recovery time, the [!INCLUDE[ssDE](../../includes/ssde-md.md)] generates automatic checkpoints. The frequency of automatic checkpoints depends on the `recovery interval` advanced server configuration option, which specifies the maximum time that a given server instance should use to recover a database during a system restart. The [!INCLUDE[ssDE](../../includes/ssde-md.md)] estimates the maximum number of log records it can process within the recovery interval. When a database that is using automatic checkpoints reaches this maximum number of log records, the [!INCLUDE[ssDE](../../includes/ssde-md.md)] issues an checkpoint on the database. The time interval between automatic checkpoints can be highly variable. A database with a substantial transaction workload will have more frequent checkpoints than a database that is used primarily for read-only operations.  
  
 Also, under the simple recovery model, an automatic checkpoint is also queued if the log becomes 70 percent full.  
  
 Under the simple recovery model, unless some factor is delaying log truncation, an automatic checkpoint truncates the unused section of the transaction log. In contrast, under the full and bulk-logged recovery models, once a log backup chain has been established, automatic checkpoints do not cause log truncation. For more information, see [The Transaction Log &#40;SQL Server&#41;](the-transaction-log-sql-server.md).  
  
 After a system crash, the length of time required to recover a given database is largely dependent on the amount of random I/O needed to redo pages that were dirty at the time of the crash. This means that the `recovery interval` setting is unreliable. It cannot determine an accurate recovery duration. Furthermore, when an automatic checkpoint is in progress, the general I/O activity for data increases significantly and quite unpredictably.  
  
  
####  <a name="PerformanceImpact"></a> Impact of Recovery Interval on Recovery Performance  
 For an online transaction processing (OLTP) system using short transactions, `recovery interval` is the primary factor determining recovery time. However, the `recovery interval` option does not affect the time required to undo a long-running transaction. Recovery of a database with a long-running transaction can take much longer than the specified in the `recovery interval` option. For example, if a long-running transaction took two hours to perform updates before the server instance became disabled, the actual recovery takes considerably longer than the `recovery interval` value to recover the long transaction. For more information about the impact of a long running transaction on recovery time, see [The Transaction Log &#40;SQL Server&#41;](the-transaction-log-sql-server.md).  
  
 Typically, the default values provides optimal recovery performance. However, changing the recovery interval might improve performance in the following circumstances:  
  
-   If recovery routinely takes significantly longer than 1 minute when long-running transactions are not being rolled back.  
  
-   If you notice that frequent checkpoints are impairing performance on a database.  
  
 If you decide to increase the `recovery interval` setting, we recommend increasing it gradually by small increments and evaluating the effect of each incremental increase on recovery performance. This approach is important because as the `recovery interval` setting increases, database recovery takes that many times longer to complete. For example, if you change `recovery interval` 10, recovery takes approximately 10 times longer to complete than when `recovery interval` is set to zero.  
  
  
###  <a name="IndirectChkpt"></a> Indirect Checkpoints  
 Indirect checkpoints, new in [!INCLUDE[ssSQL11](../../includes/sssql11-md.md)], provide a configurable database-level alternative to automatic checkpoints. In the event of a system crash, indirect checkpoints provide potentially faster, more predictable recovery time than automatic checkpoints. Indirect checkpoints offer the following advantages:  
  
-   An online transactional workload on a database that is configured for indirect checkpoints could experience performance degradation. Indirect checkpoints make sure that the number of dirty pages are below a certain threshold so that the database recovery completes within the target recovery time. The recovery interval configuration option uses the number of transactions to determine the recovery time as opposed to indirect checkpoints which makes use of number of dirty pages. When indirect checkpoints are enabled on a database receiving a large number of DML operations, the background writer can start aggressively flushing dirty buffers to disk to ensure that the time required to perform recovery is within the target recovery time set of the database. This can cause additional I/O activity on certain systems which can contribute to a performance bottleneck if the disk subsystem is operating above or nearing the I/O threshold.  
  
-   Indirect checkpoints enable you to reliably control database recovery time by factoring in the cost of random I/O during REDO. This enables a server instance to stay within an upper-bound on recovery times for a given database (except when a long-running transaction causes excessive UNDO times).  
  
-   Indirect checkpoints reduce checkpoint-related I/O spiking by continually writing dirty pages to disk in the background.  
  
 However, an online transactional workload on a database that is configured for indirect checkpoints could experience performance degradation. This is because the background writer used by indirect checkpoint sometimes increases the total write load for a server instance.  
  
  
###  <a name="EventsCausingChkpt"></a> Internal Checkpoints  
 Internal Checkpoints are generated by various server components to guarantee that disk images match the current state of the log. Internal checkpoint are generated in response to the following events:  
  
-   Database files have been added or removed by using ALTER DATABASE.  
  
-   A database backup is taken.  
  
-   A database snapshot is created, whether explicitly or internally for DBCC CHECK.  
  
-   An activity requiring a database shutdown is performed. For example, AUTO_CLOSE is ON and the last user connection to the database is closed, or a database option change is made that requires a restart of the database.  
  
-   An instance of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] is stopped by stopping the [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] (MSSQLSERVER) service . Either action  causes a checkpoint in each database in the instance of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)].  
  
-   Bringing a [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] failover cluster instance (FCI) offline.  
  
  
##  <a name="RelatedTasks"></a> Related Tasks  
 **To change the recovery interval on a server instance**  
  
-   [Configure the recovery interval Server Configuration Option](../../database-engine/configure-windows/configure-the-recovery-interval-server-configuration-option.md)  
  
 **To configure indirect checkpoints on a database**  
  
-   [Change the Target Recovery Time of a Database &#40;SQL Server&#41;](change-the-target-recovery-time-of-a-database-sql-server.md)  
  
 **To issue a manual checkpoint on a database**  
  
-   [CHECKPOINT &#40;Transact-SQL&#41;](/sql/t-sql/language-elements/checkpoint-transact-sql)  
  
  
##  <a name="RelatedContent"></a> Related Content  
  
-   [Transaction Log Physical Architecture](http://technet.microsoft.com/library/ms179355.aspx) (in [!INCLUDE[ssKilimanjaro](../../includes/sskilimanjaro-md.md)] Books Oline)  
  
  
## See Also  
 [The Transaction Log &#40;SQL Server&#41;](the-transaction-log-sql-server.md)  
  
  

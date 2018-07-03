---
title: "Always On Availability Groups (SQL Server) | Microsoft Docs"
ms.custom: ""
ms.date: "06/14/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: high-availability
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "Availability Groups [SQL Server], about"
  - "secondary replicas, see Availability Groups [SQL Server]"
  - "availability [SQL Server]"
  - "AlwaysOn [SQL Server], see Availability Groups [SQL Server]"
  - "Availability Groups [SQL Server]"
ms.assetid: aa427606-8422-4656-b205-c9e665ddc8c1
caps.latest.revision: 32
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# Always On Availability Groups (SQL Server)
  The [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] feature is a high-availability and disaster-recovery solution that provides an enterprise-level alternative to database mirroring. Introduced in [!INCLUDE[ssSQL11](../../../includes/sssql11-md.md)], [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] maximizes the availability of a set of user databases for an enterprise. An *availability group* supports a failover environment for a discrete set of user databases, known as *availability databases*, that fail over together. An availability group supports a set of read-write primary databases and one to eight sets of corresponding secondary databases. Optionally, secondary databases can be made available for read-only access and/or some backup operations.  
  
 An availability group fails over at the level of an availability replica. Failovers are not caused by database issues such as a database becoming suspect due to a loss of a data file, deletion of a database, or corruption of a transaction log.  
  
  
##  <a name="Benefits"></a> Benefits  
 [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] provides a rich set of options that improve database availability and that enable improved resource use. The key components are as follows:  
  
-   Supports up to nine availability replicas. An *availability replica* is an instantiation of an availability group that is hosted by a specific instance of SQL Server and maintains a local copy of each availability database that belongs to the availability group. Each availability group supports one primary replica and up to eight secondary replicas. For more information, see [Overview of Always On Availability Groups &#40;SQL Server&#41;](overview-of-always-on-availability-groups-sql-server.md).  
  
    > [!IMPORTANT]  
    >  Each availability replica must reside on a different node of a single Windows Server Failover Clustering (WSFC) cluster. For more information about prerequisites, restrictions, and recommendations for availability groups, see [Prerequisites, Restrictions, and Recommendations for Always On Availability Groups;SQL Server;](prereqs-restrictions-recommendations-always-on-availability.md).  
  
-   Supports alternative availability modes, as follows:  
  
    -   *Asynchronous-commit mode*. This availability mode is a disaster-recovery solution that works well when the availability replicas are distributed over considerable distances.  
  
    -   *Synchronous-commit mode*. This availability mode emphasizes high availability and data protection over performance, at the cost of increased transaction latency. A given availability group can support up to three synchronous-commit availability replicas, including the current primary replica.  
  
     For more information, see [ Availability Modes;Always On Availability Groups;](availability-modes-always-on-availability-groups.md).  
  
-   Supports several forms of availability-group failover:  automatic failover, planned manual failover (generally referred as simply "manual failover"), and forced manual failover (generally referred as simply "forced failover"). For more information, see [Failover and Failover Modes;Always On Availability Groups;](failover-and-failover-modes-always-on-availability-groups.md).  
  
-   Enables you to configure a given availability replica to support either or both of the following active-secondary capabilities:  
  
    -   Read-only connection access which enables read-only connections to the replica to access and read its databases when it is running as a secondary replica. For more information, see [Active Secondaries: Readable Secondary Replicas;Always On Availability Groups](https://msdn.microsoft.com/library/ff878253.aspx)).  
  
    -   Performing backup operations on its databases when it is running as a secondary replica. For more information, see [Active Secondaries: Backup on Secondary Replicas](https://msdn.microsoft.com/library/ff878253.aspx)).  
  
     Using active secondary capabilities improves your IT efficiency and reduce cost through better resource utilization of secondary hardware. In addition, offloading read-intent applications and backup jobs to secondary replicas helps to improve performance on the primary replica.  
  
-   Supports an availability group listener for each availability group. An *availability group listener* is a server name to which clients can connect in order to access a database in a primary or secondary replica of an AlwaysOn availability group. Availability group listeners direct incoming connections to the primary replica or to a read-only secondary replica. The listener provides fast application failover after an availability group fails over. For more information, see [Availability Group Listeners, Client Connectivity, and Application Failover;SQL Server;](../../listeners-client-connectivity-application-failover.md).  
  
-   Supports a flexible failover policy for greater control over availability-group failover. For more information, see [Failover and Failover Modes; Always On Availability Groups;](failover-and-failover-modes-always-on-availability-groups.md).  
  
-   Supports automatic page repair for protection against page corruption. For more information, see [Automatic Page Repair &#40;For Availability Groups and Database Mirroring;](../../../sql-server/failover-clusters/automatic-page-repair-availability-groups-database-mirroring.md).  
  
-   Supports encryption and compression, which provide a secure, high performing transport.  
  
-   Provides an integrated set of tools to simplify deployment and management of availability groups, including:  
  
    -   [!INCLUDE[tsql](../../../includes/tsql-md.md)] DDL statements for creating and managing availability groups. For more information, see [Overview of Transact-SQL Statements for Always On Availability Group;SQL Server;](transact-sql-statements-for-always-on-availability-groups.md).  
  
    -   [!INCLUDE[ssManStudioFull](../../../includes/ssmanstudiofull-md.md)] tools, as follows:  
  
        -   The [!INCLUDE[ssAoNewAgWiz](../../../includes/ssaonewagwiz-md.md)] creates and configures an availability group. In some environments, this wizard can also automatically prepare the secondary databases and start data synchronization for each of them. For more information, see [Use the New Availability Group Dialog Box;SQL Server Management Studio;](use-the-new-availability-group-dialog-box-sql-server-management-studio.md).  
  
        -   The [!INCLUDE[ssAoAddDbWiz](../../../includes/ssaoadddbwiz-md.md)] adds one or more primary databases to an existing availability group. In some environments, this wizard can also automatically prepare the secondary databases and start data synchronization for each of them. For more information, see [Use the Add Database to Availability Group Wizard (SQL Server)](availability-group-add-database-to-group-wizard.md).  
  
        -   The [!INCLUDE[ssAoAddRepWiz](../../../includes/ssaoaddrepwiz-md.md)] adds one or more secondary replicas to an existing availability group. In some environments, this wizard can also automatically prepare the secondary databases and start data synchronization for each of them. For more information, see [Use the Add Replica to Availability Group Wizard;SQL Server Management Studio;](use-the-add-replica-to-availability-group-wizard-sql-server-management-studio.md).  
  
        -   The [!INCLUDE[ssAoFoAgWiz](../../../includes/ssaofoagwiz-md.md)] initiates a manual failover on an availability group. Depending on the configuration and state of the secondary replica that you specify as the failover target, the wizard can perform either a planned or forced manual failover. For more information, see [Use the Fail Over Availability Group Wizard;SQL Server Management Studio;](use-the-fail-over-availability-group-wizard-sql-server-management-studio.md).  
  
    -   The [!INCLUDE[ssAoDash](../../../includes/ssaodash-md.md)] monitors AlwaysOn availability groups, availability replicas, and availability databases and evaluates results for AlwaysOn policies. For more information, see [Use the AlwaysOn Dashboard;SQL Server Management Studio;](use-the-always-on-dashboard-sql-server-management-studio.md).  
  
    -   The Object Explorer Details pane displays basic information about existing availability groups. For more information, see [Use the Object Explorer Details to Monitor Availability Group;SQL Server Management Studio;](use-object-explorer-details-to-monitor-availability-groups.md).  
  
    -   PowerShell cmdlets. For more information, see [Overview of PowerShell Cmdlets for Always On Availability Groups;SQL Serve;](overview-of-powershell-cmdlets-for-always-on-availability-groups-sql-server.md).  
  
##  <a name="TermsAndDefinitions"></a> Terms and Definitions  
 availability group  
 A container for a set of databases, *availability databases*, that fail over together.  
  
 availability database  
 A database that belongs to an availability group. For each availability database, the availability group maintains a single read-write copy (the *primary database*) and one to eight read-only copies (*secondary databases*).  
  
 primary database  
 The read-write copy of an availability database.  
  
 secondary database  
 A read-only copy of an availability database.  
  
 availability replica  
 An instantiation of an availability group that is hosted by a specific instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] and maintains a local copy of each availability database that belongs to the availability group. Two types of availability replicas exist: a single *primary replica* and one to eight *secondary replicas*.  
  
 primary replica  
 The availability replica that makes the primary databases available for read-write connections from clients and, also, sends transaction log records for each primary database to every secondary replica.  
  
 secondary replica  
 An availability replica that maintains a secondary copy of each availability database, and serves as a potential failover targets for the availability group. Optionally, a secondary replica can support read-only access to secondary databases can support creating backups on secondary databases.  
  
 availability group listener  
 A server name to which clients can connect in order to access a database in a primary or secondary replica of an Always On availability group. Availability group listeners direct incoming connections to the primary replica or to a read-only secondary replica.  
  
> [!NOTE]  
>  For more information, see [Overview of AlwaysOn Availability Groups;SQL Serve;](overview-of-always-on-availability-groups-sql-server.md).  
  
##  <a name="Interoperability"></a> Interoperability and Coexistence with Other Database Engine Features  
 [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] can be used with the following features or components of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)]:  
  
-   [About Change Data Capture;SQL Server;](../../../relational-databases/track-changes/about-change-data-capture-sql-server.md)  
  
-   [About Change Tracking;SQL Serve;](../../../relational-databases/track-changes/about-change-tracking-sql-server.md)  
  
-   [Contained databases](../../../relational-databases/databases/contained-databases.md)  
  
-   [Database encryption](../../../relational-databases/security/encryption/transparent-data-encryption.md)  
  
-   [Database snapshots](database-snapshots-with-always-on-availability-groups-sql-server.md)  
  
-   [FILESTREAM](../../../relational-databases/blob/filestream-sql-server.md)  
  
-   [FileTable](../../../relational-databases/blob/filetables-sql-server.md)  
  
-   [Log shipping](../../log-shipping/about-log-shipping-sql-server.md)  
  
-   [Remote Blob Store (RBS)](../../../relational-databases/blob/remote-blob-store-rbs-sql-server.md)  
  
-   [Replication](../../install-windows/install-sql-server-replication.md)  
  
-   [Service Broker](../../configure-windows/sql-server-service-broker.md)  
  
-   [SQL Server Agent](../../../ssms/agent/sql-server-agent.md)  
  
-   [Reporting Services](reporting-services-with-always-on-availability-groups-sql-server.md)  
  
> [!WARNING]  
>  For information about restrictions and limitations for using other features with [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)], see [Always On Availability Groups: Interoperability;SQL Server;](always-on-availability-groups-interoperability-sql-server.md).  
  
##  <a name="RelatedTasks"></a> Related Tasks  
  
-   [Getting Started with Always On Availability Groups;SQL Server;](getting-started-with-always-on-availability-groups-sql-server.md)  
  
##  <a name="RelatedContent"></a> Related Content  
  
-   **Blogs:**  
  
     [SQL Server Always On Team Blogs: The official SQL Server AlwaysOn Team Blog](http://blogs.msdn.com/b/sqlalwayson/)  
  
     [CSS SQL Server Engineers Blogs](http://blogs.msdn.com/b/psssql/)  
  
-   **Videos:**  
  
     [Microsoft SQL Server Code-Named "Denali" Always On Series,Part 1: Introducing the Next Generation High Availability Solution](http://channel9.msdn.com/Events/TechEd/NorthAmerica/2011/DBI302)  
  
     [Microsoft SQL Server Code-Named "Denali" Always On Series,Part 2: Building a Mission-Critical High Availability Solution Using AlwaysOn](http://channel9.msdn.com/Events/TechEd/NorthAmerica/2011/DBI404)  
  
-   **Whitepapers:**  
  
     [Microsoft SQL Server Always On Solutions Guide for High Availability and Disaster Recovery](http://go.microsoft.com/fwlink/?LinkId=227600)  
  
  
  
## See Also  
 [Overview of Always On Availability Groups;SQL Server;](overview-of-always-on-availability-groups-sql-server.md)   
 [Prerequisites, Restrictions, and Recommendations for AlwaysOn Availability Groups &#40;SQL Server&#41;](prereqs-restrictions-recommendations-always-on-availability.md)   
 [Configuration of a Server Instance for Always On Availability Groups;SQL Server;](always-on-availability-groups-sql-server.md)   
 [Creation and Configuration of Availability Groups;SQL Server;](creation-and-configuration-of-availability-groups-sql-server.md)   
 [Administration of an Availability Group;SQL Server;](administration-of-an-availability-group-sql-server.md)   
 [Monitoring of Availability Groups &#40;SQL Server&#41;](monitoring-of-availability-groups-sql-server.md)   
 [Overview of Transact-SQL Statements for Always On Availability Groups;SQL Server;](transact-sql-statements-for-always-on-availability-groups.md)   
 [Overview of PowerShell Cmdlets for AlwaysOn Availability Groups;SQL Server;](overview-of-powershell-cmdlets-for-always-on-availability-groups-sql-server.md)  
  
  

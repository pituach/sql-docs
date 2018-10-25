---
title: "Configuration of a Server Instance for Always On Availability Groups (SQL Server) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: high-availability
ms.topic: conceptual
helpviewer_keywords: 
  - "Availability Groups [SQL Server], server instance"
  - "Availability Groups [SQL Server], about"
ms.assetid: fad8db32-593e-49d5-989c-39eb8399c416
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# Configuration of a Server Instance for Always On Availability Groups (SQL Server)
  This topic contains information about the requirements for configuring an instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] to support [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] in [!INCLUDE[ssCurrent](../../../includes/sscurrent-md.md)].  
  
> [!IMPORTANT]  
>  For essential information about [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] prerequisites and restrictions for Windows Server Failover Clustering (WSFC) nodes and for instances of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)], see [Prerequisites, Restrictions, and Recommendations for AlwaysOn Availability Groups &#40;SQL Server&#41;](prereqs-restrictions-recommendations-always-on-availability.md).  
  
 
  
##  <a name="TermsAndDefinitions"></a> Terms and Definitions  
  
 A high-availability and disaster-recovery solution that provides an enterprise-level replacement for database mirroring. An *availability group* supports a failover environment for a discrete set of user databases, known as *availability databases*, that fail over together.  
  
 availability replica  
 An instantiation of an availability group that is hosted by a specific instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] and that maintains a local copy of each availability database that belongs to the availability group. Two types of availability replicas exist: a single *primary replica* and one to four *secondary replicas*. The server instances that host the availability replicas for a given availability group must reside on different nodes of a single Windows Server Failover Clustering (WSFC) cluster.  
  
 [database mirroring endpoint](../../database-mirroring/the-database-mirroring-endpoint-sql-server.md)  
 An endpoint is a SQL Server object that enables SQL Server to communicate over the network. To participate in database mirroring and/or [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] a server instance requires a special, dedicated endpoint. All mirroring and availability group connections on a server instance use the same database mirroring endpoint. This endpoint is a special-purpose endpoint used exclusively to receive these connections from other server instances.  
  
##  <a name="ConfigSI"></a> To Configure a Server Instance to Support AlwaysOn Availability Groups  
 To support [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)], a server instance must reside on a node in the WSFC failover cluster that hosts the availability group, be [!INCLUDE[ssHADR](../../../includes/sshadr-md.md)] enabled, and possess a database mirroring endpoint.  
  
1.  Enable the AlwaysOn Availability Groups feature on every server instance that is to participate in one or more availability groups. A given server instance can host only a single availability replica for a given availability group.  
  
2.  Ensure that the server instance possesses a database mirroring endpoint.  
  
##  <a name="RelatedTasks"></a> Related Tasks  
 **To enable AlwaysOn Availability Groups**  
  
-   [Enable and Disable AlwaysOn Availability Groups &#40;SQL Server&#41;](enable-and-disable-always-on-availability-groups-sql-server.md)  
  
 **To determine whether a database mirroring endpoint exists**  
  
-   [sys.database_mirroring_endpoints &#40;Transact-SQL&#41;](/sql/relational-databases/system-catalog-views/sys-database-mirroring-endpoints-transact-sql)  
  
 **To create a database mirroring endpoint**  
  
-   [Create a Database Mirroring Endpoint for AlwaysOn Availability Groups &#40;SQL Server PowerShell&#41;](database-mirroring-always-on-availability-groups-powershell.md)  
  
-   [Create a Database Mirroring Endpoint for Windows Authentication &#40;Transact-SQL&#41;](../../database-mirroring/create-a-database-mirroring-endpoint-for-windows-authentication-transact-sql.md)  
  
-   [Allow a Database Mirroring Endpoint to Use Certificates for Outbound Connections &#40;Transact-SQL&#41;](../../database-mirroring/database-mirroring-use-certificates-for-outbound-connections.md)  
  
##  <a name="RelatedContent"></a> Related Content  
  
-   **Blogs:**  
  
     [AlwaysON - HADRON Learning Series: Worker Pool Usage for HADRON Enabled Databases](http://blogs.msdn.com/b/psssql/archive/2012/05/17/alwayson-hadron-learning-series-worker-pool-usage-for-hadron-enabled-databases.aspx)  
  
     [SQL Server AlwaysOn Team Blogs: The official SQL Server AlwaysOn Team Blog](http://blogs.msdn.com/b/sqlalwayson/)  
  
     [CSS SQL Server Engineers Blogs](http://blogs.msdn.com/b/psssql/)  
  
-   **Videos:**  
  
     [Microsoft SQL Server Code-Named "Denali" AlwaysOn Series,Part 1: Introducing the Next Generation High Availability Solution](http://channel9.msdn.com/Events/TechEd/NorthAmerica/2011/DBI302)  
  
     [Microsoft SQL Server Code-Named "Denali" AlwaysOn Series,Part 2: Building a Mission-Critical High Availability Solution Using AlwaysOn](http://channel9.msdn.com/Events/TechEd/NorthAmerica/2011/DBI404)  
  
-   **Whitepapers:**  
  
     [Microsoft SQL Server AlwaysOn Solutions Guide for High Availability and Disaster Recovery](http://go.microsoft.com/fwlink/?LinkId=227600)  
  
     [Microsoft White Papers for SQL Server 2012](http://msdn.microsoft.com/library/hh403491.aspx)  
  
     [SQL Server Customer Advisory Team Whitepapers](http://sqlcat.com/)  
  
## See Also  
 [Overview of AlwaysOn Availability Groups &#40;SQL Server&#41;](overview-of-always-on-availability-groups-sql-server.md)   
 [Prerequisites, Restrictions, and Recommendations for AlwaysOn Availability Groups &#40;SQL Server&#41;](prereqs-restrictions-recommendations-always-on-availability.md)   
 [The Database Mirroring Endpoint &#40;SQL Server&#41;](../../database-mirroring/the-database-mirroring-endpoint-sql-server.md)   
 [AlwaysOn Availability Groups: Interoperability (SQL Server)](always-on-availability-groups-interoperability-sql-server.md)   
 [Failover Clustering and AlwaysOn Availability Groups &#40;SQL Server&#41;](failover-clustering-and-always-on-availability-groups-sql-server.md)   
 [Windows Server Failover Clustering &#40;WSFC&#41; with SQL Server](../../../sql-server/failover-clusters/windows/windows-server-failover-clustering-wsfc-with-sql-server.md)   
 [AlwaysOn Failover Cluster Instances](../../../sql-server/failover-clusters/windows/always-on-failover-cluster-instances-sql-server.md)  
  
  

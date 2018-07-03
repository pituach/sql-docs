---
title: "Remove Database Mirroring (SQL Server) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: high-availability
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "database mirroring [SQL Server], removing"
  - "removing database mirroring [SQL Server]"
ms.assetid: bbc4d7f7-3bc7-40d6-a822-af195fe7f8c0
caps.latest.revision: 41
author: MikeRayMSFT
ms.author: mikeray
manager: craigg
---
# Remove Database Mirroring (SQL Server)
  This topic describes how to remove database mirroring from a database in [!INCLUDE[ssCurrent](../../includes/sscurrent-md.md)] by using [!INCLUDE[ssManStudioFull](../../includes/ssmanstudiofull-md.md)] or [!INCLUDE[tsql](../../includes/tsql-md.md)].  At any time, the database owner can manually stop a database mirroring session by removing mirroring from the database.  
  
 
  
##  <a name="BeforeYouBegin"></a> Before You Begin  
  
###  <a name="Security"></a> Security  
  
####  <a name="Permissions"></a> Permissions  
 Requires ALTER permission on the database.  
  
##  <a name="SSMSProcedure"></a> Using SQL Server Management Studio  
  
#### To remove database mirroring  
  
1.  During a database mirroring session, connect to the principal server instance, in Object Explorer, click the server name to expand the server tree.  
  
2.  Expand **Databases**, and select the database.  
  
3.  Right-click the database, select **Tasks**, and then click **Mirror**. This opens the **Mirroring** page of the **Database Properties** dialog box.  
  
4.  In the **Select a Page** pane, click **Mirroring**.  
  
5.  To remove mirroring, click **Remove Mirroring**. A prompt asks for confirmation. If you click **Yes**, the session is stopped and mirroring is removed from the database.  
  
##  <a name="TsqlProcedure"></a> Using Transact-SQL  
 To remove database mirroring, use the **Database Properties**. use the **Mirroring** page of the **Database Properties** dialog box.  
  
#### To remove database mirroring  
  
1.  Connect to the [!INCLUDE[ssDE](../../includes/ssde-md.md)] of either mirroring partner.  
  
2.  From the Standard bar, click **New Query**.  
  
3.  Issue the following [!INCLUDE[tsql](../../includes/tsql-md.md)] statement:  
  
    ```  
    ALTER DATABASE database_name SET PARTNER OFF  
    ```  
  
     where *database_name* is the mirrored database whose session you want to remove.  
  
     The following example removes database mirroring from the [!INCLUDE[ssSampleDBobject](../../includes/sssampledbobject-md.md)] sample database.  
  
    ```  
    ALTER DATABASE AdventureWorks2012 SET PARTNER OFF;  
    ```  
  
##  <a name="FollowUp"></a> Follow Up: Removing Database Mirroring  
  
> [!NOTE]  
>  For information about the impact of removing mirroring, see [Removing Database Mirroring &#40;SQL Server&#41;](database-mirroring-sql-server.md).  
  
-   **If you intend to restart mirroring on the database**  
  
     Any log backups taken on the principal database after mirroring was removed must all be applied to the mirror database before you can restart mirroring.  
  
-   **If you do not intent to restart mirroring**  
  
     Optionally, you can recover the former mirror database. On the server instance that was the mirror server, you can use the following [!INCLUDE[tsql](../../includes/tsql-md.md)] statement:  
  
    ```  
    RESTORE DATABASE database_name WITH RECOVERY;  
    ```  
  
    > [!IMPORTANT]  
    >  If you recover this database, two divergent databases with the same name are online. Therefore, you need to ensure that clients can access only one of them—typically the most recent principal database.  
  
##  <a name="RelatedTasks"></a> Related Tasks  
  
-   [Pause or Resume a Database Mirroring Session &#40;SQL Server&#41;](pause-or-resume-a-database-mirroring-session-sql-server.md)  
  
-   [Remove the Witness from a Database Mirroring Session &#40;SQL Server&#41;](remove-the-witness-from-a-database-mirroring-session-sql-server.md)  
  
-   [Establish a Database Mirroring Session Using Windows Authentication &#40;SQL Server Management Studio&#41;](establish-database-mirroring-session-windows-authentication.md)  
  
-   [Establish a Database Mirroring Session Using Windows Authentication &#40;Transact-SQL&#41;](database-mirroring-establish-session-windows-authentication.md)  
  
-   [Example: Setting Up Database Mirroring Using Certificates &#40;Transact-SQL&#41;](example-setting-up-database-mirroring-using-certificates-transact-sql.md)  
  
## See Also  
 [Database Mirroring &#40;SQL Server&#41;](database-mirroring-sql-server.md)   
 [Setting Up Database Mirroring &#40;SQL Server&#41;](setting-up-database-mirroring-sql-server.md)   
 [AlwaysOn Availability Groups (SQL Server)](../availability-groups/windows/always-on-availability-groups-sql-server.md)  
  
  

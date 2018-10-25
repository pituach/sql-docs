---
title: "Assign a Job to a Job Category | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology:
ms.topic: conceptual
helpviewer_keywords: 
  - "jobs [SQL Server Agent], assigning"
  - "SQL Server Agent jobs, categories"
  - "jobs [SQL Server Agent], categories"
  - "categories [SQL Server Agent jobs]"
  - "SQL Server Agent jobs, assigning"
  - "assigning job to category"
ms.assetid: a9ea65a2-1d73-4582-a335-63adeb450cb6
author: stevestein
ms.author: sstein
manager: craigg
---
# Assign a Job to a Job Category
  This topic describes how to assign [!INCLUDE[msCoName](../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Agent jobs to job categories in [!INCLUDE[ssCurrent](../../includes/sscurrent-md.md)] by using [!INCLUDE[ssManStudioFull](../../includes/ssmanstudiofull-md.md)], [!INCLUDE[tsql](../../includes/tsql-md.md)] or SQL Server Management Objects.  
  
 Job categories help you organize your jobs for easy filtering and grouping. For example, you can organize all your database backup jobs in the Database Maintenance category. You can assign jobs to built-in job categories, or you can create a user-defined job category and then assign jobs to that.  
  
  
##  <a name="BeforeYouBegin"></a> Before You Begin  
  
###  <a name="Security"></a> Security  
 For detailed information, see [Implement SQL Server Agent Security](implement-sql-server-agent-security.md).  
  
  
  
##  <a name="SSMS"></a> Using SQL Server Management Studio  
  
#### To assign a job to a job category  
  
1.  In **Object Explorer**, click the plus sign to expand the server where you want to assign a job to a job category.  
  
2.  Click the plus sign to expand **SQL Server Agent**.  
  
3.  Click the plus sign to expand the **Jobs** folder.  
  
4.  Right-click the job you want to edit and select **Properties**.  
  
5.  In the **Job Properties -***job_name* dialog box, in the **Category** list, select the job category you want to assign to the job.  
  
6.  Click **OK**.  
  
  
##  <a name="TSQL"></a> Using Transact-SQL  
  
#### To assign a job to a job category  
  
1.  In **Object Explorer**, connect to an instance of [!INCLUDE[ssDE](../../includes/ssde-md.md)].  
  
2.  On the Standard bar, click **New Query**.  
  
3.  Copy and paste the following example into the query window and click **Execute**.  
  
    ```  
    -- adding a new job category to the "NightlyBackups" job  
    USE msdb ;  
    GO  
    EXEC dbo.sp_update_job  
        @job_name = N'NightlyBackups',  
        @category_name = N'[Uncategorized (Local)]';  
    GO  
    ```  
  
 For more information, see [sp_update_job &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-update-job-transact-sql).  
  
  
  
##  <a name="SMO"></a> Using SQL Server Management Objects  
 **To assign a job to a job category**  
  
 Use the `JobCategory` class by using a programming language that you choose, such as Visual Basic, Visual C#, or PowerShell.  
  
  
  
  

﻿---
title: "Pick Schedule for Job | Microsoft Docs"
ms.custom: ""
ms.date: "01/19/2017"
ms.prod: sql
ms.prod_service: "sql-tools"
ms.component: "ssms-agent"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: ssms
ms.tgt_pltfrm: ""
ms.topic: conceptual
f1_keywords: 
  - "sql13.ag.job.pickscheduleforjob.f1"
helpviewer_keywords: 
  - "Pick Schedule for Job dialog box"
ms.assetid: 6de2025d-c25c-47b9-9a25-18c294935c15
caps.latest.revision: 3
author: "stevestein"
ms.author: "sstein"
manager: craigg
monikerRange: "= azuresqldb-mi-current || >= sql-server-2016 || = sqlallproducts-allversions"
---
# Pick Schedule for Job
[!INCLUDE[appliesto-ss-asdbmi-xxxx-xxx-md](../../includes/appliesto-ss-asdbmi-xxxx-xxx-md.md)]

> [!IMPORTANT]  
> On [Azure SQL Database Managed Instance](https://docs.microsoft.com/azure/sql-database/sql-database-managed-instance), most, but not all SQL Server Agent features are currently supported. See [Azure SQL Database Managed Instance T-SQL differences from SQL Server](https://docs.microsoft.com/azure/sql-database/sql-database-managed-instance-transact-sql-information#sql-server-agent) for details.

Use this dialog to pick an existing schedule for the [!INCLUDE[msCoName](../../includes/msconame_md.md)] [!INCLUDE[ssNoVersion](../../includes/ssnoversion_md.md)] Agent job.  
  
## Options  
**Available schedules**  
Lists the schedules available for this job. Because a job and a schedule must have the same owner, this list only includes schedules owned by the owner of the job.  
  
**Name**  
Displays the name of the schedule.  
  
**Enabled**  
Selected if the schedule is enabled.  
  
**Description**  
Describes the conditions under which the schedule runs the job.  
  
**Jobs in schedule**  
Lists the job numbers attached to the schedule. Click a number to view the properties of the job.  
  
**Properties**  
Launches the **Job Schedule Properties** dialog where you can view information about the schedule.  
  
## See Also  
[Create and Attach Schedules to Jobs](../../ssms/agent/create-and-attach-schedules-to-jobs.md)  
  

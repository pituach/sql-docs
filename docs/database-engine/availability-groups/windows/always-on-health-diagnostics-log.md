---
title: "Always On Availability Groups health diagnostics log (SQL Server) | Microsoft Docs"
ms.custom: "ag-guide"
ms.date: "06/13/2017"
ms.prod: sql
ms.reviewer: ""
ms.suite: ""
ms.technology: high-availability
ms.tgt_pltfrm: ""
ms.topic: conceptual
ms.assetid: c1862d8a-5f82-4647-a280-3e588b82a6dc
caps.latest.revision: 5
author: rothja
ms.author: jroth
manager: craigg
---
# Always On Availability Groups health diagnostics log
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md](../../../includes/appliesto-ss-xxxx-xxxx-xxx-md.md)]
  To monitor the health of the primary availability replica, the SQL Server resource DLL run by the Windows Server Failover Clustering (WSFC) cluster uses a stored procedure in the SQL Server instance called [sp_server_diagnostics](~/relational-databases/system-stored-procedures/sp-server-diagnostics-transact-sql.md).  
  
 The SQL Server resource DLL maintains a dedicated open connection with the SQL Server instance, through which the SQL Server instance periodically sends detailed health diagnostics to the SQL Server resource DLL. The health diagnostics, coupled with the failover policy configured in the availability group resource in the cluster (the FailoverConditionLevel property), are used by the cluster to determine whether to restart or fail over the availability group resource. This stored procedure is the SQL Server 2012 and above instance “heartbeat” to the WSFC cluster, which is more granular and reliable than in SQL Server 2008 R2 or lower, where a periodic connection to the instance is made with the query `SELECT @@SERVERNAME`. You can then control the conditions that trigger failovers by setting the availability group FailureConditonLevel property.  
  
 **Use the SQL Server failover cluster diagnostic logs**
 
 All the health diagnostics SQL Server Resource DLL receives from sp_server_diagnostics are automatically saved in the default Log directory of the SQL Server instance (%PROGRAMFILES%\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Log). These logs are known as SQLDIAG logs and are saved in the XEL (extended events) file format. These files in the SQL Server Log directory have the following format: \<HOSTNAME>_\<INSTANCENAME>_SQLDIAG_X_XXXXXXXXX.xel. By looking at the SQLDIAG logs, you may be able to determine the root cause of availability group resource failure or failover event.  
  
 To view a SQLDIAG log, drag the .xel file into SQL Server Management Studio.  
  
  
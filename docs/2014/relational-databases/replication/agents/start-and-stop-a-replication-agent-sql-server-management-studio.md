---
title: "Start and Stop a Replication Agent (SQL Server Management Studio) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "replication"
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "agents [SQL Server replication], stopping"
  - "agents [SQL Server replication], starting"
ms.assetid: 97977c4a-8c7c-4a22-9480-69aa812bd1e5
caps.latest.revision: 40
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# Start and Stop a Replication Agent (SQL Server Management Studio)
  Start and stop agents from the **Jobs** folder and the **Replication** folder in [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssManStudioFull](../../../includes/ssmanstudiofull-md.md)] and from Replication Monitor. Start and stop the following agents and jobs:  
  
-   The Snapshot Agent, which is used by all publications.  
  
-   The Log Reader Agent, which is used by all transactional publications.  
  
-   The Queue Reader Agent, which is used by transactional publications enabled for queued updating subscriptions.  
  
-   The Distribution Agent, which synchronizes subscriptions to transactional and snapshot publications.  
  
-   The Merge Agent, which synchronizes subscriptions to merge publications.  
  
-   Replication maintenance jobs.  
  
 For more information about starting the Merge Agent and the Distribution Agent, see [Synchronize a Push Subscription](../synchronize-a-push-subscription.md) and [Synchronize a Pull Subscription](../synchronize-a-pull-subscription.md). For more information about maintenance jobs, see [Run Replication Maintenance Jobs &#40;SQL Server Management Studio&#41;](../../../ssms/sql-server-management-studio-ssms.md).  
  
 For information about starting Replication Monitor, see [Start the Replication Monitor](../monitor/start-the-replication-monitor.md).  
  
### To start and stop a Snapshot Agent or Log Reader Agent from Management Studio  
  
1.  Connect to the Publisher in [!INCLUDE[ssManStudio](../../../includes/ssmanstudio-md.md)], and then expand the server node and the **Replication** folder.  
  
2.  Expand the **Local Publications** folder, and then right-click a publication.  
  
3.  Click **View Snapshot Agent Status** or **View Log Reader Agent Status**.  
  
4.  Click **Start** or **Stop**.  
  
### To start and stop a Queue Reader Agent from Management Studio  
  
1.  Connect to the Distributor in [!INCLUDE[ssManStudio](../../../includes/ssmanstudio-md.md)], and then expand the server node.  
  
2.  Expand the **SQL Server Agent** folder, and then expand the **Jobs** folder.  
  
3.  Right-click the job for the agent, and then click **Start Job** or **Stop Job**. The name of the job for the Queue Reader Agent is in the form **[\<Distributor>].\<integer>**.  
  
### To start and stop a Snapshot Agent, Log Reader Agent, or Queue Reader Agent from Replication Monitor  
  
1.  Expand a Publisher group in the left pane, expand a Publisher, and then click a publication.  
  
2.  Click the **Agents** tab.  
  
3.  Right-click an agent, and then click **Start Agent** or **Stop Agent**.  
  
## See Also  
 [Monitoring Replication](../monitoring-replication.md)   
 [Replication Agent Executables Concepts](../concepts/replication-agent-executables-concepts.md)   
 [Replication Agents Overview](replication-agents-overview.md)  
  
  

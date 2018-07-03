---
title: "Agent Profiles (single agent) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "replication"
ms.tgt_pltfrm: ""
ms.topic: conceptual
f1_keywords: 
  - "sql12.rep.profiles.perfprofileagentname.f1"
helpviewer_keywords: 
  - "Agent Profile dialog box"
ms.assetid: 22713555-c496-4ce1-8ec7-4ae75cfadca8
caps.latest.revision: 17
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# Agent Profiles (single agent)
  Use the **Agent Profiles** dialog box to manage profiles for an agent. Agent profiles provide a convenient way to manage the runtime parameters for each agent. Each agent has a default profile, and some agents have additional predefined profiles. For example, the Merge Agent has a "slow link" profile designed for low bandwidth connections. Predefined profiles are sufficient for most applications, but you can also create user-defined profiles, allowing you to customize agent behavior.  
  
## Options  
 **Default for New**  
 Select the profile that will be used when jobs are created for an agent of a given type. For example, if you create a number of subscriptions to a merge publication, the Merge Agent job for each subscription will use the profile selected. If you want to change the profile for existing jobs, select a profile, and then click **Change Existing Agents**.  
  
 **Name**  
 The name of the profile.  
  
 **Type**  
 The type of profile: **User** (user-defined) or **System** (predefined).  
  
 **Properties (...)**  
 Click to view the values used for each parameter in the agent profile.  
  
 **New**  
 Click to create a new profile.  
  
 **Delete**  
 Select a user-defined profile, and then click **Delete** to delete that profile. Predefined profiles cannot be deleted.  
  
 **Change Existing Agents**  
 Select a profile, and then click **Change Existing Agents** to specify that all existing jobs for an agent of a given type should use the selected profile. For example, if you have created a number of subscriptions to a merge publication, and you want to change the profile to specify that the Merge Agent job for each of these subscriptions should use the **Slow link agent profile**, select that profile, and then click **Change Existing Agents**.  
  
## See Also  
 [Work with Replication Agent Profiles](agents/work-with-replication-agent-profiles.md)   
 [Replication Agents Overview](agents/replication-agents-overview.md)   
 [Replication Agent Profiles](agents/replication-agent-profiles.md)  
  
  

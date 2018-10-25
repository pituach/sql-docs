---
title: "Enable Updating Subscriptions for Transactional Publications | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: 
  - "replication"
ms.topic: conceptual
helpviewer_keywords: 
  - "transactional replication, updatable subscriptions"
  - "updatable subscriptions, enabling"
  - "subscriptions [SQL Server replication], updatable"
ms.assetid: 539d5bb0-b808-4d8c-baf4-cb6d32d2c595
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# Enable Updating Subscriptions for Transactional Publications
  This topic describes how to enable updating subscriptions for transactional publications in [!INCLUDE[ssCurrent](../../../includes/sscurrent-md.md)] by using [!INCLUDE[ssManStudioFull](../../../includes/ssmanstudiofull-md.md)] or [!INCLUDE[tsql](../../../includes/tsql-md.md)].  
  
> [!NOTE]  
>  [!INCLUDE[ssNoteDepFutureAvoid](../../../includes/ssnotedepfutureavoid-md.md)]  
  

  
##  <a name="BeforeYouBegin"></a> Before You Begin  
  
###  <a name="Security"></a> Security  
 When possible, prompt users to enter security credentials at runtime. If you must store credentials in a script file, you must secure the file to prevent unauthorized access.  
  
##  <a name="SSMSProcedure"></a> Using SQL Server Management Studio  
 Enable updating subscriptions for transactional publications on the **Publication Type** page of the New Publication Wizard. For more information about using this wizard, see [Create a Publication](create-a-publication.md). You cannot enable updating subscriptions after a publication is created.  
  
 To use updating subscriptions, you must also configure options in the New Subscription Wizard. For more information, see [Create an Updatable Subscription to a Transactional Publication](../create-updatable-subscription-transactional-publication-transact-sql.md).  
  
#### To enable updating subscriptions  
  
1.  On the **Publication Type** page of the New Publication Wizard, select **Transactional publication with updatable subscriptions**.  
  
2.  On the **Agent Security** page, specify security settings for the Queue Reader Agent in addition to the Snapshot Agent and Log Reader Agent. For more information about the permissions required for the account under which the Queue Reader Agent runs, see [Replication Agent Security Model](../security/replication-agent-security-model.md).  
  
    > [!NOTE]  
    >  The Queue Reader Agent is configured even if you use only immediate updating subscriptions.  
  
##  <a name="TsqlProcedure"></a> Using Transact-SQL  
 When creating a transactional publication programmatically using replication stored procedures, you can enable either immediate or queued updating subscriptions.  
  
#### To create a publication that supports immediate updating subscriptions  
  
1.  If necessary, create a Log Reader Agent job for the publication database.  
  
    -   If a Log Reader Agent job already exists for the publication database, proceed to step 2.  
  
    -   If you are unsure whether a Log Reader Agent job exists for a published database, execute [sp_helplogreader_agent &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-helplogreader-agent-transact-sql) at the Publisher on the publication database. If the result set is empty, a Log Reader Agent job must be created.  
  
    -   At the publisher, execute [sp_addlogreader_agent &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-addlogreader-agent-transact-sql). Specify the [!INCLUDE[msCoName](../../../includes/msconame-md.md)] Windows credentials under which the agent runs for **@job_name** and **@password**. If the agent will use SQL Server Authentication when connecting to the Publisher, you must also specify a value of **0** for **@publisher_security_mode** and the [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] login information for **@publisher_login** and **@publisher_password**.  
  
2.  Execute [sp_addpublication &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-addpublication-transact-sql), specifying a value of **true** for the parameter **@allow_sync_tran**.  
  
3.  At the Publisher, execute [sp_addpublication_snapshot &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-addpublication-snapshot-transact-sql). Specify the publication name used in step 2 for **@publication** and the Windows credentials under which the Snapshot Agent runs for **@job_name** and **@password**. If the agent will use SQL Server Authentication when connecting to the Publisher, you must also specify a value of **0** for **@publisher_security_mode** and the [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] login information for **@publisher_login** and **@publisher_password**. This creates a Snapshot Agent job for the publication.  
  
4.  Add articles to the publication. For more information, see [Define an Article](define-an-article.md).  
  
5.  At the Subscriber, create an updating subscription to this publication. For more information, see [Create an Updatable Subscription to a Transactional Publication](../create-updatable-subscription-transactional-publication-transact-sql.md).  
  
#### To create a publication that supports queued updating subscriptions  
  
1.  If necessary, create a Log Reader Agent job for the publication database.  
  
    -   If a Log Reader Agent job already exists for the publication database, proceed to step 2.  
  
    -   If you are unsure whether a Log Reader Agent job exists for a published database, execute [sp_helplogreader_agent &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-helplogreader-agent-transact-sql) at the Publisher on the publication database. If the result set is empty, then a Log Reader Agent job must be created.  
  
    -   At the publisher, execute [sp_addlogreader_agent &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-addlogreader-agent-transact-sql). Specify the Windows credentials under which the agent runs for **@job_name** and **@password**. If the agent will use SQL Server Authentication when connecting to the Publisher, you must also specify a value of **0** for **@publisher_security_mode** and the [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] login information for **@publisher_login** and **@publisher_password**.  
  
2.  If necessary, create a Queue Reader Agent job for the Distributor.  
  
    -   If a Queue Reader Agent job already exists for the distribution database, proceed to step 3.  
  
    -   If you are unsure whether a Queue Reader Agent job exists for the distribution database, execute [sp_helpqreader_agent &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-helpqreader-agent-transact-sql) at the Distributor on the distribution database. If the result set is empty, then a Queue Reader Agent job must be created.  
  
    -   At the Distributor, execute [sp_addqreader_agent &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-addqreader-agent-transact-sql). Specify the Windows credentials under which the agent runs for **@job_name** and **@password**. These credentials are used when the Queue Reader Agent connects to the Publisher and Subscriber. For more information, see [Replication Agent Security Model](../security/replication-agent-security-model.md).  
  
3.  Execute [sp_addpublication &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-addpublication-transact-sql), specifying a value of **true** for the parameter **@allow_queued_tran** and a value of **pub wins**, **sub reinit**, or **sub wins** for **@conflict_policy**.  
  
4.  At the Publisher, execute [sp_addpublication_snapshot &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-addpublication-snapshot-transact-sql). Specify the publication name used in step 3 for **@publication** and the Windows credentials under which the Snapshot Agent runs for **@snapshot_job_name** and **@password**. If the agent will use SQL Server Authentication when connecting to the Publisher, you must also specify a value of **0** for **@publisher_security_mode** and the [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] login information for **@publisher_login** and **@publisher_password**. This creates a Snapshot Agent job for the publication.  
  
5.  Add articles to the publication. For more information, see [Define an Article](define-an-article.md).  
  
6.  At the Subscriber, create an updating subscription to this publication. For more information, see [Create an Updatable Subscription to a Transactional Publication](../create-updatable-subscription-transactional-publication-transact-sql.md).  
  
#### To change the conflict policy for a publication that allows queued updating subscriptions  
  
1.  At the Publisher on the publication database, execute [sp_changepublication &#40;Transact-SQL&#41;](/sql/relational-databases/system-stored-procedures/sp-changepublication-transact-sql). Specify a value of **conflict_policy** for **@property** and the desired conflict policy mode of **pub wins**, **sub reinit**, or **sub wins** for **@value**.  
  
###  <a name="TsqlExample"></a> Example (Transact-SQL)  
 This example creates a publication that supported both immediate and queued updating pull subscriptions.  
  
 [!code-sql[HowTo#sp_createtranupdatingpub](../../../snippets/tsql/SQL15/replication/howto/tsql/createtranpubupdate.sql#sp_createtranupdatingpub)]  
  
## See Also  
 [Set Queued Updating Conflict Resolution Options &#40;SQL Server Management Studio&#41;](../publish/set-queued-updating-conflict-resolution-options-sql-server-management-studio.md)   
 [Publication Types for Transactional Replication](../transactional/publication-types-for-transactional-replication.md)   
 [Updatable Subscriptions for Transactional Replication](../transactional/updatable-subscriptions-for-transactional-replication.md)   
 [Create a Publication](create-a-publication.md)   
 [Create an Updatable Subscription to a Transactional Publication](../create-updatable-subscription-transactional-publication-transact-sql.md)   
 [Updatable Subscriptions for Transactional Replication](../transactional/updatable-subscriptions-for-transactional-replication.md)   
 [Use sqlcmd with Scripting Variables](../../scripting/sqlcmd-use-with-scripting-variables.md)  
  
  

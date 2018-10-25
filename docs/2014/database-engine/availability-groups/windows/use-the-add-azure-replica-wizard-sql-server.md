---
title: "Use the Add Azure Replica Wizard (SQL Server) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: high-availability
ms.topic: conceptual
f1_keywords: 
  - "sql12.swb.addreplicawizard.azurereplica.f1"
ms.assetid: b89cc41b-07b4-49f3-82cc-bc42b2e793ae
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# Use the Add Azure Replica Wizard (SQL Server)
  Use the Add Azure Replica Wizard to help you create a new Windows Azure VM in hybrid IT and configure it as a secondary replica for a new or existing AlwaysOn availability group.  
  
-   **Before you begin:**  
  
     [Prerequisites](#Prerequisites)  
  
     [Security](#Security)  
  
-   **To add a replica, using:**  [Add Azure Replica Wizard (SQL Server Management Studio)](#SSMSProcedure)  
  
##  <a name="BeforeYouBegin"></a> Before You Begin  
 If you have never added any availability replica to an availability group, see the "Server instances" and "Availability groups and replicas" sections in [Prerequisites, Restrictions, and Recommendations for AlwaysOn Availability Groups &#40;SQL Server&#41;](prereqs-restrictions-recommendations-always-on-availability.md).  
  
###  <a name="Prerequisites"></a> Prerequisites  
  
-   You must be connected to the server instance that hosts the current primary replica.  
  
-   You must have a hybrid-IT environment where your on-premise subnet has a site-to-site VPN with Windows Azure. For more information, see [Configure a Site-to-Site VPN in the Management Portal](https://azure.microsoft.com/documentation/articles/vpn-gateway-site-to-site-create).  
  
-   Your availability group must contain on-premise availability replicas.  
  
-   Clients to the availability group listener must have connectivity to the Internet if they want to maintain connectivity with the listener when the availability group is failed over to a Windows Azure replica.  
  
-   **Prerequisites for using full initial data synchronization** You will need to specify a network share in order for the wizard to create and access backups. For the primary replica, the account used to start the [!INCLUDE[ssDE](../../../includes/ssde-md.md)] must have read and write file-system permissions on a network share. For secondary replicas, the account must have read permission on the network share.  
  
     If you are unable to use the wizard to perform full initial data synchronization, you need to prepare your secondary databases manually. You can do this before or after running the wizard. For more information, see [Manually Prepare a Secondary Database for an Availability Group &#40;SQL Server&#41;](manually-prepare-a-secondary-database-for-an-availability-group-sql-server.md).  
  
###  <a name="Security"></a> Security  
  
####  <a name="Permissions"></a> Permissions  
 See [Security](use-the-add-replica-to-availability-group-wizard-sql-server-management-studio.md#Security)  
  
##  <a name="SSMSProcedure"></a> Using the Add Azure Replica Wizard (SQL Server Management Studio)  
 The Add Azure Replica Wizard can be launched from the [Specify Replicas Page](specify-replicas-page-new-availability-group-wizard-add-replica-wizard.md). There are two ways to reach this page:  
  
-   [Use the Availability Group Wizard &#40;SQL Server Management Studio&#41;](use-the-availability-group-wizard-sql-server-management-studio.md)  
  
-   [Use the Add Replica to Availability Group Wizard &#40;SQL Server Management Studio&#41;](use-the-add-replica-to-availability-group-wizard-sql-server-management-studio.md)  
  
 Once you have launched the Add Azure Replica Wizard, follow the steps below:  
  
1.  First, download a management certificate for your Windows Azure subscription. Click **Download** to open the sign-in page.  
  
2.  In the sign-in page, sign in to your Windows Azure subscription. Once you are signed in, the wizard installs a management certificate onto your local machine. This management certificate is automatically loaded when you use this wizard again. If you have downloaded multiple management certificates, you can click the **...** button to select the one you want to use.  
  
3.  Next, connect to your subscription by clicking **Connect**. Once you are connected, the drop-down lists are populated with your Windows Azure parameters, such as **Virtual Network** and **Virtual Network Subnet**.  
  
4.  Specify the settings for the Windows Azure VM that will host the new secondary replica:  
  
     Image  
     The name of the SQL Server image to use for the Windows Azure VM  
  
     VM Size  
     The size of the Windows Azure VM  
  
     VM Name  
     The DNS name of the Windows Azure VM  
  
     VM Username  
     The username of the default administrator for the Windows Azure VM  
  
     VM Administrator Password (and Confirm Password)  
     The password for the default administrator for the Windows Azure VM  
  
     Virtual Network  
     The virtual network in which to place the Windows Azure VM  
  
     Virtual Network Subnet  
     The virtual network subnet in which to place the Windows Azure VM  
  
     Domain  
     The Active Directory (AD) domain to join the Windows Azure VM  
  
     Domain Username  
     The AD username used to join the Windows Azure VM to the domain  
  
     Password  
     The password used to join the Windows Azure VM to the domain  
  
5.  Click **OK** to commit your settings and exit the Add Azure Replica Wizard.  
  
6.  Continue with the rest of the configuration steps for [Specify Replicas Page](specify-replicas-page-new-availability-group-wizard-add-replica-wizard.md) as you do for any new replica.  
  
     Once you are finished with the Availability Group Wizard or the Add Replica to Availability Group Wizard, the configuration process performs all operations in Windows Azure to create the new VM, join it to the AD domain, add it to the Windows cluster, enable AlwaysOn High Availability, and add the new replica to the availability group.  
  
##  <a name="RelatedTasks"></a> Related Tasks  
  
-   [Add a Secondary Replica to an Availability Group &#40;SQL Server&#41;](add-a-secondary-replica-to-an-availability-group-sql-server.md)  
  
## See Also  
 [Overview of AlwaysOn Availability Groups &#40;SQL Server&#41;](overview-of-always-on-availability-groups-sql-server.md)   
 [Prerequisites, Restrictions, and Recommendations for AlwaysOn Availability Groups &#40;SQL Server&#41;](prereqs-restrictions-recommendations-always-on-availability.md)   
 [Add a Secondary Replica to an Availability Group &#40;SQL Server&#41;](add-a-secondary-replica-to-an-availability-group-sql-server.md)  
  
  

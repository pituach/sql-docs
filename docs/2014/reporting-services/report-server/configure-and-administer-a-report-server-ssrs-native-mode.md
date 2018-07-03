---
title: "Configure and Administer a Report Server (SSRS Native Mode) | Microsoft Docs"
ms.custom: ""
ms.date: "08/10/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "reporting-services-native"
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "Reporting Services, components"
  - "deploying [Reporting Services], component options"
  - "report servers [Reporting Services], component options"
  - "configuration options [Reporting Services]"
  - "administering Reporting Services"
  - "components [Reporting Services], configuring"
  - "configuring servers [Reporting Services]"
ms.assetid: cfec012b-56f1-4346-9814-247acf22351c
caps.latest.revision: 50
author: markingmyname
ms.author: maghan
manager: craigg
---
# Configure and Administer a Report Server (SSRS Native Mode)
  This topic summarizes the approaches that you can use to configure [!INCLUDE[ssRSnoversion](../../includes/ssrsnoversion-md.md)]. It also includes a list of topics that explain how to configure specific components, features, or server capabilities. To configure [!INCLUDE[ssRSnoversion](../../includes/ssrsnoversion-md.md)], you can:  
  
-   Use the Reporting Services Configuration Manager. Many of the topics in this section contain information about how to configure specific features through this tool.  
  
-   Use [!INCLUDE[ssManStudio](../../includes/ssmanstudio-md.md)] to customize server properties, enable My Reports, enable trace logs, and set site-wide defaults. For more information about site settings, see [Reporting Services Report Server &#40;Native Mode&#41;](reporting-services-report-server-native-mode.md) for Management Studio. Note that you can create and run script that sets server properties programmatically. For more information, see [Script Deployment and Administrative Tasks](../tools/script-deployment-and-administrative-tasks.md) and [Report Server System Properties](../report-server-web-service/net-framework/reporting-services-properties-report-server-system-properties.md).  
  
-   Use Report Manager to grant permissions to access the report server. Permissions are conveyed through role assignments that you define for each user or group account. For more information, see [Roles and Permissions &#40;Reporting Services&#41;](../security/roles-and-permissions-reporting-services.md).  
  
-   Optionally, modify configuration files to change application settings. For more information about each file and guidelines for modifying them, see [Reporting Services Configuration Files](reporting-services-configuration-files.md).  
  
## In This Section  
 [Configure Report Server URLs  &#40;SSRS Configuration Manager&#41;](../install-windows/configure-report-server-urls-ssrs-configuration-manager.md)  
 Describes how to define the URLs used to access the report server and Report Manager.  
  
 [Configure the Report Server Service Account &#40;SSRS Configuration Manager&#41;](../install-windows/configure-the-report-server-service-account-ssrs-configuration-manager.md)  
 Provides recommendations and steps on how to modify service account and password.  
  
 [Create a Report Server Database  &#40;SSRS Configuration Manager&#41;](../../sql-server/install/create-a-report-server-database-ssrs-configuration-manager.md)  
 Describes how to create a report server database, required for storing server metadata and objects.  
  
 [Configure a Report Server Database Connection  &#40;SSRS Configuration Manager&#41;](../../sql-server/install/configure-a-report-server-database-connection-ssrs-configuration-manager.md)  
 Describes how to modify the connection string used by the report server to connect to the report server database.  
  
 [Configure a Report Server for E-Mail Delivery &#40;SSRS Configuration Manager&#41;](../../sql-server/install/configure-a-report-server-for-e-mail-delivery-ssrs-configuration-manager.md)  
 Describes how to configure a report server to support e-mail report distribution.  
  
 [Configure the Unattended Execution Account &#40;SSRS Configuration Manager&#41;](../install-windows/configure-the-unattended-execution-account-ssrs-configuration-manager.md)  
 Describes how to configure a user account to process reports in unattended mode.  
  
## See Also  
 [Configure Report Builder Access](configure-report-builder-access.md)   
 [Reporting Services Configuration Files](reporting-services-configuration-files.md)   
 [Reporting Services Configuration Manager &#40;Native Mode&#41;](../../sql-server/install/reporting-services-configuration-manager-native-mode.md)   
 [Reporting Services Security and Protection](../security/reporting-services-security-and-protection.md)   
 [Reporting Services Report Server &#40;Native Mode&#41;](reporting-services-report-server-native-mode.md)  
  
  

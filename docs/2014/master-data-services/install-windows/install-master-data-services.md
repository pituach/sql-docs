---
title: "Install Master Data Services | Microsoft Docs"
ms.custom: ""
ms.date: "05/24/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: 
  - "database-engine"
ms.topic: conceptual
ms.assetid: bb7aa3e7-8807-42c8-884f-0e41d7a20837
author: leolimsft
ms.author: lle
manager: craigg
---
# Install Master Data Services
  The following workflow provides an overview of how to install and configure [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)]. [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] installation is a three-part process:  
  
-   [Pre-Installation Tasks](#preinstall): Verify system requirements before you install [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)].  
  
-   [Installation Operations](#install): Install [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] by using [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Setup or the command prompt.  
  
-   [Post-Installation Tasks](#postinstall): Open [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] to complete post-installation operations. Create and configure the [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] database, [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] web application, and web services, and deploy a sample model.  
  
##  <a name="preinstall"></a> Pre-Installation Tasks  
  
|Action|Details|Related Topics|  
|------------|-------------|--------------------|  
|Verify installation requirements|The computer where you run [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Setup must meet minimum requirements for:<br /><br /> [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Setup.<br /><br /> The [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] web application and web services.<br /><br /> The [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] database, if you host the database on the same computer as the web application.<br /><br /> Note that you can separate the web server computer and database server computer by running Setup on only the web server computer and creating the [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] database on a remote computer that runs a supported version and edition of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)].|[Features Supported by the Editions of SQL Server 2014](../../getting-started/features-supported-by-the-editions-of-sql-server-2014.md)<br /><br /> [Hardware and Software Requirements for Installing SQL Server 2014](../../sql-server/install/hardware-and-software-requirements-for-installing-sql-server.md)<br /><br /> [Web Application Requirements &#40;Master Data Services&#41;](web-application-requirements-master-data-services.md)<br /><br /> [Database Requirements &#40;Master Data Services&#41;](database-requirements-master-data-services.md)|  
|Configure the required roles, role services, and features|Before you run Setup, configure the computer with the required Windows roles, role services, and features.<br /><br /> Note: Although you can perform this step later in the workflow, it is helpful to configure this prior to running Setup so that you can perform web configuration tasks immediately following the installation.|[Web Application Requirements &#40;Master Data Services&#41;](web-application-requirements-master-data-services.md)|  
|Review language support considerations|Determine the language that you want to install and run [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] in.|[Multi-Lingual and Global Deployments &#40;Master Data Services&#41;](multi-lingual-and-global-deployments-master-data-services.md)|  
  
##  <a name="install"></a> Installation Operations  
  
|Action|Details|Related Topics|  
|------------|-------------|--------------------|  
|Run [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Setup|On the computer that will host the [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] web application and [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] web services, use [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Setup or a command prompt to install [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)]. When you use [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Setup, [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] is available on the **Feature Selection** page under **Shared Features**. When you use a command prompt, [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] is available as a feature parameter. Note that the command-line setup process installs [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)], but does not configure it. You must configure it using the Master Data Services Configuration Manager. The installation process:<br /><br /> Installs [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] folders and files at the location you specify for shared features, and assigns permissions to these objects.<br /><br /> Registers [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] assemblies in the Global Assembly Cache (GAC).<br /><br /> Installs [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)].|[Install SQL Server 2014 from the Installation Wizard &#40;Setup&#41;](../../database-engine/install-windows/install-sql-server-from-the-installation-wizard-setup.md)<br /><br /> [Folder and File Permissions &#40;Master Data Services&#41;](../folder-and-file-permissions-master-data-services.md)|  
  
##  <a name="postinstall"></a> Post-Installation Tasks  
  
|Action|Details|Related Topics|  
|------------|-------------|--------------------|  
|Open [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] to complete post-installation operations|After Setup completes, open [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)]. [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] performs the following post-installation operations on the local computer:<br /><br /> Creates a Windows group, **MDS_ServiceAccounts**, to contain [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] service accounts for application pools.<br /><br /> Under the [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] installation path, creates the MDSTempDir folder and assigns permissions for **MDS_ServiceAccounts**. This folder is where temporary compilation files are compiled for the [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] web application.<br /><br /> In the [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] Web.config file, configures the `tempDirectory` attribute of the **\<compilation>** element with the path to the MDSTempDir folder.<br /><br /> <br /><br /> If you script the installation process, you can open [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] to register the [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] snap-in, but you must manually perform the other steps to complete the configuration. [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] provides you with a wizard-driven configuration process. There is no command-line process for configuring [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)].|[Folder and File Permissions &#40;Master Data Services&#41;](../folder-and-file-permissions-master-data-services.md)<br /><br /> [Web Configuration Reference &#40;Master Data Services&#41;](../web-configuration-reference-master-data-services.md)|  
|Create a [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] database|Use [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] to create a [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] database for your master data.|[Create a Master Data Services Database](create-a-master-data-services-database.md)|  
|Create a [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] web application|Use [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] to create and configure a web application to host [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)].|[Create a Master Data Manager Web Application &#40;Master Data Services&#41;](create-a-master-data-manager-web-application-master-data-services.md)|  
|Associate a [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] database with a web application|Use [!INCLUDE[ssMDScfgmgr](../../includes/ssmdscfgmgr-md.md)] to associate your [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] web application with your [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] database.|[Associate a Master Data Services Database and Web Application](associate-a-master-data-services-database-and-web-application.md)|  
|Configure Internet Explorer Enhanced Security|When you install [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] on a Windows Server 2008 or Windows Server 2008 R2 computer, you might have to configure Internet Explorer Enhanced Security to allow scripting for the [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] application site. Otherwise, browsing to the [!INCLUDE[ssMDSmdm](../../includes/ssmdsmdm-md.md)] application site on the server computer will fail.|[Internet Explorer: Enhanced Security Configuration](http://go.microsoft.com/fwlink/p/?LinkId=223869)|  
|Install the [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)][!INCLUDE[ssMDSXLS](../../includes/ssmdsxls-md.md)]|Users who will work with master data can install the [!INCLUDE[ssMDSXLS](../../includes/ssmdsxls-md.md)].|[http://go.microsoft.com/fwlink/?LinkId=219530](http://go.microsoft.com/fwlink/?LinkId=219530)|  
|Enable Data Quality Services (DQS) integration|For users of the [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)][!INCLUDE[ssMDSXLS](../../includes/ssmdsxls-md.md)], enable integration with the DQS feature, which can be used to match similar data.|[Enable Data Quality Services Integration with Master Data Services](enable-data-quality-services-integration-with-master-data-services.md)|  
|Deploy a sample model|Sample model packages are installed with Master Data Services, and can be deployed using MDSModelDeploy.exe.|[Deploying MDS Samples in SQL Server](http://go.microsoft.com/fwlink/?LinkId=251486&clcid=0x409)|  
  
 If you encounter issues during the installation process or initial configuration, see [Troubleshooting Installation and Configuration Issues](http://social.technet.microsoft.com/wiki/contents/articles/troubleshooting-installation-and-configuration-issues-master-data-services.aspx) on TechNet Wiki.  
  
 If you no longer need [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] on a computer, you can uninstall [!INCLUDE[ssMDSshort](../../includes/ssmdsshort-md.md)] and determine whether to remove items that are not affected by the uninstall process. For more information, see [Uninstall and Remove Master Data Services](../../sql-server/install/uninstall-and-remove-master-data-services.md).  
  
## See Also  
 [Install SQL Server 2014](../../database-engine/install-windows/install-sql-server.md)  
  
  

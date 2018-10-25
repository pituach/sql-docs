---
title: "Download SQL Server Data Tools (SSDT) | Microsoft Docs"
ms.custom: ""
ms.date: "09/28/2018"
ms.prod: sql
ms.prod_service: "sql-tools"
ms.reviewer: ""
ms.technology: ssdt
ms.topic: conceptual
keywords: 
  - "install ssdt, download ssdt, latest ssdt"
ms.assetid: b0fc4987-d260-4d0a-9dd1-98099835b361
author: "stevestein"
ms.author: "sstein"
manager: craigg
monikerRange: ">=aps-pdw-2016||=azuresqldb-current||=azure-sqldw-latest||>=sql-server-2016||=sqlallproducts-allversions||=azuresqldb-mi-current"
---
# Download and install SQL Server Data Tools (SSDT) for Visual Studio
[!INCLUDE[appliesto-ss-asdb-asdw-pdw-md.md](../includes/appliesto-ss-asdb-asdw-pdw-md.md)]
**SQL Server Data Tools** is a modern development tool for building SQL Server relational databases, Azure SQL databases, Analysis Services (AS) data models, Integration Services (IS) packages, and Reporting Services (RS) reports. With SSDT, you can design and deploy any SQL Server content type with the same ease as you would develop an application in Visual Studio.

*For most users, SQL Server Data Tools (SSDT) is installed during Visual Studio installation. Installing SSDT using the Visual Studio installer adds the base SSDT functionality, so you still need to run the [SSDT standalone installer](#ssdt-for-vs-2017-standalone-installer) to get AS, IS, and RS tools.*

## Install SSDT with Visual Studio 2017

To install SSDT during [Visual Studio installation](https://docs.microsoft.com/visualstudio/install/install-visual-studio), select the **Data storage and processing** workload, and then select **SQL Server Data Tools**. If Visual Studio is already installed, you can [edit the list of workloads](https://docs.microsoft.com/visualstudio/install/modify-visual-studio) to include SSDT:
![Data storage and processing workload](../ssdt/media/download-sql-server-data-tools-ssdt/data-workload.png)



## Install Analysis Services, Integration Services, and Reporting Services tools
To install AS, IS, and RS project support, run the [SSDT standalone installer](#ssdt-for-vs-2017-standalone-installer). 

The installer lists available Visual Studio instances to add the SSDT tools to. If Visual Studio is not installed, selecting **Install a new SQL Server Data Tools instance** installs SSDT with a minimal version of Visual Studio, but for the best experience we recommend using SSDT with [the latest version of Visual Studio](https://www.visualstudio.com/downloads). 

![select AS, IS, RS](../ssdt/media/download-sql-server-data-tools-ssdt/select-services.png)



## SSDT for VS 2017 (standalone installer)

[![download](../ssdt/media/download.png) Download SSDT for Visual Studio 2017 (15.8.1) ](https://go.microsoft.com/fwlink/?linkid=2024393) 

> [!IMPORTANT]
> - Before installing SSDT for Visual Studio 2017 (15.8.1), uninstall *Analysis Services Projects* and *Reporting Services Projects* extensions if they are already installed, and close all VS instances.
> - When installing SSDT on Windows 10 1803 and choosing to install SSIS, you may meet an unexpected reboot. You can launch the installer again and continue the installation after the reboot.



**Version Information**  
  
Release number: 15.8.1  
Build Number: 14.0.16179.0  
Release date: September 27, 2018  

For a complete list of changes, see the [changelog](changelog-for-sql-server-data-tools-ssdt.md).

SSDT for Visual Studio 2017 has the same [system requirements](https://docs.microsoft.com/visualstudio/productinfo/vs2017-system-requirements-vs) as Visual Studio.  

### Available Languages - SSDT for VS 2017

This release of **SSDT for VS 2017** can be installed in the following languages:  

[Chinese (Simplified)]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x804) | 
[Chinese (Traditional)]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x404) | 
[English (United States)]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x409) | 
[French]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x40c)  
[German]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x407) | 
[Italian]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x410) | 
[Japanese]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x411) | 
[Korean]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x412) | 
[Portuguese (Brazil)]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x416) | 
[Russian]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x419) | 
[Spanish]( https://go.microsoft.com/fwlink/?linkid=2024393&clcid=0x40a)  


## Offline install

To install SSDT when you're not connected to the internet follow the steps in this section. For more information, see [Create a network installation of Visual Studio 2017](https://docs.microsoft.com/visualstudio/install/create-a-network-installation-of-visual-studio).

First, complete the following steps while online:

1. [Download the SSDT standalone installer](#ssdt-for-vs-2017-standalone-installer).
2. [Download vs_sql.exe](https://aka.ms/vs/15/release/vs_sql.exe).
3. While still online, execute one of the following commands to download all the files required for installing offline. Using the `--layout` option is the key. Replace <filepath> with the actual path to save the files.

   a.	For a specific language, pass the locale: `vs_sql.exe --layout c:\<filepath> --lang en-us` (a single language is ~1GB)  
   b. For all languages, omit the `--lang` argument: `vs_sql.exe --layout c:\<filepath>` (all languages are ~3.9GB).

After completing the previous steps, the following can be done while offline:

1. Copy the VS2017 payload to the SSDT payload folder. Ensure all files from both are combined into a single layouts folder.
2. Run `vs_setup.exe --NoWeb` to install the VS2017 Shell and SQL Server Data Project.
3. Run `SSDT-Setup-ENU.exe /install` and select SSIS/SSRS/SSAS.

   - Or for an unattended installation, run `SSDT-Setup-ENU.exe /INSTALLALL[:vsinstances] /passive`  

For available options, run `SSDT-Setup-ENU.exe /help`

## Supported SQL versions
  
|Project Templates|SQL Platforms Supported|  
|-------------------|--------------------|  
Relational databases|  SQL Server 2005* - SQL Server 2017<br> (use SSDT 17.x or SSDT for Visual Studio 2017 to connect to [SQL Server on Linux](../linux/sql-server-linux-overview.md))<br /><br />Azure SQL Database<br /><br />Azure SQL Data Warehouse (supports queries only; database projects are not yet supported)<br /><br />  * SQL Server 2005 support is deprecated,<br /><br /> please move to an officially supported SQL version|
  |Analysis Services models<br /><br />Reporting Services reports | SQL Server 2008 – SQL Server 2017|
  |Integration Services packages| SQL Server 2012 – SQL Server 2017    |
  
## DacFx
SSDT for Visual Studio 2015, and SSDT for Visual Studio 2017 both use DacFx 17.4.1: [Download Data-Tier Application Framework (DacFx) 17.4.1](https://www.microsoft.com/download/details.aspx?id=56508).

## Previous versions

To download and install SSDT for Visual Studio 2015, or an older version of SSDT, see [Previous releases of SQL Server Data Tools (SSDT and SSDT-BI)](previous-releases-of-sql-server-data-tools-ssdt-and-ssdt-bi.md).



## Next steps  
After installing SSDT, work through these tutorials to learn how to create databases, packages, data models, and reports using SSDT:  

- [Project-Oriented Offline Database Development](project-oriented-offline-database-development.md)  
- [SSIS Tutorial: Create a Simple ETL Package](../integration-services/ssis-how-to-create-an-etl-package.md)  
- [Analysis Services tutorials](../analysis-services/analysis-services-tutorials-ssas.md)  
- [Create a Basic Table Report (SSRS Tutorial)](../reporting-services/create-a-basic-table-report-ssrs-tutorial.md)  

[!INCLUDE[get-help-options](../includes/paragraph-content/get-help-options.md)]


## See Also  
[SSDT MSDN Forum](https://social.msdn.microsoft.com/Forums/sqlserver/home?forum=ssdt)  
[SSDT Team Blog](http://blogs.msdn.com/b/ssdt/)  
[DACFx API Reference](https://msdn.microsoft.com/library/dn645454.aspx)  
[Download SQL Server Management Studio (SSMS)](../ssms/download-sql-server-management-studio-ssms.md)  

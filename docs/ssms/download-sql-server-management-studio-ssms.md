---
title: "Download SQL Server Management Studio (SSMS) | Microsoft Docs"
ms.custom: ""
ms.date: "09/25/2018"
ms.prod: sql
ms.prod_service: "sql-tools"
ms.reviewer: ""
ms.technology: ssms
ms.topic: conceptual
keywords: 
  - "install ssms, download ssms, latest ssms"
  - "SQL Server Management Studio"
  - "ssms.exe"
  - "sql man studio"
  - "sql management studio"
  - "sql management studio install"
  - "download sql management studio"
  - "ms sql management studio"
  - "install sql management studio"
  - "ssms download"
  - "sql server ssms"
  - "ssms express"
ms.assetid: adafeeef-4255-4924-8042-02f503d599ca
author: "stevestein"
ms.author: "sstein"
manager: craigg
---
# Download SQL Server Management Studio (SSMS)
[!INCLUDE[appliesto-ss-asdb-asdw-xxx-md](../includes/appliesto-ss-asdb-asdw-xxx-md.md)]
SSMS is an integrated environment for managing any SQL infrastructure, from SQL Server to Azure SQL Database. SSMS provides tools to configure, monitor, and administer instances of SQL. Use SSMS to deploy, monitor, and upgrade the data-tier components used by your applications, as well as build queries and scripts.

Use SQL Server Management Studio (SSMS) to query, design, and manage your databases and data warehouses, wherever they are - on your local computer, or in the cloud.

**SSMS is free!**

## SSMS 17.9 is the current General Availability (GA) version of SSMS

**[![download](../ssdt/media/download.png) Download SQL Server Management Studio 17.9](https://go.microsoft.com/fwlink/?linkid=2014306)**
<br>**[![download](../ssdt/media/download.png) Download SQL Server Management Studio 17.9 Upgrade Package (upgrades 17.x to 17.9)](https://go.microsoft.com/fwlink/?linkid=2014215)**

For additional details about SSMS 17.9, please see the [SSMS 17.9 changelog](sql-server-management-studio-changelog-ssms.md#ssms-179-latest-ga-release).

## SSMS 18.0 (preview)

**SSMS 18.0 Public Preview 4 is now available, and is the latest generation of *SQL Server Management Studio* that provides support for [!INCLUDE[sql-server-2019](..\includes\sssqlv15-md.md)]!**

**[![download](../ssdt/media/download.png) Download SQL Server Management Studio 18.0 (preview 4)](https://go.microsoft.com/fwlink/?linkid=2014662)**

Preview 4 is the first public preview of SSMS 18.0.

**Version Information**

- Release number: 18.0 (preview 4)<br>
- Build number: 15.0.18040.0<br>
- Release date: September 24, 2018

If you have comments or suggestions, or you want to report issues, the best way to reach out to the SSMS Team is at [UserVoice](https://aka.ms/sqlfeedback).

The SSMS 18.x installation does not upgrade or replace SSMS versions 17.x or earlier. SSMS 18.x installs side by side with previous versions so both versions are available for use.

If a computer contains side by side installations of SSMS, verify you start the correct version for your specific needs. The latest version is labeled *Microsoft SQL Server Management Studio 18*:
 

## Available Languages (SSMS 18.0 preview)

This release of SSMS can be installed in the following languages:

SQL Server Management Studio 18.0 (preview 4):<br>
[Chinese (Simplified)](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x804) | [Chinese (Traditional)](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x404) | [English (United States)](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x409) | [French](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x40c) | [German](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x407) | [Italian](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x410) | [Japanese](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x411) | [Korean](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x412) | [Portuguese (Brazil)](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x416) | [Russian](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x419) | [Spanish](https://go.microsoft.com/fwlink/?linkid=2014662&clcid=0x40a)

SQL Server Management Studio 18.0 Upgrade Package (upgrades to 18.0):<br>
No upgrade option is available at this time.

> [!NOTE]
> The SQL Server PowerShell module is a separate install through the PowerShell Gallery. For more information, see [Download SQL Server PowerShell Module](download-sql-server-ps-module.md).


## New in this Release (SSMS 18.0 preview)

SSMS 18.0 (preview) is the latest version of SQL Server Management Studio. The 18.x generation of SSMS provides support for almost all feature areas on SQL Server 2008 through SQL Server 2019 preview.

For details about what's new in this release, see [the SSMS changelog](sql-server-management-studio-changelog-ssms.md).


## Supported SQL offerings (SSMS 18.0 preview)

* This version of SSMS works with all [supported versions of SQL Server 2008 - [!INCLUDE[sql-server-2019](..\includes\sssqlv15-md.md)]](https://support.microsoft.com/lifecycle?C2=1044) and provides the greatest level of support for working with the latest cloud features in Azure SQL Database and Azure SQL Data Warehouse.
* Additionally, SSMS 18.x can be installed side by side with SSMS 17.x, SSMS 16.x, or SQL Server 2014 SSMS and earlier.
* SQL Server Integration Services (SSIS) - SSMS version 17.x or later does not support connecting to the legacy SQL Server Integration Services service. To connect to an earlier version of the legacy Integration Services, use the version of SSMS aligned with the version of SQL Server. For example, use SSMS 16.x to connect to the legacy SQL Server 2016 Integration Services service. SSMS 17.x and SSMS 16.x can be installed side-by-side on the same computer. Since the release of SQL Server 2012, the SSIS Catalog database, SSISDB, is the recommended way to store, manage, run, and monitor Integration Services packages. For details, see [SSIS Catalog](../integration-services/catalog/ssis-catalog.md).

## Supported Operating systems (SSMS 18.0 preview)

This release of SSMS supports the following 64-bit platforms when used with the latest available service pack:

- Windows 10 (64-bit) *
- Windows Server 2016 *
- Windows Server 2012 R2 (64-bit)
- Windows Server 2012 (64-bit)
- Windows Server 2008 R2 (64-bit)

\* Requires version 1607 (10.0.14939) or later

> [!NOTE]
> SSMS runs on Windows only. If you need a tool that runs on platforms other than Windows, take a look at Azure Data Studio. Azure Data Studio is a new cross-platform tool that runs on macOS, Linux, as well as Windows. For details, see [Azure Data Studio](../azure-data-studio/what-is.md).
  
## SSMS installation tips and issues (SSMS 18.0 preview)

### Minimize Installation Reboots

* Take the following actions to reduce the chances of SSMS setup requiring a reboot at the end of installation:
  * Make sure you are running an up-to-date version of the Visual C++ 2013 Redistributable Package. Version 12.0.40649.5 (or greater) is required. Only the x64 version is needed.
  * Verify the version of .NET Framework on the computer is 4.6.1 (or greater).
  * Close any other instances of Visual Studio that are open on the computer.
  * Make sure all the latest OS updates are installed on the computer.
  * The noted actions are typically required only once. There are few cases where a reboot is required during additional upgrades to the same major version of SSMS. For minor upgrades, all the prerequirements for SSMS are already installed on the computer.


## Release Notes (SSMS 18.0 preview)

The following are known issues in the current release:

> [!IMPORTANT]
> When using *Active Directory – Universal with MFA Support* authentication with the SQL query editor, users may experience their connection being closed and reopened with each query invocation. Side effects of such closure include global temporary tables being dropped unexpectedly and sometimes a new SPID being given to the connection. This closure will not occur if there is an open transaction on the connection. To work around this issue, users can set `persist security info=true` in the connection parameters.

SSMS

- Double-clicking on a .sql file launches SSMS, but does not open the actual script.
  - Workaround: drag and drop the .sql file onto the SSMS editor.

SSIS

- Package can’t be deployed or executed successfully when it targets SQL Server of old version and contains Script Task/Script component at the same time.
- SSMS can’t connect to remote Integration Services.


## Previous releases

[Previous SQL Server Management Studio Releases](../ssms/sql-server-management-studio-changelog-ssms.md#previous-ssms-releases)

## Feedback

![needhelp_person_icon](../ssms/media/needhelp_person_icon.png) [SQL Client Tools Forum](https://social.msdn.microsoft.com/Forums/en-US/home?forum=sqltools)

[!INCLUDE[get-help-options](../includes/paragraph-content/get-help-options.md)]

## See Also

- [Tutorial: SQL Server Management Studio](tutorials/tutorial-sql-server-management-studio.md)
- [SQL Server Management Studio documentation](sql-server-management-studio-ssms.md)
- [Additional updates and service packs](https://technet.microsoft.com/sqlserver/ff803383.aspx)
- [Download SQL Server Data Tools (SSDT)](../ssdt/download-sql-server-data-tools-ssdt.md)

[!INCLUDE[contribute-to-content](../includes/paragraph-content/contribute-to-content.md)]

If you have comments or suggestions, or you want to report issues, the best way to reach out to the SSMS Team is at [UserVoice](https://aka.ms/sqlfeedback).
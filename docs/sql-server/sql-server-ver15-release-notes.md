---
title: "SQL Server 2019 Release Notes | Microsoft Docs"
ms.custom: ""
ms.date: "09/25/2018"
ms.prod: "sql-server-2018"
ms.reviewer: ""
ms.technology: 
  - "server-general"
ms.topic: "article"
ms.assetid: 13942af8-5a40-4cef-80f5-918386767a47
author: "MikeRayMSFT"
ms.author: "mikeray"
manager: "craigg"
monikerRange: "= sql-server-ver15 || = sqlallproducts-allversions"
---
# SQL Server 2019 preview release notes

[!INCLUDE[tsql-appliesto-ssver15-xxxx-xxxx-xxx](../includes/tsql-appliesto-ssver15-xxxx-xxxx-xxx.md)]

This article describes limitations and known issues for the [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] Community Technology Preview (CTP) releases. For related information, see:
- [What's New in SQL Server 2019](../sql-server/what-s-new-in-sql-server-ver15.md)

> [!NOTE]
> Preview releases of [!INCLUDE[ssNoVersion](../includes/ssnoversion-md.md)] are made available for you to experience the features of the upcoming release. They are not supported or licensed for production use. The following scenarios are explicitly unsupported:
>
> - Side-by-side installation with other versions of [!INCLUDE[ssNoVersion](../includes/ssnoversion-md.md)]
> - Uninstallation
> - Upgrade from a previous edition of SQL Server

**Try [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)]!**
- [![Download from Evaluation Center](../includes/media/download2.png)](http://go.microsoft.com/fwlink/?LinkID=862101) [Download [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] to install on Windows](http://go.microsoft.com/fwlink/?LinkID=862101)
- Install on Linux for [Red Hat Enterprise Server](../linux/quickstart-install-connect-red-hat.md), [SUSE Linux Enterprise Server](../linux/quickstart-install-connect-suse.md), and [Ubuntu](../linux/quickstart-install-connect-ubuntu.md).
- [Run on SQL Server 2019 on Docker](../linux/quickstart-install-connect-docker.md).

## CTP 2.0 (September 2018)

[!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0 is the first public release of [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)].

[!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0 is available is only as Evaluation Edition. No other editions are available. Support for CTP 2.0 is described in license_Eval.rtf with your installation media.

Limited support may be found at one of the following locations:

- Forums
  - [SQL Server Feedback](http://aka.ms/sqlfeedback)
  - [Getting started with SQL Server](https://social.msdn.microsoft.com/Forums/sqlserver/en-US/home?forum=sqlgetstarted)
  - [Transact-SQL](https://social.msdn.microsoft.com/Forums/sqlserver/en-US/home?forum=transactsql)
  - [SQL Server Documentation](https://social.msdn.microsoft.com/Forums/sqlserver/en-US/home?forum=sqldocumentation)

- Or tweet [@SQLServer](http://twitter.com/SQLServer) with [#sqlhelp](https://twitter.com/search?q=%23sqlhelp)

### Documentation (CTP 2.0)

- **Issue and customer impact**: Documentation for SQL Server 2019 (15.x) is limited and content is included with the [!INCLUDE[ssSQL17](../includes/sssql17-md.md)] documentation set. Content in articles that is specific to SQL Server 2019 (15.x) is noted with **Applies To**.

- **Issue and customer impact**: [!INCLUDE[ssNoVersion](../includes/ssnoversion-md.md)] documentation can be filtered by version. Use the control at the top left of each documentation page to filter for your requirements. 

- **Issue and customer impact**: No offline content is available for SQL Server 2019 (15.x).

### Hardware and software requirements

- **Issue and customer impact**: Hardware and software requirements are still being reviewed and not final for the product release.

  - **Hardware**
    - [Windows - processor, memory, and operating system requirements](../sql-server/install/hardware-and-software-requirements-for-installing-sql-server.md#pmosr)
    - [Linux - system requirements](../linux/sql-server-linux-setup.md#system)
  - **Software**
    - Windows Server 2016 or later. For additional requirements, see [Requirements for Installing SQL Server](../sql-server/install/hardware-and-software-requirements-for-installing-sql-server.md)
    - For Linux, refer to [Linux - supported platforms](../linux/sql-server-linux-setup.md#supportedplatforms)

### SQL Graph

**Issue and customer impact**: Tools which have dependency on DacFx like import-export will not work for the new graph features - Edge Constraints or Merge DML. Scripting in [!INCLUDE[ssManStudioFull](../includes/ssmanstudiofull-md.md)] may not work.

**Workaround**: Writing [!INCLUDE[tsql](../includes/tsql-md.md)] scripts and running them against the server using [!INCLUDE[ssManStudioFull](../includes/ssmanstudiofull-md.md)] or SQLCMD will work. Exporting or Importing database objects that create Edge constraints, have the new merge DML syntax or create derived tables/views on graph objects will not work. Users will have to manually create such objects in their database using [!INCLUDE[tsql](../includes/tsql-md.md)] scripts. 

**Applies to**: [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0.

### UTF-8 collations

**Issue and customer impact**: UTF-8 enabled collations cannot be used with some other [!INCLUDE[ssNoVersion](../includes/ssnoversion-md.md)] features. UTF-8 is not supported when the following [!INCLUDE[ssNoVersion](../includes/ssnoversion-md.md)] features are in use:

- SQL Server Replication
- Linked Server
- In-memory OLTP
- External Table for Polybase

  Also note there is currently no UI support to choose UTF-8 enabled collations in Azure Data Studio or SSDT. The latest SSMS version supports choice of UTF-8 enabled collations in the UI.

**Workaround**: No workaround for [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0.

**Applies to**: [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0.

### Lightweight query profiling infrastructure

**Issue and customer impact**: Executing the command `ALTER DATABASE SCOPED CONFIGURATION SET LIGHTWEIGHT_QUERY_PROFILING = ON` returns a syntax error. Any scenarios that depend on executing this command will fail.

> [!NOTE]
> Currently, the lightweight query profiling infrastructure (LWP) cannot be controlled at the individual database level, and remains enabled for all databases by default. For more information on LWP, refer to [What's New in SQL Server 2019](../sql-server/what-s-new-in-sql-server-ver15.md).

**Workaround**: No workaround for [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0.

**Applies to**: [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0.

### Always Encrypted with secure enclaves

**Issue and customer impact**: Rich computations are pending several performance optimizations, include limited functionality (no indexing, etc), and are currently disabled by default.

**Workaround**: To enable rich computations, run `DBCC traceon(127,-1)`. For details, see  [Enable rich computations](../relational-databases/security/encryption/configure-always-encrypted-enclaves.md#configure-a-secure-enclave).

**Applies to**: [!INCLUDE[SQL Server 2019](../includes/sssqlv15-md.md)] CTP 2.0.

### SQL Server Integration Services (SSIS) Transfer Database Task

**Issue and customer impact**:  When a `Transfer Database Task` is configured to transfer a database in `Database Online` mode, it may fail with the following error:

>The Execute method on the task returned error code 0x80131500 (An error occurred while transferring data. See the inner exception for details.). The Execute method must succeed, and indicate the result using an "out" parameter.

**Workaround**: Execute `DBCC TRACEON (7416,-1)` on the server and try again.

### SQL Server Machine Learning Services installation failure

**Issue/Customer impact**: SQL Server Machine Learning Services installations fails on machines that have trust relationship issues with the primary domain. The following error will be seen in the logs in this case:
 
>  Error: 0 : System.SystemException:The trust relationship between this workstation and the primary domain failed at System.Security.Principal.NTAccount.TranslateToSids(IdentityReferenceCollection sourceAccounts, Boolean& someFailed) ...

Verify in the logs located at:

* `C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\R_SERVICES\library\RevoScaleR\rxLibs\x64\RegisterRExt.log`
* `C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\PYTHON_SERVICES\Lib\site-packages\revoscalepy\rxLibs\RegisterRExt.log`
**Workaround**: Resolve the domain trust issues and retry the installation.

**Applies to**: SQL Server 2019 CTP 2.0.

[!INCLUDE[get-help-options-msft-only](../includes/paragraph-content/get-help-options.md)]

![MS_Logo_X-Small](../sql-server/media/ms-logo-x-small.png)

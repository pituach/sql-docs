---
title: "Support Policies for OLE DB Driver for SQL Server | Microsoft Docs"
description: "Support policies for OLE DB Driver for SQL Server"
ms.date: "06/12/2018"
ms.prod: sql
ms.prod_service: "database-engine, sql-database, sql-data-warehouse, pdw"
ms.component: "oledb|applications"
ms.reviewer: ""
ms.suite: "sql"
ms.custom: ""
ms.technology: connectivity
ms.tgt_pltfrm: ""
ms.topic: "reference"
author: "pmasl"
ms.author: "Pedro.Lopes"
manager: craigg
---
# Support Policies for OLE DB Driver for SQL Server
[!INCLUDE[appliesto-ss-asdb-asdw-pdw-asdbmi-md](../../../includes/appliesto-ss-asdb-asdw-pdw-asdbmi-md.md)]

[!INCLUDE[Driver_OLEDB_Download](../../../includes/driver_oledb_download.md)]

  This article discusses how various data-access components can be used with OLE DB Driver for SQL Server.  

## Server Support  
 OLE DB Driver for SQL Server supports connections to [!INCLUDE[ssSQL11](../../../includes/sssql11-md.md)],  [!INCLUDE[ssSQL14](../../../includes/sssql14-md.md)],[!INCLUDE[ssSQL15](../../../includes/sssql15-md.md)],  [!INCLUDE[ssSQL17](../../../includes/sssql17-md.md)], and [!INCLUDE[ssSDSfull](../../../includes/sssdsfull-md.md)].

## Supported Operating System Versions  
 The following table lists which operating systems support OLE DB Driver for SQL Server.  

|Supported operating systems|  
|--------------------------------------|---------------------------------|   
|Microsoft Windows 8.1<br /><br />Microsoft Windows 10<br /><br /> Microsoft Windows Server 2012<br /><br />Microsoft Windows Server 2012 R2<br /><br />Microsoft Windows Server 2016|  

## ADO Support Policies  
 ADO applications can use the SQLOLEDB OLE DB provider that is included with Windows if they do not require any of the features of [!INCLUDE[ssVersion2005](../../../includes/ssversion2005-md.md)] or later.  

 ADO applications can use the OLE DB Driver for SQL Server, but if they do so they must specify `DataTypeCompatibility=80` in the connection strings. Only features from [!INCLUDE[ssVersion2005](../../../includes/ssversion2005-md.md)] are available when `DataTypeCompatibility=80` is present in the connection strings.  

## OLE DB Support Policies  
Applications can use the OLE DB provider (SQLOLEDB) included with the Windows operating system. 
However, that is in maintenance mode and no longer updated. 
You should use the OLE DB Driver for SQL Server (MSOLEDBSQL) instead.

## See Also  
 [Building Applications with OLE DB Driver for SQL Server](../../oledb/applications/building-applications-with-oledb-driver-for-sql-server.md)   

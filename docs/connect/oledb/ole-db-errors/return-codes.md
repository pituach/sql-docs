---
title: "Return Codes | Microsoft Docs"
description: "Return codes"
ms.custom: ""
ms.date: "06/14/2018"
ms.prod: sql
ms.prod_service: "database-engine, sql-database, sql-data-warehouse, pdw"
ms.component: "oledb|ole-db-errors"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: connectivity
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "OLE DB error handling, return codes"
  - "OLE DB Driver for SQL Server, errors"
  - "failed function [OLE DB]"
  - "successful function [OLE DB]"
  - "S_FALSE"
  - "IS_ERROR macro"
  - "DB_S_ERRORSOCCURRED return"
  - "return codes [OLE DB]"
  - "S_OK"
  - "FAILED macro"
  - "errors [OLE DB], return codes"
author: "pmasl"
ms.author: "Pedro.Lopes"
manager: craigg
---
# Return Codes
[!INCLUDE[appliesto-ss-asdb-asdw-pdw-asdbmi-md](../../../includes/appliesto-ss-asdb-asdw-pdw-asdbmi-md.md)]

[!INCLUDE[Driver_OLEDB_Download](../../../includes/driver_oledb_download.md)]

  At the most basic level, a member function either succeeds or fails. At a somewhat more precise level, a function can succeed, but its success may not be what the application developer intended.  
  
 For more information about OLE DB return codes, see [Return Codes (OLE DB)](http://go.microsoft.com/fwlink/?LinkId=101631).  
  
 When an OLE DB Driver for SQL Server member function returns S_OK, the function succeeded.  
  
 When an OLE DB Driver for SQL Server member function doesn't return S_OK, the OLE/COM HRESULT-unpacking FAILED and IS_ERROR macros can determine the overall success or failure of a function.  
  
 If FAILED or IS_ERROR returns TRUE, the OLE DB Driver for SQL Server consumer is assured that member function execution failed. When FAILED or IS_ERROR return FALSE and the HRESULT doesn't equal S_OK, the OLE DB Driver for SQL Server consumer is assured the function succeeded in some sense. The consumer can retrieve detailed information on this "success with information" return from the OLE DB Driver for SQL Server error interfaces. Also, in the case where a function clearly fails (the FAILED macro returns TRUE), extended error information is available from the OLE DB Driver for SQL Server error interfaces.  
  
 OLE DB Driver for SQL Server consumers commonly encounter the DB_S_ERRORSOCCURRED "success with information" HRESULT return. Typically, member functions that return DB_S_ERRORSOCCURRED define one or more parameters that deliver status values to the consumer. No error information may be available to the consumer other than that returned in status-value parameters, so consumers should implement application logic to retrieve status values when they're available.  
  
 The OLE DB Driver for SQL Server member functions don't return the success code S_FALSE. All OLE DB Driver for SQL Server member functions always return S_OK to indicate success.  
  
## See Also  
 [Errors](../../oledb/ole-db-errors/errors.md)  
  
  

---
title: "SQL Server Error Detail | Microsoft Docs"
description: "SQL Server error detail"
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
  - "OLE DB Driver for SQL Server, errors"
  - "errors [OLE DB], error details"
  - "IErrorRecords interface"
  - "IErrorInfo interface"
  - "OLE DB error handling, error details"
  - "ISQLServerErrorInfo interface"
author: "pmasl"
ms.author: "Pedro.Lopes"
manager: craigg
---
# SQL Server Error Detail
[!INCLUDE[appliesto-ss-asdb-asdw-pdw-asdbmi-md](../../../includes/appliesto-ss-asdb-asdw-pdw-asdbmi-md.md)]

[!INCLUDE[Driver_OLEDB_Download](../../../includes/driver_oledb_download.md)]

  The OLE DB Driver for SQL Server defines the provider-specific error interface [ISQLServerErrorInfo](http://msdn.microsoft.com/library/a8323b5c-686a-4235-a8d2-bda43617b3a1). The interface returns more detail about a [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] error and is valuable when command execution or rowset operations fail.  
  
 There are two ways to obtain access to **ISQLServerErrorInfo** interface.  
  
 The consumer may call **IErrorRecords::GetCustomerErrorObject** to obtain an **ISQLServerErrorInfo** pointer, as shown in the following code sample. (There is no need to obtain **ISQLErrorInfo.**) Both **ISQLErrorInfo** and **ISQLServerErrorInfo** are custom OLE DB error objects, with **ISQLServerErrorInfo** being the interface to use to obtain information of server errors, including such details as procedure name and line numbers.  
  
```  
// Get the SQL Server custom error object.  
if(FAILED(hr=pIErrorRecords->GetCustomErrorObject(  
   nRec, IID_ISQLServerErrorInfo,  
   (IUnknown**)&pISQLServerErrorErrorInfo)))  
```  
  
 Another way to get an **ISQLServerErrorInfo** pointer is to call the **QueryInterface** method on an already-obtained **ISQLErrorInfo** pointer. Note that because **ISQLServerErrorInfo** contains a superset of the information available from **ISQLErrorInfo**, it makes sense to go directly to **ISQLServerErrorInfo** through **GetCustomerErrorObject**.  
  
 The **ISQLServerErrorInfo** interface exposes one member function, [ISQLServerErrorInfo::GetErrorInfo](../../oledb/ole-db-interfaces/isqlservererrorinfo-geterrorinfo-ole-db.md). The function returns a pointer to an SSERRORINFO structure and a pointer to a string buffer. Both pointers reference memory the consumer must deallocate by using the **IMalloc::Free** method.  
  
 SSERRORINFO structure members are interpreted by the consumer as follows.  
  
|Member|Description|  
|------------|-----------------|  
|*pwszMessage*|[!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] error message. Identical to the string returned in **IErrorInfo::GetDescription**.|  
|*pwszServer*|Name of the instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] for the session.|  
|*pwszProcedure*|If appropriate, the name of the procedure in which the error originated. An empty string otherwise.|  
|*lNative*|[!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] native error number. Identical to the value returned in the *plNativeError* parameter of **ISQLErrorInfo::GetSQLInfo**.|  
|*bState*|State of a [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] error message.|  
|*bClass*|Severity of a [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] error message.|  
|*wLineNumber*|When applicable, the line number of a stored procedure on which the error occurred.|  
  
## See Also  
 [Errors](../../oledb/ole-db-errors/errors.md)   
 [RAISERROR &#40;Transact-SQL&#41;](../../../t-sql/language-elements/raiserror-transact-sql.md)  
  
  

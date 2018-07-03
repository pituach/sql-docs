---
title: "ISSCommandWithParameters::GetParameterProperties (OLE DB) | Microsoft Docs"
description: "ISSCommandWithParameters::GetParameterProperties (OLE DB)"
ms.custom: ""
ms.date: "06/14/2018"
ms.prod: sql
ms.prod_service: "database-engine, sql-database, sql-data-warehouse, pdw"
ms.component: "oledb|ole-db-interfaces"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: 
  - "database-engine"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ISSCommandWithParameters::GetParameterProperties (OLE DB)"
apitype: "COM"
helpviewer_keywords: 
  - "GetParameterProperties method"
author: "pmasl"
ms.author: "Pedro.Lopes"
manager: craigg
---
# ISSCommandWithParameters::GetParameterProperties (OLE DB)
[!INCLUDE[appliesto-ss-asdb-asdw-pdw-asdbmi-md](../../../includes/appliesto-ss-asdb-asdw-pdw-asdbmi-md.md)]

[!INCLUDE[Driver_OLEDB_Download](../../../includes/driver_oledb_download.md)]

  Returns an array of SSPARAMPROPS property set structures, one SSPARAMPROPS property set for each UDT or XML parameter.  
  
## Syntax  
  
```  
  
HRESULT GetParameterProperties(  
      DB_UPARAMS *pcParams,  
      SSPARAMPROPS **prgParamProperties);  
```  
  
## Arguments  
 *pcParams*[out][in]  
 A pointer to memory that contains the number of SSPARAMPROPS structures returned in *prgParamProperties*.  
  
 *prgParamProperties*[out]  
 A pointer to memory in which an array of SSPARAMPROPS structures is returned. The provider allocates memory for the structures and returns the address to this memory, the consumer releases this memory with **IMalloc::Free** when it no longer needs the structures. Before calling **IMalloc::Free** for *prgParamProperties*, the consumer must also call **VariantClear** for the *vValue* property of each DBPROP structure to prevent a memory leak in cases where the variant contains a reference type such as a BSTR. If *pcParams* is zero on output or an error other than DB_E_ERRORSOCCURRED occurs, the provider doesn't allocate any memory and makes sure *prgParamProperties* is a null pointer on output.  
  
## Return Code Values  
 The **GetParameterProperties** method returns the same error codes as the core OLE DB **ICommandProperties::GetProperties** method, except that DB_S_ERRORSOCCURRED and DB_E_ERRORSOCCURED can't be raised.  
  
## Remarks  
 **ISSCommandWithParameters::GetParameterProperties** method behaves consistently with respect to **GetParameterInfo**. If [ISSCommandWithParameters::SetParameterProperties](../../oledb/ole-db-interfaces/isscommandwithparameters-setparameterproperties-ole-db.md) or **SetParameterInfo** have not been called or have been called with cParams equal to zero, **GetParameterInfo** derives parameter information and returns it. If **ISSCommandWithParameters::SetParameterProperties** or **SetParameterInfo** have been called for at least one parameter, **ISSCommandWithParameters::GetParameterProperties** method returns properties only for those parameters for which **ISSCommandWithParameters::SetParameterProperties** has been called. If **ISSCommandWithParameters::SetParameterProperties** is called after **ISSCommandWithParameters::GetParameterProperties** or **GetParameterInfo**, subsequent calls to **ISSCommandWithParameters::GetParameterProperties** return the overridden values for those parameters for which **ISSCommandWithParameters::SetParameterProperties** method has been called.  
  
 The SSPARAMPROPS structure is defined as follows:  
  
 `struct SSPARAMPROPS {`  
  
 `DBORDINAL iOrdinal;`  
  
 `ULONG cPropertySets;`  
  
 `DBPROPSET *rgPropertySets;`  
  
 `};`  
  
|Member|Description|  
|------------|-----------------|  
|*iOrdinal*|The ordinal of the passed parameter.|  
|*cPropertySets*|The number of DBPROPSET structures in *rgPropertySets*.|  
|*rgPropertySets*|A pointer to memory in which to return an array of DBPROPSET structures.|  
  
## See Also  
 [ISSCommandWithParameters &#40;OLE DB&#41;](../../oledb/ole-db-interfaces/isscommandwithparameters-ole-db.md)  
  
  

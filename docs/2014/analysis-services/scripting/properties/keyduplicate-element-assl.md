---
title: "KeyDuplicate Element (ASSL) | Microsoft Docs"
ms.custom: ""
ms.date: "03/06/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: 
  - "analysis-services"
  - "docset-sql-devref"
ms.topic: "reference"
api_name: 
  - "KeyDuplicate Element"
api_location: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine"
topic_type: 
  - "apiref"
f1_keywords: 
  - "KeyDuplicate"
helpviewer_keywords: 
  - "KeyDuplicate element"
ms.assetid: d7000b8b-e81f-4401-8738-00c2e0f73a59
author: minewiskan
ms.author: owend
manager: craigg
---
# KeyDuplicate Element (ASSL)
  Determines how [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] handles a duplicate key error if it encounters one during processing.  
  
## Syntax  
  
```xml  
  
<ErrorConfiguration>  
   ...  
      <KeyDuplicate>...</KeyDuplicate>  
   ...  
</ErrorConfiguration>  
```  
  
## Element Characteristics  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Data type and length|String (enumeration)|  
|Default value|*IgnoreError*|  
|Cardinality|0-1: Optional element that can occur once and only once.|  
  
## Element Relationships  
  
|Relationship|Element|  
|------------------|-------------|  
|Parent element|[ErrorConfiguration](../objects/errorconfiguration-element-assl.md)|  
|Child elements|None|  
  
## Remarks  
 Duplicate key errors are generated only during dimension processing, when an attribute key is encountered more than once. Because attribute keys must be unique, [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] discards the duplicate records. Duplicate key errors typically indicate a flaw in the design of the dimension, specifically in the relationships between attributes.  
  
 The value of this element is limited to one of the strings in the following table.  
  
|Value|Description|  
|-----------|-----------------|  
|*IgnoreError*|Processing should ignore the error and continue.|  
|*ReportAndContinue*|Processing should report the error and continue.|  
|*ReportAndStop*|Processing should report the error and stop.|  
  
 The enumeration that corresponds to the allowed values for `KeyDuplicate` in the Analysis Management Objects (AMO) object model is <xref:Microsoft.AnalysisServices.ErrorOption>.  
  
## See Also  
 [Properties &#40;ASSL&#41;](properties-assl.md)  
  
  

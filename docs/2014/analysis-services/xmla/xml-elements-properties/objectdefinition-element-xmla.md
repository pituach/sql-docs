---
title: "ObjectDefinition Element (XMLA) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "analysis-services"
  - "docset-sql-devref"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ObjectDefinition Element"
api_location: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine"
topic_type: 
  - "apiref"
f1_keywords: 
  - "urn:schemas-microsoft-com:xml-analysis#ObjectDefinition"
  - "http://schemas.microsoft.com/analysisservices/2003/engine#ObjectDefinition"
  - "microsoft.xml.analysis.objectdefinition"
helpviewer_keywords: 
  - "ObjectDefinition element"
ms.assetid: 1911868c-a018-4308-8cf9-972a57f610a1
caps.latest.revision: 13
author: minewiskan
ms.author: owend
manager: craigg
---
# ObjectDefinition Element (XMLA)
  Contains one or more Analysis Services Scripting Language (ASSL) elements, used to create or alter objects on an instance of [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)].  
  
## Syntax  
  
```xml  
  
<Create> <!-- or Alter -->  
   ...  
   <ObjectDefinition>  
      <!-- One or more ASSL elements -->  
   </ObjectDefinition>  
   ...  
</Create>  
```  
  
## Element Characteristics  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Data type and length|None|  
|Default value|None|  
|Cardinality|0-1: Optional element that can occur once and only once.|  
  
## Element Relationships  
  
|Relationship|Element|  
|------------------|-------------|  
|Parent elements|[Alter](../xml-elements-commands/alter-element-xmla.md), [Create](../xml-elements-commands/create-element-xmla.md)|  
|Child elements|Required ASSL elements. One or more ASSL elements, used to define [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] objects. For more information about ASSL, see [Properties &#40;XMLA&#41;](xml-elements-properties.md).|  
  
## Remarks  
  
## Example  
 The following example creates an empty database named `Test Database` on an [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] instance.  
  
```  
  
      <Create xmlns="http://schemas.microsoft.com/analysisservices/2003/engine">  
   <ObjectDefinition>  
      <Database xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">  
         <Name>Test Database</Name>  
         <Description>A test database.</Description>  
      </Database>  
   </ObjectDefinition>  
</Create>  
```  
  
## See Also  
 [Properties &#40;XMLA&#41;](xml-elements-properties.md)  
  
  

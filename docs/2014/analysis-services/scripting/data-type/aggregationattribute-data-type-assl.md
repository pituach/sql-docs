---
title: "AggregationAttribute Data Type (ASSL) | Microsoft Docs"
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
  - "AggregationAttribute Data Type"
api_location: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine"
topic_type: 
  - "apiref"
f1_keywords: 
  - "AggregationAttribute"
helpviewer_keywords: 
  - "AggregationAttribute data type"
ms.assetid: 636827c7-938d-4b7d-9827-46da3bc60d9a
caps.latest.revision: 41
author: minewiskan
ms.author: owend
manager: craigg
---
# AggregationAttribute Data Type (ASSL)
  Defines a primitive data type that represents the association between an [Aggregation](../objects/aggregation-element-assl.md) element and an attribute.  
  
## Syntax  
  
```xml  
  
<AggregationAttribute>  
   <AttributeID>...</AttributeID>  
      <Annotations>...</Annotations>  
</AggregationAttribute>  
```  
  
## Data Type Characteristics  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Base data types|None|  
|Derived data types|None|  
  
## Data Type Relationships  
  
|Relationship|Element|  
|------------------|-------------|  
|Parent elements|None|  
|Child elements|[AttributeID](../properties/id-element-assl.md), [Annotations](../collections/annotations-element-assl.md)|  
|Derived elements|[Attribute](../objects/attribute-element-assl.md) ([Attributes](../collections/attributes-element-assl.md) collection of [AggregationDimension](dimension-data-type-assl.md))|  
  
## Remarks  
 The corresponding class in the Analysis Management Objects (AMO) object model is <xref:Microsoft.AnalysisServices.AggregationAttribute>.  
  
## See Also  
 [Aggregation Element &#40;ASSL&#41;](../objects/aggregation-element-assl.md)   
 [Analysis Services Scripting Language XML Data Types &#40;ASSL&#41;](analysis-services-scripting-language-xml-data-types-assl.md)  
  
  

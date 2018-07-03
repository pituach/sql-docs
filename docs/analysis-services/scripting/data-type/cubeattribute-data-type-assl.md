---
title: "CubeAttribute Data Type (ASSL) | Microsoft Docs"
ms.date: 05/03/2018
ms.prod: sql
ms.technology: analysis-services
ms.custom: assl
ms.topic: reference
ms.author: owend
ms.reviewer: owend
author: minewiskan
manager: kfile
---
# CubeAttribute Data Type (ASSL)
[!INCLUDE[ssas-appliesto-sqlas](../../../includes/ssas-appliesto-sqlas.md)]
  Defines a primitive data type that represents an attribute associated with a [Cube](../../../analysis-services/scripting/objects/cube-element-assl.md) element.  
  
## Syntax  
  
```xml  
  
<CubeAttribute>  
   <AttributeID>...</AttributeID>  
   <AggregationUsage>...</AggregationUsage>  
   <AttributeHierarchyOptimizedState>...</AttributeHierarchyOptimizedState>  
   <AttributeHierarchyEnabled>...</AttributeHierarchyEnabled>  
   <AttributeHierarchyVisible>...</AttributeHierarchyVisible>  
   <Annotations>...</Annotations>  
</CubeAttribute>  
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
|Child elements|[AggregationUsage](../../../analysis-services/scripting/properties/aggregationusage-element-assl.md), [Annotations](../../../analysis-services/scripting/collections/annotations-element-assl.md), [AttributeHierarchyEnabled](../../../analysis-services/scripting/properties/attributehierarchyenabled-element-assl.md), [AttributeHierarchyOptimizedState](../../../analysis-services/scripting/properties/attributehierarchyoptimizedstate-element-assl.md), [AttributeHierarchyVisible](../../../analysis-services/scripting/properties/attributehierarchyvisible-element-assl.md), [AttributeID](../../../analysis-services/scripting/properties/attributeid-element-assl.md)|  
|Derived elements|[Attribute](../../../analysis-services/scripting/objects/attribute-element-assl.md) ([Attributes](../../../analysis-services/scripting/collections/attributes-element-assl.md) collection of [CubeDimension](../../../analysis-services/scripting/data-type/cubedimension-data-type-assl.md))|  
  
## Remarks  
 The *AttributeHierarchyOptimizedState* element is not supported when running the service in DeploymentMode configuration property values of 1 or 2 (SharePoint or Tabular modes, used to run [!INCLUDE[ssGemini](../../../includes/ssgemini-md.md)] and tabular model databases).  
  
 An attribute cannot be added as a level of a hierarchy when the property, *AtttributeHierarchyEnabled*, is set to FALSE and the instance is operating under DeploymentMode 1 or 2 (SharePoint or Tabular server mode).  
  
 Attributes in the [CubeDimension](../../../analysis-services/scripting/data-type/cubedimension-data-type-assl.md) element that are not explicitly included in the [Attributes](../../../analysis-services/scripting/collections/attributes-element-assl.md) collection become part of the collection with default values assigned to them. After attributes are added to the collection, the attributes can be returned by the [Discover](../../../analysis-services/xmla/xml-elements-methods-discover.md) method.  
  
 The [AggregationUsage](../../../analysis-services/scripting/properties/aggregationusage-element-assl.md) element controls how [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] automatically designs aggregations for the attribute. The **AggregationUsage** element does not constrain any aggregations that are manually created for the cube.  
  
 The corresponding element in the Analysis Management Objects (AMO) object model is <xref:Microsoft.AnalysisServices.CubeAttribute>.  
  
## See Also  
 [Analysis Services Scripting Language XML Data Types &#40;ASSL&#41;](../../../analysis-services/scripting/data-type/analysis-services-scripting-language-xml-data-types-assl.md)  
  
  

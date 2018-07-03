---
title: "Object Element (XMLA) | Microsoft Docs"
ms.date: 05/08/2018
ms.prod: sql
ms.technology: analysis-services
ms.custom: xmla
ms.topic: reference
ms.author: owend
ms.reviewer: owend
author: minewiskan
manager: kfile
---
# Object Element (XMLA)
[!INCLUDE[ssas-appliesto-sqlas-aas](../../../includes/ssas-appliesto-sqlas-aas.md)]
  Contains an object reference used by the parent element.  
  
## Syntax  
  
```xml  
  
<Alter> <!-- or any of the parent elements in the Element relationships table -->  
...  
   <Object>  
      <!-- One or more object identifiers, depending on the parent element -->  
   </Object>  
...  
</Alter>  
```  
  
## Element characteristics  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Data type and length|None|  
|Default value|None|  
|Cardinality|See the table below.|  
  
|Ancestor or Parent|Cardinality|  
|------------------------|-----------------|  
|[Alter](../../../analysis-services/xmla/xml-elements-commands/create-element-xmla.md)|0-1: Optional element that can occur once and only once.|  
|All others|1-1: Required element that occurs once and only once.|  
  
## Element relationships  
  
|Relationship|Element|  
|------------------|-------------|  
|Parent elements|[Alter](../../../analysis-services/xmla/xml-elements-commands/alter-element-xmla.md), [Backup](../../../analysis-services/xmla/xml-elements-commands/backup-element-xmla.md), [ClearCache](../../../analysis-services/xmla/xml-elements-commands/clearcache-element-xmla.md), [Delete](../../../analysis-services/xmla/xml-elements-commands/delete-element-xmla.md), [DesignAggregations](../../../analysis-services/xmla/xml-elements-commands/designaggregations-element-xmla.md), [Lock](../../../analysis-services/xmla/xml-elements-commands/lock-element-xmla.md), [NotifyTableChange](../../../analysis-services/xmla/xml-elements-commands/notifytablechange-element-xmla.md), [Process](../../../analysis-services/xmla/xml-elements-commands/process-element-xmla.md), [Subscribe](../../../analysis-services/xmla/xml-elements-commands/subscribe-element-xmla.md), [Synchronize](../../../analysis-services/xmla/xml-elements-commands/synchronize-element-xmla.md)|  
|Child elements|Required Analysis Services Scripting Language (ASSL) elements. Specified by listing the ID elements of the object and its ancestors (excluding the **Server** object.) For example, the following **Object** element identifies a partition:<br /><br /> `<Object>`<br /><br /> `<DatabaseID>Adventure Works DW Multidimensional 2012</DatabaseID>`<br /><br /> `<CubeID>Adventure Works</CubeID>`<br /><br /> `<MeasureGroupID>Internet Sales</MeasureGroupID>`<br /><br /> `<PartitionID>Inernet_Sales_2001</PartitionID>`<br /><br /> `</Object>`|  
  
## Remarks  
 The order in which identifiers appear is not important.  
  
 For **Alter** elements, the instance of Analysis Services is used as the default object if the **Object** element is not specified.  
  
## See also
 [Properties &#40;XMLA&#41;](../../../analysis-services/xmla/xml-elements-properties/xml-elements-properties.md)  
  
  

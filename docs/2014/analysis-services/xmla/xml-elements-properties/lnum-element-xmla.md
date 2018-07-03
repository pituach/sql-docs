---
title: "LNum Element (XMLA) | Microsoft Docs"
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
  - "LNum Element"
api_location: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine"
topic_type: 
  - "apiref"
f1_keywords: 
  - "microsoft.xml.analysis.lnum"
  - "urn:schemas-microsoft-com:xml-analysis#LNum"
  - "http://schemas.microsoft.com/analysisservices/2003/engine#LNum"
helpviewer_keywords: 
  - "LNum element"
ms.assetid: 7b9cc143-0c5e-4a8c-a288-8921bfcfd103
caps.latest.revision: 13
author: minewiskan
ms.author: owend
manager: craigg
---
# LNum Element (XMLA)
  Contains information about level ordinal positions for the parent [HierarchyInfo](hierarchyinfo-element-xmla.md) or [Member](member-element-xmla.md) element.  
  
## Syntax  
  
```xml  
  
<HierarchyInfo> <!-- or Member -->  
   ...  
   <LNum>...</LNum>  
   ...  
</HierarchyInfo>  
```  
  
## Element Characteristics  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Data type and length|int|  
|Default value|None|  
|Cardinality|1-1: Required element that occurs once and only once.|  
  
## Element Relationships  
  
|Relationship|Element|  
|------------------|-------------|  
|Parent elements|[HierarchyInfo](hierarchyinfo-element-xmla.md), [Member](member-element-xmla.md)|  
|Child elements|None|  
  
## Remarks  
 For `HierarchyInfo` elements, the `LNum` element contains the name of the property that provides the level ordinal positions of the hierarchy. The value is equivalent to the LEVEL_NUMBER property defined for axis rowsets in the OLE DB for OLAP specification.  
  
 For `Member` elements, the `LNum` element contains the zero-based ordinal position, from the root level of the hierarchy, of the member represented by the parent [Member](member-element-xmla.md) element. A value of zero represents the root level of the hierarchy.  
  
## See Also  
 [Properties &#40;XMLA&#41;](xml-elements-properties.md)  
  
  

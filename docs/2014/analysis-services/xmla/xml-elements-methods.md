---
title: "Methods (XMLA) | Microsoft Docs"
ms.custom: ""
ms.date: "03/06/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "analysis-services"
  - "docset-sql-devref"
ms.tgt_pltfrm: ""
ms.topic: "reference"
topic_type: 
  - "apiref"
  - "apinav"
f1_keywords: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine#"
helpviewer_keywords: 
  - "methods [XML for Analysis]"
  - "XML for Analysis, methods"
  - "XMLA, methods"
ms.assetid: c6768dd4-ca06-4a85-93b7-5fd5700886ad
caps.latest.revision: 30
author: minewiskan
ms.author: owend
manager: craigg
---
# Methods (XMLA)
  The XML for Analysis (XMLA) protocol uses two methods, `Discover` and `Execute`, to offer a standard way for applications to access information on an instance of [!INCLUDE[msCoName](../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] [!INCLUDE[ssASnoversion](../../includes/ssasnoversion-md.md)]. Because these methods are invoked by using Simple Object Access Protocol (SOAP), they accept input and deliver output in XML. [!INCLUDE[ssASnoversion](../../includes/ssasnoversion-md.md)] implements both methods, in compliance with the XML for Analysis 1.1 specification.  
  
## In This Section  
 The following topics describe the XMLA methods implemented by [!INCLUDE[ssASnoversion](../../includes/ssasnoversion-md.md)].  
  
|Method|Description|  
|------------|-----------------|  
|[Discover Method &#40;XMLA&#41;](xml-elements-methods-discover.md)|Retrieves information, such as the list of available databases or details about a specific object, from an instance of [!INCLUDE[ssASnoversion](../../includes/ssasnoversion-md.md)]. The data retrieved with the `Discover` method depends on the values of the parameters passed to it.|  
|[Execute Method &#40;XMLA&#41;](xml-elements-methods-execute.md)|Sends XMLA commands to an instance of [!INCLUDE[ssASnoversion](../../includes/ssasnoversion-md.md)]. This includes requests involving data transfer, such as retrieving or updating data on the server.|  
  
## See Also  
 [XML Elements &#40;XMLA&#41;](../dev-guide/xml-elements-xmla.md)   
 [XML Data Types &#40;XMLA&#41;](xml-data-types/xml-data-types-xmla.md)   
 [XML Elements &#40;XMLA&#41;](../dev-guide/xml-elements-xmla.md)  
  
  

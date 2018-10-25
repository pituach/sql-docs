---
title: "EndSession Element (XMLA) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: 
  - "analysis-services"
  - "docset-sql-devref"
ms.topic: "reference"
api_name: 
  - "EndSession Element"
api_location: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine"
topic_type: 
  - "apiref"
f1_keywords: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine#EndSession"
  - "urn:schemas-microsoft-com:xml-analysis#EndSession"
  - "microsoft.xml.analysis.endsession"
helpviewer_keywords: 
  - "EndSession element"
ms.assetid: e64f1da4-5c83-40a2-b15e-837f5451bafa
author: minewiskan
ms.author: owend
manager: craigg
---
# EndSession Element (XMLA)
  Uses the SOAP header in a SOAP request message to end an existing session on an instance of [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)].  
  
 **Namespace** urn:schemas-microsoft-com:xml-analysis  
  
## Syntax  
  
```xml  
  
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">  
   <soap:Header>  
      ...  
      <EndSession  
         xmlns="urn:schemas-microsoft-com:xml-analysis"  
         SessionId="string" />  
      ...  
   </soap:Header>  
   <soap:Body>  
      ...  
   </soap:Body>  
</soap:Envelope>  
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
|Parent elements|None|  
|Child elements|None|  
  
## Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|SessionId|Required `String` attribute that identifies the session to be ended. [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] uses a globally unique identifier (GUID) to identify a session.|  
  
## Remarks  
 The `EndSession` header element is part of the SOAP request sent to an existing, explicitly started session on an [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] instance. If the `EndSession` header element is sent, but contains a session identifier that is no longer valid, a SOAP fault is returned that indicates that the session cannot be found.  
  
## See Also  
 [BeginSession Element &#40;XMLA&#41;](session-element-xmla.md)   
 [Session Element &#40;XMLA&#41;](session-element-xmla.md)   
 [Managing Connections and Sessions &#40;XMLA&#41;](../../multidimensional-models-scripting-language-assl-xmla/managing-connections-and-sessions-xmla.md)   
 [Headers &#40;XMLA&#41;](xml-elements-headers.md)  
  
  

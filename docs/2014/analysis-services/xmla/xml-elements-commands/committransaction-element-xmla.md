---
title: "CommitTransaction Element (XMLA) | Microsoft Docs"
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
  - "CommitTransaction Element"
api_location: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine"
topic_type: 
  - "apiref"
f1_keywords: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine#CommitTransaction"
  - "urn:schemas-microsoft-com:xml-analysis#CommitTransaction"
  - "microsoft.xml.analysis.committransaction"
helpviewer_keywords: 
  - "CommitTransaction command"
ms.assetid: 1cd814dc-a0be-4305-b44d-faf15e843f7d
caps.latest.revision: 14
author: minewiskan
ms.author: owend
manager: craigg
---
# CommitTransaction Element (XMLA)
  Commits a transaction on the current session with a [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] instance.  
  
## Syntax  
  
```xml  
  
<Command>  
   <CommitTransaction />  
</Command>  
```  
  
## Element Characteristics  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Data type and length|None|  
|Default value|None|  
|Cardinality|0-n: Optional element that can occur more than once.|  
  
## Element Relationships  
  
|Relationship|Element|  
|------------------|-------------|  
|Parent elements|[Command](../xml-elements-properties/command-element-xmla.md)|  
|Child elements|None|  
  
## Remarks  
 The `CommitTransaction` command commits an active transaction, explicitly defined using the `BeginTransaction` element, on the current session. If an active transaction does not already exist, an error occurs. If an active transaction already exists, the [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] instance decrements the reference count of transactions for the current session. If the reference count of explicitly defined active transactions reaches zero, the [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] instance commits the transaction.  
  
## See Also  
 [BeginTransaction Element &#40;XMLA&#41;](begintransaction-element-xmla.md)   
 [Cancel Element &#40;XMLA&#41;](cancel-element-xmla.md)   
 [RollbackTransaction Element &#40;XMLA&#41;](rollbacktransaction-element-xmla.md)   
 [Commands &#40;XMLA&#41;](xml-elements-commands.md)  
  
  

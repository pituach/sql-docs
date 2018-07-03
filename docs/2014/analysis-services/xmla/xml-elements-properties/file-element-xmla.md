---
title: "File Element (XMLA) | Microsoft Docs"
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
  - "File Element"
api_location: 
  - "http://schemas.microsoft.com/analysisservices/2003/engine"
topic_type: 
  - "apiref"
f1_keywords: 
  - "microsoft.xml.analysis.file"
  - "http://schemas.microsoft.com/analysisservices/2003/engine#File"
  - "urn:schemas-microsoft-com:xml-analysis#File"
helpviewer_keywords: 
  - "File element"
ms.assetid: 3dfd0e9b-746b-4ce5-8a95-610d2e573739
caps.latest.revision: 12
author: minewiskan
ms.author: owend
manager: craigg
---
# File Element (XMLA)
  Identifies a file to be used by the parent [Backup](../xml-elements-commands/backup-element-xmla.md) or [Restore](../xml-elements-commands/restore-element-xmla.md) command, or by the parent [Location](location-element-xmla.md) element.  
  
## Syntax  
  
```xml  
  
<Backup> <!-- or one of the elements listed below in the Element Relationships table -->  
   ...  
   <File>...</File>  
   ...  
</Backup>  
```  
  
## Element Characteristics  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Data type and length|String|  
|Default value|None|  
|Cardinality|1-1: Required element that occurs once and only once.|  
  
## Element Relationships  
  
|Relationship|Element|  
|------------------|-------------|  
|Parent elements|[Backup](../xml-elements-commands/backup-element-xmla.md), [Location](location-element-xmla.md), [Restore](../xml-elements-commands/restore-element-xmla.md)|  
|Child elements|None|  
  
## Remarks  
 The `File` element contains a UNC file name, and the parent element determines the use of the `File` element.  
  
 For `Backup` commands, the `File` element determines the name of the backup file created by the `Backup` command. If a path is not specified as part of the file name, the path specified in the `BackupDir` configuration property for the instance of [!INCLUDE[msCoName](../../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] is used. If the specified file already exists, an error occurs unless the `AllowOverwrite` element of the parent `Backup` command is set to `True`.  
  
 For `Restore` commands, the `File` element determines the name of the backup file to be restored by the `Restore` command.  
  
 For `Location` elements, the `File` element describes a remote backup file for an [!INCLUDE[ssASnoversion](../../../includes/ssasnoversion-md.md)] instance that contains remote partitions. For more information about backing up and restoring remote partitions, see [Backing Up, Restoring, and Synchronizing Databases &#40;XMLA&#41;](../../multidimensional-models-scripting-language-assl-xmla/backing-up-restoring-and-synchronizing-databases-xmla.md).  
  
## See Also  
 [AllowOverwrite Element &#40;XMLA&#41;](allowoverwrite-element-xmla.md)   
 [Properties &#40;XMLA&#41;](xml-elements-properties.md)  
  
  

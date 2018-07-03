---
title: "DISCOVER_COMMANDS Rowset | Microsoft Docs"
ms.date: 05/03/2018
ms.prod: sql
ms.technology: analysis-services
ms.custom: schema-rowsets
ms.topic: reference
ms.author: owend
ms.reviewer: owend
author: minewiskan
manager: kfile
---
# DISCOVER_COMMANDS Rowset
[!INCLUDE[ssas-appliesto-sqlas](../../../includes/ssas-appliesto-sqlas.md)]
  Provides resource usage and activity information about the currently executing or last executed commands in the opened connections on the server.  
  
 **Applies to:** tabular models, multidimensional models  
  
## Rowset Columns  
 The **DISCOVER_COMMANDS** rowset contains the following columns.  
  
|Column name|Type indicator|Restriction|Description|  
|-----------------|--------------------|-----------------|-----------------|  
|**SESSION_SPID**|**DBTYPE_I4**|Yes|The session ID.|  
|**SESSION_COMMAND_COUNT**|**DBTYPE_I4**||The number of commands executed since the start of the session.|  
|**COMMAND_START_TIME**|**DBTYPE_DBTIMESTAMP**||The date and time the last command started, expressed as UTC time on the server.|  
|**COMMAND_ELAPSED_TIME_MS**|**DBTYPE_I8**||The elapsed time, in milliseconds, since the start of the command.|  
|**COMMAND_CPU_TIME_MS**|**DBTYPE_I8**||The CPU time, in milliseconds,  consumed by the command since the start of the command execution.|  
|**COMMAND_READS**|**DBTYPE_I8**||The accumulated number of disk reads since the start of the command.|  
|**COMMAND_READ_KB**|**DBTYPE_I8**||The ccumulated value of data read from disk, in kilobytes, since the start of the command.|  
|**COMMAND_WRITES**|**DBTYPE_I8**||The accumulated number of disk writes since the start of the command.|  
|**COMMAND_WRITE_KB**|**DBTYPE_I8**||The accumulated value of data written to disk, in kilobytes, since the start of the command.|  
|**COMMAND_TEXT**|**DBTYPE_WSTR**||The command text.|  
|**COMMAND_END_TIME**|**DBTYPE_DBTIMESTAMP**||The server UTC date and time when the command finishes its execution.|  
  
 This schema rowset is not sorted.  
  
## Using ADOMD.NET to return the rowset  
 When using ADOMD.NET and the schema rowset to retrieve metadata, you can use either the GUID or string to reference a schema rowset object in the GetSchemaDataSet method. For more information, see [Working with Schema Rowsets in ADOMD.NET](../../../analysis-services/multidimensional-models-adomd-net-client/retrieving-metadata-working-with-schema-rowsets.md).  
  
 The following table provides the GUID and string values that identify this rowset.  
  
|Argument|Value|  
|--------------|-----------|  
|GUID|a07ccd34-8148-11d0-87bb-00c04fc33942|  
|ADOMDNAME|Commands|  
  
## See Also  
 [XML for Analysis Schema Rowsets](../../../analysis-services/schema-rowsets/xml/xml-for-analysis-schema-rowsets.md)  
  
  

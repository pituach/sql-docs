---
title: "DISCOVER_DB_CONNECTIONS Rowset | Microsoft Docs"
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
# DISCOVER_DB_CONNECTIONS Rowset
[!INCLUDE[ssas-appliesto-sqlas](../../../includes/ssas-appliesto-sqlas.md)]
  Provides resource usage and activity information about the currently opened connections from the server to a database.  
  
## Rowset Columns  
 The **DISCOVER_DB_CONNECTIONS** rowset contains the following columns.  
  
|Column name|Type indicator|Length|Description|  
|-----------------|--------------------|------------|-----------------|  
|**CONNECTION_CATALOG_NAME**|**DBTYPE_WSTR**||The database name of the currently connected database.|  
|**CONNECTION_ID**|**DBTYPE_I4**||A unique number that identifies the connection.|  
|**CONNECTION_IDLE_TIME_MS**|**DBTYPE_I8**||The idle time, in milliseconds, since the start of the connection.|  
|**CONNECTION_IN_USE**|**DBTYPE_I4**||indicates whether the connection is active (1) or idle (0).|  
|**CONNECTION_LAST_COMMAND_END_TIME**|**DBTYPE_DBTIMESTAMP**||The server UTC date and time when the last command finished its execution.|  
|**CONNECTION_LAST_COMMAND_START_TIME**|**DBTYPE_DBTIMESTAMP**||The server UTC date and time when he last command initiated its execution.|  
|**CONNECTION_SERVER_NAME**|**DBTYPE_WSTR**||The name of the currently connected server.|  
|**CONNECTION_SPID**|**DBTYPE_I4**||The session ID.|  
|**CONNECTION_START_TIME**|**DBTYPE_DBTIMESTAMP**||The server UTC date and time when the connection was initiated.|  
|**CONNECTION_USAGE_TIME_MS**|**DBTYPE_I8**||The connection active time, in milliseconds, since the start of the connection.|  
  
 This schema rowset is not sorted.  
  
> [!IMPORTANT]  
>  The **DISCOVER_DB_CONNECTIONS** rowset will only display information when the service is connected to the relational data sources.  
  
## Restriction Columns  
 The **DISCOVER_DB_CONNECTIONS** rowset can be restricted on the columns listed in the following table.  
  
|Column name|Type indicator|Restriction State|  
|-----------------|--------------------|-----------------------|  
|CONNECTION_ID|DBTYPE_I4|Optional.|  
|CONNECTION_IN_USE|DBTYPE_I4|Optional.|  
|CONNECTION_SERVER_NAME|DBTYPE_WSTR|Optional.|  
|CONNECTION_CATALOG_NAME|DBTYPE_WSTR|Required.|  
|CONNECTION_SPID|DBTYPE_I4|Optional.|  
  
## See Also  
 [XML for Analysis Schema Rowsets](../../../analysis-services/schema-rowsets/xml/xml-for-analysis-schema-rowsets.md)  
  
  

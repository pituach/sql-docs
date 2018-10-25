---
title: "MSSQLSERVER_9532 | Microsoft Docs"
ms.custom: ""
ms.date: "03/06/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: supportability
ms.topic: conceptual
helpviewer_keywords: 
  - "9532 (Database Engine error)"
ms.assetid: ab95cce8-4f97-4aea-a746-a73eea7c9aab
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# MSSQLSERVER_9532
    
## Details  
  
|||  
|-|-|  
|Product Name|SQL Server|  
|Event ID|9532|  
|Event Source|MSSQLSERVER|  
|Component|SQLEngine|  
|Symbolic Name|XMLERR_COLUMNSET_CANNOT_CONVERT_FROM_TO|  
|Message Text|In the query/DML operation involving  column set '%.*ls', conversion failed when converting from the data type '%ls' to the data type '%ls' for the column '%.\*ls'.|  
  
## Explanation  
 A column set is an untyped XML representation that combines some of the columns of a table into a structured output. When you are inserting or updating sparse column values through the XML column set, the values that are inserted into the underlying sparse columns are implicitly converted from the `xml` data type. A value was provided that cannot be converted to the data type of the column.  
  
## User Action  
 Because the value provided could not be implicitly converted, it might be an invalid entry. Correct the error and retry. If the value is correct, modify the statement to use the individual columns instead of the column set. This will allow you to explicitly cast the value into the correct data type.  
  
  

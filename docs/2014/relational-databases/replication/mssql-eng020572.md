---
title: "MSSQL_ENG020572 | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "replication"
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "MSSQL_ENG020572 error"
ms.assetid: 636566db-ffcf-4109-8c11-15b8c7cb9cd9
caps.latest.revision: 10
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# MSSQL_ENG020572
    
## Message Details  
  
|||  
|-|-|  
|Product Name|SQL Server|  
|Event ID|20572|  
|Event Source|MSSQLSERVER|  
|Component|[!INCLUDE[ssDEnoversion](../../includes/ssdenoversion-md.md)]|  
|Symbolic Name||  
|Message Text|Subscriber '%s' subscription to article '%s' in publication '%s' has been reinitialized after a validation failure.|  
  
## Explanation  
 The data at the Subscriber was validated against the data at the Publisher, and the data did not match; therefore validation failed. When you specified that validation should be performed, you selected the option that a subscription should be reinitialized if validation failed. Reinitializing a subscription involves applying a new snapshot at the Subscriber. For more information about validation, see [Validate Replicated Data](validate-replicated-data.md).  
  
## User Action  
 Data at the Publisher and Subscriber will match after the new snapshot is applied at the Subscriber.  
  
## See Also  
 [Errors and Events Reference &#40;Replication&#41;](errors-and-events-reference-replication.md)  
  
  

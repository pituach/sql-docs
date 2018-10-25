---
title: "srv_got_attention (Extended Stored Procedure API) | Microsoft Docs"
ms.custom: ""
ms.date: "03/06/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: 
  - "database-engine"
  - "docset-sql-devref"
ms.topic: "reference"
api_name: 
  - "srv_got_attention"
api_location: 
  - "opends60.dll"
topic_type: 
  - "apiref"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "srv_got_attention"
ms.assetid: 805e68e1-d17f-41bd-8b9f-a27283bb6fbe
author: rothja
ms.author: jroth
manager: craigg
---
# srv_got_attention (Extended Stored Procedure API)
    
> [!IMPORTANT]  
>  [!INCLUDE[ssNoteDepFutureDontUse](../../includes/ssnotedepfuturedontuse-md.md)] Use CLR integration instead.  
  
 Checks whether the current connection or task needs to be aborted and returns TRUE if the connection is killed or the batch is aborted  
  
## Syntax  
  
```  
  
BOOL srv_got_attention  
(SRV_PROC *  
srvproc  
);  
  
```  
  
#### Parameters  
 *srvproc*  
 Pointer identifying a database connection.  
  
## Return Value  
 TRUE if the connection is killed or the batch is aborted. FALSE if the connection or batch is active.  
  
## Remarks  
 A long-running extended stored procedure should check the server attention by calling **srv_got_attention** periodically so that the procedure may terminate itself when the connection is killed or the batch is aborted.  
  
> [!IMPORTANT]  
>  You should thoroughly review the source code of extended stored procedures, and you should test the compiled DLLs before you install them on a production server. For information about security review and testing, see this [Microsoft Web site](http://go.microsoft.com/fwlink/?LinkID=54761&amp;clcid=0x409http://msdn.microsoft.com/security/).  
  
  

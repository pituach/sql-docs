---
title: "How Extended Stored Procedures Work | Microsoft Docs"
ms.custom: ""
ms.date: "03/09/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: 
  - "database-engine"
  - "docset-sql-devref"
ms.topic: "reference"
helpviewer_keywords: 
  - "extended stored procedures [SQL Server], about extended stored procedures"
ms.assetid: 6e946d8c-3268-4b59-8a1c-1637909cd701
author: rothja
ms.author: jroth
manager: craigg
---
# How Extended Stored Procedures Work
    
> [!IMPORTANT]  
>  [!INCLUDE[ssNoteDepFutureDontUse](../../includes/ssnotedepfuturedontuse-md.md)] Use CLR Integration instead.  
  
 The process by which an extended stored procedure works is:  
  
1.  When a client executes an extended stored procedure, the request is transmitted in tabular data stream (TDS) or Simple Object Access Protocol (SOAP) format from the client application to [!INCLUDE[msCoName](../../includes/msconame-md.md)] [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)].  
  
2.  [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] searches for the DLL associated with the extended stored procedure, and loads the DLL if it is not already loaded.  
  
3.  [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] calls the requested extended stored procedure (implemented as a function inside the DLL).  
  
4.  The extended stored procedure passes result sets and return parameters back to the server by through the Extended Stored Procedure API.  
  
## See Also  
 [Database Engine Extended Stored Procedure Programming](../database-engine-extended-stored-procedure-programming.md)  
  
  

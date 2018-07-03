---
title: "MSSQLSERVER_125 | Microsoft Docs"
ms.custom: ""
ms.date: "04/04/2017"
ms.prod: sql
ms.reviewer: ""
ms.suite: "sql"
ms.technology: supportability
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords: 
  - "125"
helpviewer_keywords: 
  - "125 (Database Engine error)"
ms.assetid: 0f58338d-2ea0-48b8-8a20-c438b0940433
caps.latest.revision: 11
author: MashaMSFT
ms.author: mathoma
manager: craigg
---
# MSSQLSERVER_125
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md](../../includes/appliesto-ss-xxxx-xxxx-xxx-md.md)]
  
## Details  
  
|||  
|-|-|  
|Product Name|SQL Server|  
|Event ID|125|  
|Event Source|MSSQLSERVER|  
|Component|SQLEngine|  
|Symbolic Name||  
|Message Text|Case expressions may only be nested to level %d.|  
  
## Explanation  
[!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] allows for only 10 levels of nesting in CASE expressions.  
  
## User Action  
Reduce the level of CASE statements to 10 or less.  
  
## See Also  
[CASE &#40;Transact-SQL&#41;](~/t-sql/language-elements/case-transact-sql.md)  
  

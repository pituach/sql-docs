---
title: "Unexpected System Failures | Microsoft Docs"
ms.custom: ""
ms.date: "03/14/2017"
ms.prod: sql
ms.prod_service: "database-engine"
ms.reviewer: ""
ms.technology: 
  - "database-engine"
ms.topic: conceptual
helpviewer_keywords: 
  - "Best Practices [Database Engine]"
ms.assetid: 1679bf9e-a2ef-4f90-8907-a002f7341a7d
author: MikeRayMSFT
ms.author: mikeray
manager: craigg
---
# Unexpected System Failures
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md](../../includes/appliesto-ss-xxxx-xxxx-xxx-md.md)]
  This rule checks for SYSTEM Event 6008 in the computer event log. This event indicates an unexpected system shutdown. The system might be unstable and might not provide the stability and integrity that is required to host an instance of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)].  
  
## Best Practices Recommendations  
 Immediately address the cause of the unexpected server restarts, or move the instance of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] to another computer.  
  
  

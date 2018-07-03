---
title: "Winsock Proxy configuration not supported | Microsoft Docs"
ms.custom: ""
ms.date: "03/06/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "database-engine"
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "Winsock proxy configuration [SQL Server]"
ms.assetid: abf71f7b-8bd7-49d2-92f7-9ddf72924d8c
caps.latest.revision: 20
author: mashamsft
ms.author: mathoma
manager: craigg
---
# Winsock Proxy configuration not supported
  The Winsock proxy cannot be configured by using [!INCLUDE[msCoName](../../includes/msconame-md.md)][!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] tools.  
  
## Component  
 [!INCLUDE[ssDE](../../includes/ssde-md.md)]  
  
## Description  
 [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] tools cannot configure Windows components.  
  
## Corrective Action  
 Use Microsoft Internet Security and Acceleration (ISA) Server to publish a computer. For information about how to configure the Winsock proxy, see your proxy server documentation.  
  
## See Also  
 [Database Engine Upgrade Issues](../../../2014/sql-server/install/database-engine-upgrade-issues.md)   
 [SQL Server 2014 Upgrade Advisor &#91;new&#93;](/sql/2014/sql-server/install/sql-server-2014-upgrade-advisor)  
  
  

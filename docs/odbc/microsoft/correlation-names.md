---
title: "Correlation Names | Microsoft Docs"
ms.custom: ""
ms.date: "01/19/2017"
ms.prod: sql
ms.prod_service: connectivity
ms.reviewer: ""
ms.suite: "sql"
ms.technology: connectivity
ms.tgt_pltfrm: ""
ms.topic: conceptual
helpviewer_keywords: 
  - "correlation names [ODBC]"
  - "SQL grammar [ODBC], correlation names"
ms.assetid: 76c36c6f-f8e1-4ece-a77b-611dde3bdd8a
caps.latest.revision: 5
author: MightyPen
ms.author: genemi
manager: craigg
---
# Correlation Names
Correlation names are fully supported, including within the table list. For example, in the following string, E1 is the correlation name for the table named Emp:  
  
```  
SELECT * FROM Emp E1   
WHERE E1.LastName = 'Smith'  
```

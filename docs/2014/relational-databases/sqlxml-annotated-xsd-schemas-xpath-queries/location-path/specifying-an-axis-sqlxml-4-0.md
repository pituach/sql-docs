---
title: "Specifying an Axis (SQLXML 4.0) | Microsoft Docs"
ms.custom: ""
ms.date: "03/06/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "database-engine"
  - "docset-sql-devref"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "XPath queries [SQLXML], axes"
  - "XPath queries [SQLXML], location paths"
  - "self axis"
  - "attribute axis [SQLXML]"
  - "axis [SQLXML]"
  - "child axis"
  - "parent axis"
  - "location path for XPath query"
  - "axes [SQLXML]"
ms.assetid: 65631795-3389-40cf-90ea-85e9438956c5
caps.latest.revision: 21
author: douglaslMS
ms.author: douglasl
manager: craigg
---
# Specifying an Axis (SQLXML 4.0)
    
-   The axis specifies the tree relationship between the nodes selected by the location step and the context node. The following axes are supported:  `child`  
  
     Contains the child of the context node.  
  
     The following XPath expression (location path) selects from the current context node all the **\<Customer>** children:  
  
    ```  
    child::Customer  
    ```  
  
     In the following XPath query, `child` is the axis. `Customer` is the node test.  
  
-   `parent`  
  
     Contains the parent of the context node.  
  
     The following XPath expression selects all the **\<Customer>** parents of the **\<Order>** children:  
  
    ```  
    child::Customer/child::Order[parent::Customer/@customerID="ALFKI"]  
    ```  
  
     This is the same as specifying `child::Customer`. In this XPath query, `child` and `parent` are the axes. `Customer` and `Order` are the node tests.  
  
-   `attribute`  
  
     Contains the attribute of the context node.  
  
     The following XPath expression selects the **CustomerID** attribute of the context node:  
  
    ```  
    attribute::CustomerID  
    ```  
  
-   `self`  
  
     Contains the context node itself.  
  
     The following XPath expression selects the current node if it is the **\<Order>** node:  
  
    ```  
    self::Order  
    ```  
  
     In this XPath query, `self` is the axis and `Order` is the node test.  
  
  

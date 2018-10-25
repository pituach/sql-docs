---
title: "Creating SMO Programs | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: 
  - "database-engine"
  - "docset-sql-devref"
ms.topic: "reference"
helpviewer_keywords: 
  - "Visual Basic [SMO]"
  - "Visual C# [SMO]"
  - "programming [SMO]"
  - "SQL Server Management Objects, programming"
  - "SMO [SQL Server], programming"
ms.assetid: 7d2f0bcf-f1ae-45b8-bc3f-7aea4fae7e45
author: stevestein
ms.author: sstein
manager: craigg
---
# Creating SMO Programs
  General programming of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] Management Objects (SMO) objects includes the common areas that all objects share, such as running methods, setting properties, and manipulating collections.  
  
|Topic|Description|  
|-----------|-----------------|  
|[Connecting to an Instance of SQL Server](connecting-to-an-instance-of-sql-server.md)|The most basic SMO program that establishes a connection to an instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)]. Demonstrates the Windows Authentication and [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] Authentication. Also includes samples that show connecting to a local and a remote instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)].|  
|[Disconnecting from an Instance of SQL Server](disconnecting-from-an-instance-of-sql-server.md)|A program that demonstrates how to disconnect from the instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)].|  
|[Calling Methods](calling-methods.md)|This section describes the general approach to calling methods. Shows the use of parameters, and how to handle tables of data returned in a <xref:System.Data.DataTable> object. Also includes example of how to call an object constructor and how to call the `Clone` method.|  
|[Setting Properties](setting-properties-smo.md)|This section describes how to set different types of properties. Show how to set and get object properties. Also includes examples that set object properties when the object is created, and how to iterate through all the properties of an object.|  
|[Using Collections](using-collections.md)|Various programs that discuss the techniques that are used with object collections. Shows how to reference an object using collections. Also includes an example of how to iterate through the members of a collection.|  
|[Handling SMO Events](handling-smo-events.md)|This section describes how to set up and handle events in SMO. Includes an example of how to set up an event handler and how to set up event subscription.|  
|[Handling SMO Exceptions](handling-smo-exceptions.md)|This section describes how to trap exceptions in SMO. Includes examples of how to catch an exception and how to display an inner exception.|  
|[Working with Data Types](working-with-data-types.md)|This section describes how to work with the different [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] data types. Describes how to construct a datatype with the specification in the object constructor. Also includes example of how to create a datatype by using the default constructor.|  
|[Using Transactions](using-transactions.md)|This section describes how to implement transaction processing in an SMO program. Includes example of how to use transactions in an SMO program.|  
|[Using Capture Mode](using-capture-mode.md)|This section describes how to record the output of the SMO program. The example records the SMO program as [!INCLUDE[tsql](../../../includes/tsql-md.md)] statements sent to the instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] for later execution.|  
  
  

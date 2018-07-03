---
title: "Tabular Models | Microsoft Docs"
ms.date: 05/07/2018
ms.prod: sql
ms.technology: analysis-services
ms.custom: tabular-models
ms.topic: conceptual
ms.author: owend
ms.reviewer: owend
author: minewiskan
manager: kfile
---
# Tabular models
[!INCLUDE[ssas-appliesto-sqlas-aas](../../includes/ssas-appliesto-sqlas-aas.md)]
  Tabular models are Analysis Services databases that run in-memory or in DirectQuery mode, accessing data directly from backend relational data sources. By using state-of-the-art compression algorithms and multi-threaded query processor, the analytics engine delivers fast access to tabular model objects and data by reporting client applications like Power BI and Excel.  
  
 While in-memory models are the default, DirectQuery is an alternative query mode for models that are either too large to fit in memory, or when data volatility precludes a reasonable processing strategy. DirectQuery achieves parity with in-memory models through support for a wide array of data sources, ability to handle calculated tables and columns in a DirectQuery model, row level security via DAX expressions that reach the backend database, and query optimizations that result in faster throughput.
  
 Tabular models are created in [!INCLUDE[ssBIDevStudioFull](../../includes/ssbidevstudiofull-md.md)] using the Tabular model project template that provides a design surface for creating a model, tables, relationships, and DAX expressions. You can import data from multiple sources, and then enrich the model by adding relationships, calculated tables and columns, measures, KPIs, hierarchies, and translations.  
  
 Models can then be deployed to Azure Analysis Services or an instance of SQL Server Analysis Services configured for Tabular server mode. Deployed tabular models can be managed in SQL Server Management Studio. As your models grow, they can be partitioned for optimized processing and secured to the row-level by using role-based security.  

  
  

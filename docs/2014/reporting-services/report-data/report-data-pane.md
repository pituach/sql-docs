---
title: "Report Data Pane | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "reporting-services-native"
ms.tgt_pltfrm: ""
ms.topic: conceptual
f1_keywords: 
  - "sql12.rtp.rptdesigner.reportdata.f1"
  - "10039"
helpviewer_keywords: 
  - "Report Data pane"
ms.assetid: aa9614a3-12e7-4e17-9de2-fafccd1f5f9d
caps.latest.revision: 27
author: markingmyname
ms.author: maghan
manager: craigg
---
# Report Data Pane
  Use the **Report Data** pane to view the currently defined parameters, data sources, datasets, field collections, and images in your report. The Report Dane displays a hierarchical view of the items that represent data in your report. The top level nodes represent built-in fields, parameters, images, and data source references. Expand each node to view the data items. For example, when you expand a data source node, the datasets defined for that data source appear. When you expand a dataset, its field collection appears. Drag items to the report design surface to link data with report items on the report page.  
  
## Options  
 **Built-in Fields**  
 Represents fields provided by Reporting Services that are commonly used in a report, such as the report name or page number. For more information, see [Built-in Collections in Expressions &#40;Report Builder and SSRS&#41;](../report-design/built-in-collections-in-expressions-report-builder.md).  
  
 **Parameters**  
 Represents the collection of report parameters, each of which can be single-valued or multivalued. For more information, see [Report Parameters &#40;Report Builder and Report Designer&#41;](../report-design/report-parameters-report-builder-and-report-designer.md).  
  
 **Images**  
 Represents the set of images used in the report. For more information, see [Images &#40;Report Builder and SSRS&#41;](../report-design/images-report-builder-and-ssrs.md).  
  
 **Data source**  
 Represents a single data source reference to an embedded data source or to a shared data source. In [!INCLUDE[ssBIDevStudioFull](../../includes/ssbidevstudiofull-md.md)], shared data sources appear in Solution Explorer under the Shared Data Sources folder. A data source specifies one of the data source types supported by Reporting Services. A data source is the parent node for the collection of datasets based on it. For more information, see [Data Connections, Data Sources, and Connection Strings in Reporting Services](../data-connections-data-sources-and-connection-strings-in-reporting-services.md) .  
  
 **Dataset**  
 Represents a single dataset. A dataset is the parent node for the collection of fields specified by the query and including any calculated fields. Reporting Services supports query designers to help you specify a query. For more information, see [Add Data to a Report &#40;Report Builder and SSRS&#41;](report-datasets-ssrs.md) and [Query Design Tools in Report Designer SQL Server Data Tools &#40;SSRS&#41;](query-design-tools-ssrs.md).  
  
## See Also  
 [Dataset Fields Collection &#40;Report Builder and SSRS&#41;](dataset-fields-collection-report-builder-and-ssrs.md)   
 [Grouping Pane](../tools/grouping-pane.md)  
  
  

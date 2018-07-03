---
title: "Create a Drillthrough (RDLC) Report with Parameters using ReportViewer (SSRS Tutorial) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "reporting-services-native"
ms.tgt_pltfrm: ""
ms.topic: conceptual
ms.assetid: 628c8775-c62d-45ac-b349-23db86fa4e6c
caps.latest.revision: 8
author: markingmyname
ms.author: maghan
manager: craigg
---
# Create a Drillthrough (RDLC) Report with Parameters using ReportViewer (SSRS Tutorial)
  A [drillthrough](http://technet.microsoft.com/library/ff519554.aspx) report is a report that a user opens by clicking a link within another report. Drillthrough reports commonly contain details about an item that is contained in an original summary report. This tutorial will walk you through the following lessons of creating a drillthrough report with parameters and a query, in [local mode reporting](http://msdn.microsoft.com/library/ff487969.aspx).  
  
## Requirements  
 To use this walkthrough, you must have access to the **AdventureWorks2008** sample database. The query used in this walkthrough will also work with **AdventureWorks2012** database. For more information about how to get the **AdventureWorks2008** sample database, see [Walkthrough: Installing the AdventureWorks Database](http://msdn.microsoft.com/library/aa992075\(v=vs.100\).aspx) for Microsoft Visual Studio 2010.  
  
 This walkthrough assumes that you are familiar with Transaction-SQL queries and ADO.NET [DataSet](http://msdn.microsoft.com/library/system.data.dataset\(v=vs.100\).aspx) and [DataTable](http://msdn.microsoft.com/library/system.data.datatable\(v=vs.100\).aspx) objects.  
  
 Use Visual Studio 2010, or Visual Studio 2012, and the ASP.NET website template to create an ASP.NET webpage with a ReportViewer control. The control is configured to view a report that you create. For this walkthrough, you create the application in Microsoft Visual C#.  
  
## Tasks  
 [Lesson 1: Create a New Web Site](../reporting-services/lesson-1-create-a-new-web-site.md)   
 [Lesson 2: Define a Data Connection and Data Table for Parent Report](../reporting-services/lesson-2-define-a-data-connection-and-data-table-for-parent-report.md)   
 [Lesson 3: Design the Parent Report using the Report Wizard](../reporting-services/lesson-3-design-the-parent-report-using-the-report-wizard.md)   
 [Lesson 4: Define a Data Connection and Data Table for Child Report](../reporting-services/lesson-4-define-a-data-connection-and-data-table-for-child-report.md)   
 [Lesson 5: Design the Child Report using the Report Wizard](../reporting-services/lesson-5-design-the-child-report-using-the-report-wizard.md)   
 [Lesson 6: Add a ReportViewer Control to the Application](../reporting-services/lesson-6-add-a-reportviewer-control-to-the-application.md)   
 [Lesson 7: Add Drillthrough Action on Parent Report](../reporting-services/lesson-7-add-drillthrough-action-on-parent-report.md)   
 [Lesson 8: Create a Data Filter](../reporting-services/lesson-8-create-a-data-filter.md)   
 [Lesson 9: Build and Run the Application](../reporting-services/lesson-9-build-and-run-the-application.md)  
  
## See Also  
 [Reporting Services Tutorials &#40;SSRS&#41;](../reporting-services/reporting-services-tutorials-ssrs.md)   
 [Design Reports with Report Designer &#40;SSRS&#41;](tools/design-reporting-services-paginated-reports-with-report-designer-ssrs.md)  
  
  

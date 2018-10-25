---
title: Tutorial about RevoScaleR functions with SQL Server Machine Learning | Microsoft Docs
description: In this tutorial, learn how to call RevoScaleR function in SQL Server Machine Learning with R supported enabled.
ms.prod: sql
ms.technology: machine-learning

ms.date: 07/15/2018  
ms.topic: tutorial
author: HeidiSteen
ms.author: heidist
manager: cgronlun
---
# Tutorial: Use RevoScaleR R functions with SQL Server data
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md-winonly](../../includes/appliesto-ss-xxxx-xxxx-xxx-md-winonly.md)]

RevoScaleR is a Microsoft R package providing distributed and parallel processing for data science and machine learning workloads. For R development in SQL Server, RevoScaleR is one of the core built-in packages, with functions for setting a compute context, managing packages, and most importantly: working with data end-to-end, from import to visualization and analysis. Machine Learning algorithms in SQL Server have a dependency on RevoScaleR data sources. Given the importance of RevoScaleR, knowing when and how to call its functions is an essential skill. 

In this tutorial, you will learn how to create a remote compute context, move data between local and remote compute contexts, and execute R code on a remote SQL Server. You also learn how to analyze and plot data both locally and on the remote server, and how to create and deploy models.

+ Data is initially obtained from CSV files or XDF files. You import the data into [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] using the functions in the RevoScaleR package.
+ Model training and scoring is performed using the [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] compute context. 
+ Use RevoScaleR functions to create new [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] tables to save your scoring results.
+ Create plots both on the server and in the local compute context.
+ Train a model on data in [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] database, running R in the [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] instance.
+ Extract a subset of data and save it as an XDF file for re-use in analysis on your local workstation.
+ Get new data for scoring, by opening an ODBC connection to the [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] database. Scoring is done on the local workstation.
+ Create a custom R function and run it in the server compute context to perform a simulation.

## Target audience

This tutorial is intended for data scientists or for people who are already somewhat familiar with R, and with data science tasks such as summaries and model creation. However, all the code is provided, so even if you are new to R, you can run the code and follow along, assuming you have the required server and client environments.

You should also be comfortable with [!INCLUDE[tsql](../../includes/tsql-md.md)] syntax and know how to access a [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] database using tools such as these:

+ [!INCLUDE[ssManStudioFull](../../includes/ssmanstudiofull-md.md)] 
+ Database tools in Visual Studio 
+ The free [mssql extension for Visual Studio Code](https://docs.microsoft.com/sql/linux/sql-server-linux-develop-use-vscode).
  
> [!TIP]
> Save your R workspace between lessons, so that you can easily pick up where you left off.

## Prerequisites

- **SQL Server with support for R**
  
    Install [SQL Server 2017 Machine Learning Services](../install/sql-machine-learning-services-windows-install.md) with the R feature, or install [SQL Server 2016 R Services (in-Database)](../install/sql-r-services-windows-install.md).

    Make sure external scripting is enabled, Launchpad service is running, and that you have permissions to access the service.
  
-  **Database permissions**
  
    To run the queries used to train the model, you must have **db_datareader** privileges on the database where the data is stored. To run R, your user must have the permission, EXECUTE ANY EXTERNAL SCRIPT.

-   **Data science development computer**
  
    To switch back and forth between local and remote compute contexts, you need two systems. Local is typically a development workstation with sufficent power for data science workloads. Remote in this case is SQL Server 2017 or SQL Server 2016 with the R feature enabled. 
    
    Switching compute contexts is predicated on having the same-version RevoScaleR on both local and remote systems. On a local workstation, you can get the RevoScaleR packages and related providers by installing or using any one of the following: [Data Science VM on Azure](https://docs.microsoft.com/azure/machine-learning/data-science-virtual-machine/overview), [Microsoft R Client (free)](https://docs.microsoft.com/machine-learning-server/r-client/what-is-microsoft-r-client), or [Microsoft Machine Learning Server (Standalone)](https://docs.microsoft.com/machine-learning-server/install/machine-learning-server-install). For the standalone server option, install the free developer edition, using either Linux or Windows installers. You can also use SQL Server Setup to install a standalone server.
      
-   **Additional R Packages**
  
    In this tutorial, you install the following packages: **dplyr**, **ggplot2**, **ggthemes**, **reshape2**, and **e1071**. Instructions are provided as part of the tutorial.
  
    All packages must be installed in two places: on the workstation used for R solution development, and on the SQL Server computer where R scripts are executed. If you do not have permission to install packages on the server computer, ask an administrator. 
    
    **Do not install the packages to a user library.** The packages must be installed in the R package library that is used by the SQL Server instance.

## R development tools

R developers typically use IDEs for writing and debugging R code. Here are some suggestions:

- **R Tools for Visual Studio** (RTVS) is a free plug-in that provides Intellisense, debugging, and support for Microsoft R. You can use it with both R Server and SQL Server Machine Learning Services. To download, see [R Tools for Visual Studio](https://www.visualstudio.com/vs/rtvs/).

- **RStudio** is one of the more popular environments for R development. For more information, see [https://www.rstudio.com/products/RStudio/](https://www.rstudio.com/products/RStudio/).

- Basic R tools (R.exe, RTerm.exe, RScripts.exe) are also installed by default when you install R in SQL Server or R Client. If you do not wish to install an IDE, you can use built-in R tools to execute the code in this tutorial.

Recall that RevoScaleR is required on both local and remote computers. You cannot complete this tutorial using a generic installation of RStudio or other environment that's missing the Microsoft R libraries. For more information, see [Set Up a Data Science Client](../r/set-up-a-data-science-client.md).

## Next steps

> [!div class="nextstepaction"]
> [Lesson 1: Create database and permissions](deepdive-work-with-sql-server-data-using-r.md)


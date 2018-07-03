---
title: SQL Server Machine Learning Server (Standalone) and R Server (Standalone) | Microsoft Docs
ms.prod: sql
ms.technology: machine-learning

ms.date: 04/15/2018  
ms.topic: conceptual
author: HeidiSteen
ms.author: heidist
manager: cgronlun
---
# SQL Server Machine Learning Server (Standalone) and R Server (Standalone)
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md-winonly](../../includes/appliesto-ss-xxxx-xxxx-xxx-md-winonly.md)]

A standalone server is an installation of machine learning components, articulated as R and Python features, that run independently of SQL Server database engine instances. You can install a standalone server by itself, with no dependencies on SQL Server. Because a standalone server is independent of SQL Server, configuration and administration tasks and tools are more similar to a non-SQL version of Machine Learning Server, which you can read about in [this article](https://docs.microsoft.com/machine-learning-server/what-is-machine-learning-server).

The objective of a standalone machine learning server is to provide a rich development environment, with distributed and parallel processing of R and Python workloads over small-to-large data sets, using the proprietary packages and calculation engines installed with the server. The R and Python packages on a standalone server are the same as those provided in a SQL Server (In-Database) installation, allowing for code portability and [compute-context switching](https://docs.microsoft.com/machine-learning-server/r/concept-what-is-compute-context).

The primary reason developers choose a standalone machine learning server is to move beyond the memory and processing constraints of open-source R and Python. Standalone servers can load and process large amounts of data on multiple cores and aggregate the results into a single consolidated output. The functions and algorithms are engineered for both scale and utility: delivering predictive analytics, statistical modeling, data visualizations, and leading-edge machine learning algorithms in a commercial server product engineered and supported by Microsoft.

Generally, we recommend that you treat (Standalone) and (In-Database) installations as mutually exclusive to avoid resource contention, but if you have sufficient resources, there is no prohibition against installing them both on the same physical computer.

You can only have one standalone server on the computer: either [SQL Server 2017 Machine Learning Server (standalone)](../install/sql-machine-learning-standalone-windows-install.md) or [SQL Server 2016 R Server (Standalone)](../install/sql-r-standalone-windows-install.md). You must manually uninstall one version before installing a different version.

## Components of a standalone server

SQL Server 2016 is R only. SQL Server 2017 supports R and Python. The following table describes the features in each version.

| Component | Description |
|-----------|-------------|
| R packages | [RevoScaleR](revoscaler-overview.md) is the primary library for scaleable R with functions for data manipulation, transformation, visualzation, and analysis.  <br/>[MicrosoftML (R)](https://docs.microsoft.com/machine-learning-server/r-reference/microsoftml/microsoftml-package) adds machine learning algorithms to create custom models for text analysis, image analysis, and sentiment analysis. <br/>[mrsdeploy](operationalization-with-mrsdeploy.md) offers web service deployment (in SQL Server 2017 only). <br/>[olapR](how-to-create-mdx-queries-using-olapr.md) is for specifying MDX queries in R.|
| Microsoft R Open (MRO) | [MRO](https://mran.microsoft.com/open) is Microsoft's open-source distribution of R. The package and interpreter are included. Always use the version of MRO bundled in setup. |
| R tools | R console windows and command prompts are standard tools in an R distribution. Find them at \Program files\Microsoft SQL Server\140\R_SERVER\bin\x64. |
| R Samples and scripts |  Open-source R and RevoScaleR packages include built-in data sets so that you can create and run script using pre-installed data. Look for them at \Program files\Microsoft SQL Server\140\R_SERVER\library\datasets and \library\RevoScaleR. |
| Python packages | [revoscalepy](../python/what-is-revoscalepy.md) is the primary library for scaleable Python with functions for data manipulation, transformation, visualzation, and analysis. <br/>[microsoftml (Python)](https://docs.microsoft.com/machine-learning-server/python-reference/microsoftml/microsoftml-package) adds machine learning algorithms to create custom models for text analysis, image analysis, and sentiment analysis.  |
| Python tools | The built-in Python command line tool is useful for ad hoc testing and tasks. Find the tool at \Program files\Microsoft SQL Server\140\PYTHON_SERVER\python.exe. |
| Anaconda | Anaconda is an open-source distribution of Python and essential packages. |
| Python samples and scripts | As with R, Python includes built-in data sets  and scripts. Find the revoscalepy data at \Program files\Microsoft SQL Server\140\PYTHON_SERVER\lib\site-packages\revoscalepy\data\sample-data. |
| Pre-trained models in R and Python | Pre-trained models are supported and usable on a standalone server, but you cannot install them through SQL Server Setup. The setup program for Microsoft Machine Learning Server provides the models, which you can install free of charge. For more information, see [Install pretrained machine learning models on SQL Server](install-pretrained-models-sql-server.md). |

## Get started step-by-step

Start with setup, attach the binaries to your favorite development tool, and write your first script.

### Step 1: Install the software

Install either one of these versions:

+ [SQL Server 2017 Machine Learning Server (standalone)](../install/sql-machine-learning-standalone-windows-install.md)
+ [SQL Server 2016 R Server (Standalone) - R only](../install/sql-r-standalone-windows-install.md)

### Step 2: Configure a development tool

Configure your development tools to use the Machine Learning Server binaries. For more information about Python, see [Link Python binaries](https://docs.microsoft.com/machine-learning-server/python/quickstart-python-tools). For instructions on how to connect in R Studio, see [Using Different Versions of R](https://support.rstudio.com/hc/en-us/articles/200486138-Using-Different-Versions-of-R) and point the tool to C:\Program Files\Microsoft SQL Server\140\R_SERVER\bin\x64. You could also try [R Tools for Visual Studio](https://docs.microsoft.com/visualstudio/rtvs/installation). 

### Step 3: Write your first script

Write R or Python script using functions from RevoScaleR, revoscalepy, and the machine learning algorithms.
  
  + [Explore R and RevoScaleR in 25 Functions](https://docs.microsoft.com/machine-learning-server/r/tutorial-r-to-revoscaler): Start with basic R commands and then progress to the RevoScaleR distributable analytical functions that provide high performance and scaling to R solutions. Includes parallelizable versions of many of the most popular R modeling packages, such as k-means clustering, decision trees, and decision forests, and tools for data manipulation.

  + [Quickstart: An example of binary classification with the microsoftml Python package](https://docs.microsoft.com/machine-learning-server/python/quickstart-binary-classification-with-microsoftml): Create a binary classification model using the functions from microsoftml and the well-known breast cancer dataset.

Choose the best language for the task. R is best for statistical computations that are difficult to implement using SQL. For set-based operations over data, leverage the power of [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] to achieve maximum performance. Use the in-memory database engine for very fast computations over columns.

### Step 4: Operationalize your solution

Standalone servers can use the [operationalization](https://docs.microsoft.com//machine-learning-server/what-is-operationalization) functionality of the non-SQL-branded [Microsoft Machine Learning Server](https://docs.microsoft.com/machine-learning-server/what-is-machine-learning-server). You can configure a standalone server for operationalization, which gives you these benefits: deploy and host your code as web services, run diagnostics, test web service capacity.

## See also

 [SQL Server Machine Learning Services (In-Database)](sql-server-r-services.md)


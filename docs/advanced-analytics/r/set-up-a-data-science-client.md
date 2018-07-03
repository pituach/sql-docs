---
title: Set up a data-science client for R development on SQL Server | Microsoft Docs
ms.prod: sql
ms.technology: machine-learning

ms.date: 04/15/2018  
ms.topic: conceptual
author: HeidiSteen
ms.author: heidist
manager: cgronlun
---
# Set up a data-science client for R development on SQL Server
[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md-winonly](../../includes/appliesto-ss-xxxx-xxxx-xxx-md-winonly.md)]

After you have configured an instance of [!INCLUDE[ssCurrent](../../includes/sscurrent-md.md)] to support machine learning, you should set up a development environment that is capable of connecting to the server for remote execution and deployment.

This article describes some typical client scenarios, including configuration of the free Visual Studio Community edition to run R code in SQL Server.

## Install R libraries on the client

Your client environment must include Microsoft R Open, as well as the additional RevoScaleR packages that support distributed execution of R on SQL Server. Standard distributions of R do not have the packages that support remote compute contexts or parallel execution of R tasks.

To get these libraries, install any of the following:
  
+ [Microsoft R Client](http://aka.ms/rclient/download)

+ Microsoft R Server (for SQL Server 2016)

    - To install from SQL Server setup, see [Install SQL Server 2016 R Server (Standalone)](../install/sql-r-standalone-windows-install.md)

    - To use the separate Windows-based installer, see [Install Machine Learning Server for Windows](https://docs.microsoft.com/machine-learning-server/install/machine-learning-server-windows-install)

+ Machine Learning Server (for SQL Server 2017)

    - To install from SQL Server setup, see [Install SQL Server 2017 Machine Learning Server (Standalone)](../install/sql-machine-learning-standalone-windows-install.md)

    - To use the separate Windows-based installer, see [Install R Server 9.1 for Windows](https://docs.microsoft.com/machine-learning-server/install/r-server-install-windows)

## R tools

When you install R with SQL Server, you get the same R tools that are installed with any **base** installation of R, such as RGui, Rterm, and so forth. Therefore technically, you have all the tools you need to develop and test R code.

The following standard R tools are included in a *base installation* of R, and therefore are installed by default.

+ **RTerm**: A command-line terminal for running R scripts

+ **RGui.exe**:  A simple interactive editor for R. The command-line arguments are the same for RGui.exe and RTerm.

+ **RScript**: A command-line tool for running R scripts in batch mode.

To locate these tools, determine the R library that was installed when you set up SQL Server or the standalone machine learning feature. For example, in a default installation, the R tools are located in these folders:

+ SQL Server 2016 R Services: `~\Program Files\Microsoft SQL Server\MSSQL13.<instancename>\R_SERVICES\bin\x64`
+ Microsoft R Server Standalone: `~\Program Files\Microsoft R\R_SERVER\bin\x64`
+ SQL Server 2017 Machine Learning Services: `~\Program Files\Microsoft SQL Server\MSSQL14.<instancename>\R_SERVICES\bin\x64`
+ Machine Learning Server (Standalone): `~\Program Files\Microsoft\ML Server\R_SERVER\bin\x64`

If you need help with the R tools, just open **RGui**, click **Help**, and select one of the options

## Microsoft R Client

Microsoft R Client is a free download that gives you access to the RevoScaleR packages for development use. By installing R Client, you can create R solutions that can be run in all supported compute contexts, including SQL Server in-database analytics, and distributed R computing on Hadoop, Spark, or Linux using Machine Learning Server.

If you have already installed a different R development environment, such as RStudio, be sure to reconfigure the environment to use the libraries and executables provided by Microsoft R Client. By doing so you can use all the features of the RevoScaleR package, although performance will be limited.

For more information, see [What is Microsoft R Client?](https://docs.microsoft.com/machine-learning-server/r-client/what-is-microsoft-r-client)

## Install a development environment

If you don't already have a preferred R development environment, we recommend one of the following:

+ R Tools for Visual Studio

    Works with Visual Studio 2015.

    For setup information, see [How to install R Tools for Visual Studio](https://docs.microsoft.com/visualstudio/rtvs/installation).
 
    To configure RTVS to use your Microsoft R client libraries, see [About Microsoft R Client](https://docs.microsoft.com/machine-learning-server/r-client/what-is-microsoft-r-client)

+ Visual Studio 2017

    Even the free Community Edition includes the data science workload, which installs project templates for R, Python, and F#.

    Download Visual Studio from [this site](https://www.visualstudio.com/vs/). 

+ RStudio

    If you prefer to use RStudio, some additional steps are required to use the RevoScaleR libraries:

    - Install Microsoft R Client to get the required packages and libraries.
    - Update your R path to use the Microsoft R runtime.

    For more information, see [R Client - configure your IDE](https://docs.microsoft.com/machine-learning-server/r-client/what-is-microsoft-r-client#step-2-configure-your-ide).

## Configure your IDE

+ R Tools for Visual Studio

    See [this site](https://docs.microsoft.com/visualstudio/rtvs/getting-started-with-r) for some examples of how to build and debug R projects using R Tools for Visual Studio. 

+ Visual Studio 2017

    If you install Microsoft R Client or R Server **before** you install Visual Studio, the R Server libraries are automatically detected and used for your library path. If you have not installed the RevoScaleR libraries, from the **R Tools** menu, select **Install R Client**.

## Run R in SQL Server

This example uses Visual Studio 2017 Community Edition, with the data science workload installed.

1. From the **File** menu, select **New** and then select **Project**.

2. The -hand pane contains a list of preinstalled templates. Click **R**, and select **R Project**. In the **Name** box, type `dbtest` and click **OK**.

3. Visual Studio creates a new project folder and a default script file, `Script.R`. 

4. Type `.libPaths()` on the first line of the script file, and then press CTRL + ENTER.

5. The current R library path should be displayed in the **R Interactive** window. 

6. Click the **R Tools** menu and select **Windows** to see a list of other R-specific windows that you can display in your workspace.
 
    + View help on packages in the current library by pressing CTRL + 3.
    + See R variables in the **Variable Explorer**, by pressing CTRL + 8.

7. Create a connection string to a SQL Server instance, and use the connection string in the RxInSqlServer constructor to create a SQL Server data source object. 

    ```r
    connStr <- "Driver=SQL Server;Server=MyServer;Database=MyTestDB;Uid=;Pwd="
    sqlShareDir <- paste("C:\\AllShare\\", Sys.getenv("USERNAME"), sep = "")
    sqlWait <- TRUE
    sqlConsoleOutput <- FALSE
    cc <- RxInSqlServer(connectionString = connStr, shareDir = sqlShareDir, wait = sqlWait, consoleOutput = sqlConsoleOutput)
    sampleDataQuery <- "SELECT TOP 100 * from [dbo].[MyTestTable]"
    inDataSource <- RxSqlServerData(sqlQuery = sampleDataQuery, connectionString = connStr, rowsPerRead = 500)
    ```

    > [!TIP]
    > To run a batch, select the lines you want to run and press CTRL + ENTER.

8. Set the compute context to the server, and then run some simple R code on the data.

    ```r
    rxSetComputeContext(cc)
    rxGetVarInfo(data = inDataSource)
    ```

    Results are returned in the **R Interactive** window.
    
    If you want to assure yourself that the code is being executed on the SQL Server instance, you can use Profiler to create a trace.
---
title: "Feature Switch (Analytics Platform System)"
description: "Displays information about the two feature switches that are introduced in Analytics Platform System AU7."
author: "mzaman1" 
manager: "craigg"	  
ms.prod: "sql"
ms.technology: "data-warehouse"
ms.topic: "conceptual"
ms.date: "06/27/2018"
ms.author: "murshedz"
ms.reviewer: "martinle"
monikerRange: ">= aps-pdw-2016-au7 || = sqlallproducts-allversions"
---
#Appliance Feature Switches
The **Feature Switch** page displays information about the feature switches that are being introduced in Analytics Platform System AU7 and later. Use this configuration page to update or enable/disable features and settings in Analytics Platform System. Changes to feature switch values require a service restart.

![DWConig Appliance Feature Switch](media/feature-switch/SQL_Server_PDW_DWConfig_feature_switch.png "DWConig Appliance Feature Switch") 

##AutoStatsEnabled
Controls the auto statistics feature. This feature switch is set to true by default after upgrading to AU7. Any database created after the upgrade will inherit auto creation and asynchronous update of statistics. For existing databases, database administrators can enable auto statistics with [ALTER DATABASE (Parallel Data Warehouse)](../t-sql/statements/alter-database-transact-sql.md?tabs=sqlpdw). For more information on statistics, see [Statistics](../relational-databases/statistics/statistics.md).

##UseCatalogQueries
Using catalog objects for some metadata calls instead of using SMO has shown performance improvement. Set to true by default in CU7.1, this switch controls that behavior. 

##DmsProcessStopMessageTimeoutInSeconds
Controls the time Data Movement Service (DMS) waits to synchronize on a busy system when a query involving data movement is cancelled. Updating to AU7 sets this value to 900 seconds (15 minutes) by default. The valid range is 0 – 3600 seconds.

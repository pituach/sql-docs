---
title: "The Memory Optimized Filegroup | Microsoft Docs"
ms.custom: ""
ms.date: "06/14/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: in-memory-oltp
ms.topic: conceptual
ms.assetid: 14106cc9-816b-493a-bcb9-fe66a1cd4630
author: CarlRabeler
ms.author: carlrab
manager: craigg
---
# The Memory Optimized Filegroup
  To create memory-optimized tables, you must first create a memory-optimized filegroup. The memory-optimized filegroup holds one or more containers. Each container contains data files or delta files or both.  
  
 Even though data rows from SCHEMA_ONLY tables are not persisted and the metadata for memory-optimized tables and natively compiled stored procedures is stored in the traditional catalogs, the [!INCLUDE[hek_2](../../includes/hek-2-md.md)] engine still requires a memory-optimized filegroup for SCHEMA_ONLY memory-optimized tables to provide a uniform experience for databases with memory-optimized tables.  
  
 The memory-optimized filegroup is based on filestream filegroup, with the following differences:  
  
-   You can only create one memory-optimized filegroup per database. You need to explicitly mark the filegroup as containing memory_optimized_data. You can create the filegroup when you create the database or you can add it later:  
  
    ```  
    ALTER DATABASE imoltp ADD FILEGROUP imoltp_mod CONTAINS MEMORY_OPTIMIZED_DATA  
    ```  
  
-   You need to add one or more containers to the MEMORY_OPTIMIZED_DATA filegroup. For example:  
  
    ```  
    ALTER DATABASE imoltp ADD FILE (name='imoltp_mod1', filename='c:\data\imoltp_mod1') TO FILEGROUP imoltp_mod  
    ```  
  
-   You do not need to enable filestream ([Enable and Configure FILESTREAM](../blob/enable-and-configure-filestream.md)) to create a memory-optimized filegroup. The mapping to filestream is done by the [!INCLUDE[hek_2](../../includes/hek-2-md.md)] engine.  
  
-   You can add new containers to a memory-optimized filegroup. You may need a new container to expand the storage needed for durable memory-optimized table and also to distribute IO across multiple containers.  
  
-   Data movement with a memory-optimized filegroup is optimized in an AlwaysOn Availability Group configuration. Unlike filestream files that are sent to secondary replicas, the checkpoint files (both data and delta) within the memory-optimized filegroup are not sent to secondary replicas. The data and delta files are constructed using the transaction log on the secondary replica.  
  
 The following limitations of memory-optimized filegroup,  
  
-   Once you create a memory-optimized filegroup, you can only remove it by dropping the database. In a production environment, it is unlikely that you will need to remove the memory-optimized filegroup.  
  
-   You cannot drop a non-empty container or move data and delta file pairs to another container in the memory-optimized filegroup.  
  
-   You cannot specify MAXSIZE for the container.  
  
## Configuring a Memory-Optimized Filegroup  
 You should consider creating multiple containers in the memory-optimized filegroup and distribute them on different drives to achieve more bandwidth to stream the data into memory.  
  
 When configuring storage, you must provide free disk space that is four times the size of durable memory-optimized tables. You must also ensure that your IO subsystem supports the required IOPS for your workload. If data and delta file pairs are populated at a given IOPS, you need 3 times that IOPS to account for storing and merge operations. You can add storage capacity and IOPS by adding one or more containers to the memory-optimized filegroup.  
  
 In a multiple container, multiple drive scenario, data and delta files are allocated in a round-robin fashion into containers. The first data file is allocated from the first container and the delta file is allocated from the next container and this allocation pattern repeats. This allocation scheme distributes data and delta files evenly across containers if you have an odd number of drives, each mapped to one container. However, if you have an even number of drives, each mapped to a container, it can result in imbalanced storage with data files mapped to odd drives and delta files mapped to even drives. To obtain a balanced stream of IO on recovery, consider placing pairs of data and delta files on the same spindles/storage as described in the example below.  
  
 **Example:** Consider a memory-optimized filegroup with two containers: container 1 on drive X and container 2 on drives Y. Since the allocation of data and delta files is done in round-robin fashion, container 1 will only have data files and container 2 will only have delta files, which leads to imbalanced persistence for storage as well as input/output operations per second, as data files are significantly larger than the delta files. To distribute data and delta files uniformly across drives X and Y, create four containers instead of two and map the first two containers to drive X and the next two containers to drive Y. With round-robin allocation, the first data and first delta file will be allocated from container-1 and container-2 respectively which are mapped to drive X. Similarly, the next data and delta file will be allocated from container-3 and container-4 which are mapped to drive Y. This allows distributing data and delta files across two drives uniformly.  
  
## See Also  
 [Creating and Managing Storage for Memory-Optimized Objects](creating-and-managing-storage-for-memory-optimized-objects.md)  
  
  

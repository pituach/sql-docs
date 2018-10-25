---
title: How to configure persistent memory (PMEM) for SQL Server on Linux | Microsoft Docs
description: This article provides a walk-through for configuring PMEM on Linux.
author: DBArgenis 
ms.author: argenisf 
manager: craigg
ms.date: 09/24/2018
ms.topic: conceptual
ms.prod: sql
ms.custom: "sql-linux"
ms.technology: linux
monikerRange: ">= sql-server-ver15 || = sqlallproducts-allversions"
---
# How to configure persistent memory (PMEM) for SQL Server on Linux

[!INCLUDE[appliesto-ss-xxxx-xxxx-xxx-md-linuxonly](../includes/appliesto-ss-xxxx-xxxx-xxx-md-linuxonly.md)]

This article describes how to configure the persistent memory (PMEM) for SQL Server on Linux. PMEM support on Linux was introduced in SQL Server 2019 CTP 2.0.

## Overview

SQL Server 2016 introduced support for Non-Volatile DIMMs, and an optimization called [Tail of the Log Caching on NVDIMM]( https://blogs.msdn.microsoft.com/bobsql/2016/11/08/how-it-works-it-just-runs-faster-non-volatile-memory-sql-server-tail-of-log-caching-on-nvdimm/) that shortened the amount of operations needed to harden a log buffer to persistent storage. This leverages Windows Server’s capability to directly access a persistent memory device in DAX mode.

SQL Server 2019 preview extends the support for persistent memory (PMEM) devices to Linux, providing full enlightenment of data and transaction log files placed on PMEM. Enlightenment refers to the method of access to the storage device using efficient user-space memcpy operations. Rather than going through the file system and storage stack, SQL Server leverages the DAX support on Linux to directly place data into the devices, incurring into minimal latency.

## Enable enlightenment of database files
To enable enlightenment of database files in SQL Server on Linux, follow the following steps:

1. Configure the devices
  In Linux, this is performed using the `ndctl` utility.

  - Install install `ndctl` to configure pmem device. You can find it [here](https://docs.pmem.io/getting-started-guide/installing-ndctl).
  - Use [ndctl] to create a namespace.

  ```bash 
  ndctl create-namespace -f -e namespace0.0 --mode=fsdax* –map=mem
  ```

  >[!NOTE]
  >If you are using `ndctl` version lower than 59, use `--mode=memory`.

  Use `ndctl` to verify the namespace. Sample output follows:

```bash
ndctl list
[
  {
    "dev":"namespace0.0",
    "mode":"memory",
    "size":1099511627776,
    "blockdev":"pmem0",
    "numa_node":0
  }
]
```

  - Create and mount pmem device

    For example, with XFS

    ```bash
    mkfs.xfs -f /dev/pmem0
    mount –o dax,noatime /dev/pmem0 /mnt/dax
    xfs_io -c "extsize 2m" /mnt/dax
    ```

    For example, with EXT4

    ```bash
    mkfs.ext4 -b 4096 -E stride=512 -F /dev/pmem0
    mount –o dax,noatime /dev/pmem0 /mnt/dax
    ```

  Once the device has been configured with ndctl, formatted and mounted, you can place database files in it. You can also create a new database 

1. Enable SQL Server database file enlightenment by using trace flag 3979. This trace flag is a startup trace flag, and as such needs to be enabled using the mssql-conf utility.

1. Restart SQL Server.

## Next steps

For more information about SQL Server on Linux, see [SQL Server on Linux](sql-server-linux-overview.md).

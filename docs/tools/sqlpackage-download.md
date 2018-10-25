---
title: Download and install sqlpackage | Microsoft Docs
description: 'Download and Install sqlpackage for Windows, macOS, or Linux'
ms.custom: "tools|sos"
ms.date: "06/18/2018"
ms.prod: sql
ms.reviewer: "alayu; sstein"
ms.prod_service: sql-tools
ms.topic: conceptual
author: "pensivebrian"
ms.author: "broneill"
manager: craigg
---
# Download and install sqlpackage

sqlpackage runs on Windows, macOS, and Linux.

Download and install the latest .NET Framework release and macOS and Linux previews:

|Platform|Download|Release date|Version|Build|
|:---|:---|:---|:---|:---|
|Windows|[Installer](https://go.microsoft.com/fwlink/?linkid=875508)|June 22, 2018|17.8|14.0.4079.2|
|macOS (preview)|[.zip](https://go.microsoft.com/fwlink/?linkid=873927)|May 9, 2018 |0.0.1|15.0.4057.1|
|Linux (preview)|[.zip](https://go.microsoft.com/fwlink/?linkid=873926)|May 9, 2018 |0.0.1|15.0.4057.1|

For details about the latest release, see the [release notes](sqlpackage-release-notes.md).

## Get sqlpackage for Windows

This release of sqlpackage includes a standard Windows installer experience, and a .zip: 

1. Download and run the [DacFramework.msi installer for Windows](https://go.microsoft.com/fwlink/?linkid=875508).
2. Open a new Command Prompt window, and run sqlpackage.exe
    - sqlpackage is installed to the ```C:\Program Files\Microsoft SQL Server\140\DAC\bin``` folder

## Get sqlpackage (preview) for macOS

1. Download [sqlpackage for macOS](https://go.microsoft.com/fwlink/?linkid=873927).
2. To extract the file and launch sqlpackage, open a new Terminal window and type the following commands:

   **.zip Installation:**

   ```bash
   mv ~/Downloads/sqlpackage-linux-<version string> ~/sqlpackage 
   echo 'export PATH="$PATH:~/sqlpackage"' >> ~/.bash_profile
   source ~/.bash_profile
   sqlpackage
   ```

## Get sqlpackage (preview) for Linux

1. Download [sqlpackage for Linux](https://go.microsoft.com/fwlink/?linkid=873926) by using one of the installers or the tar.gz archive:
2. To extract the file and launch sqlpackage, open a new Terminal window and type the following commands:

   **.zip Installation:**

   ```bash
   cd ~
   mkdir sqlpackage
   unzip ~/Downloads/sqlpackage-linux-<version string>.zip ~/sqlpackage 
   echo 'export PATH="$PATH:~/sqlpackage"' >> ~/.bashrc
   source ~/.bashrc
   sqlpackage
   ```

   > [!NOTE]
   > On Debian, Redhat, and Ubuntu, you may have missing dependencies. Use the following commands to install these dependencies depending on your version of Linux:

   **Debian:**

   ```bash
   sudo apt-get install libuwind8
   ```

   **Redhat:**

   ```bash
   yum install libunwind
   yum install libicu
   ```

   **Ubuntu:**

   ```bash
   sudo apt-get install libunwind8

   # install the libicu library based on the Ubuntu version
   sudo apt-get install libicu52      # for 14.x
   sudo apt-get install libicu55      # for 16.x
   sudo apt-get install libicu57      # for 17.x
   sudo apt-get install libicu60      # for 18.x
   ```

## Uninstall sqlpackage (preview)

If you installed sqlpackage using the Windows installer, then uninstall the same way you remove any Windows application.

If you installed sqlpackage with a .zip or other archive, then simply delete the files.

## Supported Operating Systems

sqlpackage runs on Windows, macOS, and Linux, and is supported on the following platforms:

### Windows

- Windows 10
- Windows 8.1
- Windows 8
- Windows 7 SP1
- Windows Server 2016
- Windows Server 2012 R2
- Windows Server 2012
- Windows Server 2008 R2

### macOS

- macOS 10.13 High Sierra
- macOS 10.12 Sierra

### Linux (x64)

- Red Hat Enterprise Linux 7.4
- Red Hat Enterprise Linux 7.3
- SUSE Linux Enterprise Server v12 SP2
- Ubuntu 16.04

## Next Steps

- Learn more about [sqlpackage](sqlpackage.md)

[Microsoft Privacy Statement](https://go.microsoft.com/fwlink/?LinkId=521839)

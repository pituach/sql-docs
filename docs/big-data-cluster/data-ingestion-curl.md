---
title: Use curl to load data into HDFS on SQL Server 2019 CTP 2.0 | Microsoft Docs
description:
author: rothja
ms.author: jroth
manager: craigg
ms.date: 10/01/2018
ms.topic: conceptual
ms.prod: sql
---

# Use curl to load data into HDFS on SQL Server 2019 CTP 2.0

This article explains how to use **curl** to load data into HDFS on SQL Server 2019 CTP 2.0.

## Obtain the service external IP

WebHDFS is started when deployment is completed, and its access goes through Knox. The Knox endpoint is exposed through a Kubernetes service called (for now) **service-security-lb**.  To create the WebHDFS URL that you will need to use CURL to upload/download files you will need the **service-security-lb** service external IP address and the name of your cluster. You can get the service-security-lb service external IP address by running this command:

```bash
kubectl get service service-security-lb -n <cluster name> -o json | jq -r .status.loadBalancer.ingress[0].ip
```

> [!NOTE]
> The `<cluster name>` here is the name of the cluster that you provided when you ran mssqlctl create cluster `<cluster name>`.

## Construct the URL to access WebHDFS

Now, you can construct the URL to access the WebHDFS as follows:

`https://<service-security-lb service external IP address>:30433/gateway/default/webhdfs/v1/`

For example:

`https://13.66.190.205:30443/gateway/default/webhdfs/v1/`

## List a file

To list file under **hdfs:///airlinedata** use the following curl command:

```bash
curl -i -k -u root:root-password -X GET 'https://<service-security-lb IP external address>:30443/gateway/default/webhdfs/v1/airlinedata/?op=liststatus'
```

## Put a local file into HDFS

To put a new file **test.csv** from local directory to airlinedata directory (**Content-Type** parameter is required) use the following curl command:

```bash
curl -i -L -k -u root:root-password -X PUT 'https://<service-security-lb IP external address>:30443/gateway/default/webhdfs/v1/airlinedata/test.csv?op=create' -H 'Content-Type: application/octet-stream' -T 'test.csv'
```

## Create a directory

To create a directory **test** under `hdfs:///` use the following command:

```bash
curl -i -L -k -u root:root-password -X PUT 'https://<service-security-lb IP external address>:30443/gateway/default/webhdfs/v1/test?op=MKDIRS'
```

## Next steps

For more information about SQL Server big data cluster, see [What is SQL Server big data cluster?](big-data-cluster-overview.md).
---
title: "FIPS Mode in JDBC | Microsoft Docs"
ms.custom: ""
ms.date: "07/12/2018"
ms.prod: sql
ms.prod_service: connectivity
ms.reviewer: "craigg"
ms.technology: connectivity
ms.topic: conceptual
author: "David-Engel"
ms.author: "v-daveng"
manager: "kenvh"
---
# FIPS Mode
[!INCLUDE[Driver_JDBC_Download](../../includes/driver_jdbc_download.md)]

The Microsoft JDBC Driver for SQL Server supports *FIPS 140 Compliant Mode*. For Oracle / Sun JVM, refer to the [FIPS 140 Compliant Mode for SunJSSE](https://docs.oracle.com/javase/7/docs/technotes/guides/security/jsse/FIPS.html) section provided by Oracle to configure FIPS enabled JVM. 

#### Prerequisites

- FIPS configured JVM
- Appropriate SSL Certificate.
- Appropriate policy files. 
- Appropriate Configuration Parameters. 


## FIPS Configured JVM

To see the approved modules for FIPS Configuration, refer to the [Validated FIPS 140-1 and FIPS 140-2 Cryptographic Modules](http://csrc.nist.gov/groups/STM/cmvp/documents/140-1/1401val2016.htm). 

Vendors may have some additional steps to configure JVM with FIPS.

### Ensure your JVM is in FIPS Mode
To ensure your JVM is FIPS enabled, execute the following snippet: 

```java
public boolean isFIPS() throws Exception {
    Provider jsse = Security.getProvider("SunJSSE");
    return jsse != null && jsse.getInfo().contains("FIPS");
}
```

## Appropriate SSL Certificate
In order to connect SQL Server in FIPS mode, a valid SSL Certificate is required. Install or import it in the Java Key Store on the client machine (JVM) where FIPS is enabled.

### Importing SSL Certificate in Java KeyStore
For FIPS, most likely you need to import the certificate (.cert) to either PKCS or in a provider-specific format. 
Use the following snippet to import the SSL certificate and store it in a working directory with the appropriate KeyStore format. _TRUST\_STORE\_PASSWORD_ is your password for Java KeyStore. 


```java
public void saveGenericKeyStore(
		String provider,
		String trustStoreType,
		String certName,
		String certPath
		) throws KeyStoreException, CertificateException,
			NoSuchAlgorithmException, NoSuchProviderException,
			IOException
{
	KeyStore ks = KeyStore.getInstance(trustStoreType, provider);
	FileOutputStream os = new FileOutputStream("./MyTrustStore_" + trustStoreType);
	ks.load(null, null);
	ks.setCertificateEntry(certName, getCertificate(certPath));
	ks.store(os, TRUST_STORE_PASSWORD.toCharArray());
	os.flush();
	os.close();
}

private Certificate getCertificate(String pathName)
		throws FileNotFoundException, CertificateException
{
	FileInputStream fis = new FileInputStream(pathName);
	CertificateFactory cf = CertificateFactory.getInstance("X.509");
	return cf.generateCertificate(fis);
}
```


The following example is importing an Azure SSL Certificate in PKCS12 format with BouncyCastle Provider. The certificate is imported in the working directory named _MyTrustStore\_PKCS12_ by using the following snippet:

`saveGenericKeyStore(BCFIPS, PKCS12, "SQLAzure SSL Certificate Name", "SQLAzure.cer");`

## Appropriate policy files
For some FIPS Providers, unrestricted Policy jars are needed. In such cases, for Sun / Oracle, download the Java Cryptography Extension (JCE) Unlimited Strength Jurisdiction Policy Files for [JRE 8](http://www.oracle.com/technetwork/java/javase/downloads/jce8-download-2133166.html) or [JRE 7](http://www.oracle.com/technetwork/java/javase/downloads/jce-7-download-432124.html). 

## Appropriate Configuration Parameters
To run the JDBC Driver in FIPS-compliant mode, configure connection properties as shown in following table. 

#### Properties 

|Property|Type|Default|Description|Notes|
|---|---|---|---|---|
|encrypt|boolean ["true / false"]|"false"|For FIPS enabled JVM encrypt property should be **true**||
|TrustServerCertificate|boolean ["true / false"]|"false"|For FIPS, the user needs to validate certificate chain, so the user should use **"false"** value for this property. ||
|trustStore|String|null|Your Java Keystore file path where you imported your certificate. If you install certificate on your system, then no need to pass anything. Driver uses cacerts or jssecacerts files.||
|trustStorePassword|String|null|The password used to check the integrity of the trustStore data.||
|fips|boolean ["true / false"]|"false"|For FIPS enabled JVM this property should be **true**|Added in 6.1.4 (Stable release 6.2.2)||
|fipsProvider|String|null|FIPS provider configured in JVM. For example, BCFIPS or SunPKCS11-NSS |Added in 6.1.2 (Stable release 6.2.2), deprecated in 6.4.0 - see the details [Here](https://github.com/Microsoft/mssql-jdbc/pull/460).|
|trustStoreType|String|JKS|For FIPS mode set trust store type either PKCS12 or type defined by FIPS provider |Added in 6.1.2 (Stable release 6.2.2)||
| &nbsp; | &nbsp; | &nbsp; | &nbsp; | &nbsp; |


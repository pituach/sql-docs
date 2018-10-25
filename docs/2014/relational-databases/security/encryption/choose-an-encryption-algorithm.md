---
title: "Choose an Encryption Algorithm | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: security
ms.topic: conceptual
helpviewer_keywords: 
  - "cryptography [SQL Server], algorithms"
  - "encryption [SQL Server], algorithms"
  - "security [SQL Server], encryption"
  - "algorithms [SQL Server encryption]"
ms.assetid: 8227028c-a9c9-489d-bd27-fbf8242634ae
author: aliceku
ms.author: aliceku
manager: craigg
---
# Choose an Encryption Algorithm
  Encryption is one of several defenses-in-depth that are available to the administrator who wants to secure an instance of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)].  
  
 Encryption algorithms define data transformations that cannot be easily reversed by unauthorized users. [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] allows administrators and developers to choose from among several algorithms, including DES, Triple DES, TRIPLE_DES_3KEY, RC2, RC4, 128-bit RC4, DESX, 128-bit AES, 192-bit AES, and 256-bit AES.  
  
 No single algorithm is ideal for all situations, and guidance on the merits of each is beyond the scope of [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] Books Online. However, the following general principles apply:  
  
-   Strong encryption generally consumes more CPU resources than weak encryption.  
  
-   Long keys generally yield stronger encryption than short keys.  
  
-   Asymmetric encryption is weaker than symmetric encryption using the same key length, but it is relatively slow.  
  
-   Block ciphers with long keys are stronger than stream ciphers.  
  
-   Long, complex passwords are stronger than short passwords.  
  
-   If you are encrypting lots of data, you should encrypt the data using a symmetric key, and encrypt the symmetric key with an asymmetric key.  
  
-   Encrypted data cannot be compressed, but compressed data can be encrypted. If you use compression, you should compress data before encrypting it.  
  
> [!IMPORTANT]  
>  The RC4 algorithm is only supported for backward compatibility. New material can only be encrypted using RC4 or RC4_128 when the database is in compatibility level 90 or 100. (Not recommended.) Use a newer algorithm such as one of the AES algorithms instead. In [!INCLUDE[ssSQL11](../../../includes/sssql11-md.md)] and higher material encrypted using RC4 or RC4_128 can be decrypted in any compatibility level.  
>   
>  Repeated use of the same RC4 or RC4_128 KEY_GUID on different blocks of data will result in the same RC4 key because [!INCLUDE[ssNoVersion](../../../includes/ssnoversion-md.md)] does not provide a salt automatically. Using the same RC4 key repeatedly is a well-known error that will result in very weak encryption. Therefore, we have deprecated the RC4 and RC4_128 keywords. [!INCLUDE[ssNoteDepFutureDontUse](../../../includes/ssnotedepfuturedontuse-md.md)]  
  
 For more information about encryption algorithms and encryption technology, see [Key Security Concepts](http://go.microsoft.com/fwlink/?LinkId=62082) in the .NET Framework Developer's Guide on MSDN.  
  
 **Clarification regarding DES algorithms:**  
  
-   DESX was incorrectly named. Symmetric keys created with ALGORITHM = DESX actually use the TRIPLE DES cipher with a 192-bit key. The DESX algorithm is not provided. [!INCLUDE[ssNoteDepFutureAvoid](../../../includes/ssnotedepfutureavoid-md.md)]  
  
-   Symmetric keys created with ALGORITHM = TRIPLE_DES_3KEY use TRIPLE DES with a 192-bit key.  
  
-   Symmetric keys created with ALGORITHM = TRIPLE_DES use TRIPLE DES with a 128-bit key.  
  
## Related Tasks  
  
|||  
|-|-|  
|Encrypting using a symmetric key.|[CREATE SYMMETRIC KEY &#40;Transact-SQL&#41;](/sql/t-sql/statements/create-symmetric-key-transact-sql)|  
|Encrypting using an asymmetric key.|[CREATE ASYMMETRIC KEY &#40;Transact-SQL&#41;](/sql/t-sql/statements/create-asymmetric-key-transact-sql)|  
|Encrypting using a certificate.|[CREATE CERTIFICATE &#40;Transact-SQL&#41;](/sql/t-sql/statements/create-certificate-transact-sql)|  
|Encrypting database files using transparent data encryption.|[Transparent Data Encryption &#40;TDE&#41;](transparent-data-encryption.md)|  
|How to encrypt one column of a table.|[Encrypt a Column of Data](encrypt-a-column-of-data.md)|  
  
## See Also  
 [SQL Server Encryption](sql-server-encryption.md)   
 [Encryption Hierarchy](encryption-hierarchy.md)  
  
  

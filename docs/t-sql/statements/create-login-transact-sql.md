---
title: "CREATE LOGIN (Transact-SQL) | Microsoft Docs"
ms.custom: ""
ms.date: "10/02/2018"
ms.prod: sql
ms.prod_service: "database-engine, sql-database, sql-data-warehouse, pdw"
ms.reviewer: ""
ms.technology: t-sql
ms.topic: "language-reference"
f1_keywords: 
  - "CREATE_LOGIN_TSQL"
  - "CREATE LOGIN"
  - "LOGIN_TSQL"
  - "LOGIN"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "passwords [SQL Server], logins"
  - "mapping logins [SQL Server]"
  - "logins [SQL Server], creating"
  - "CREATE LOGIN statement"
  - "permissions [SQL Server], logins"
  - "Windows domain accounts [SQL Server]"
  - "re-hashing passwords"
  - "certificates [SQL Server], logins"
ms.assetid: eb737149-7c92-4552-946b-91085d8b1b01
author: CarlRabeler
ms.author: carlrab
manager: craigg
monikerRange: ">=aps-pdw-2016||=azuresqldb-current||=azuresqldb-current||=azure-sqldw-latest||>=sql-server-2016||=sqlallproducts-allversions||>=sql-server-linux-2017||=azuresqldb-mi-current"
---
# CREATE LOGIN (Transact-SQL)

Creates a login for SQL Server, SQL Database, SQL Data Warehouse, or Parallel Data Warehouse databases. Click one of the following tabs for the syntax, arguments, remarks, permissions, and examples for a particular version.

For more information about the syntax conventions, see [Transact-SQL Syntax Conventions](../../t-sql/language-elements/transact-sql-syntax-conventions-transact-sql.md). 

## Click a product!

In the following row, click whichever product name you are interested in. The click displays different content here on this webpage, appropriate for whichever product you click.

::: moniker range=">=sql-server-2016||>=sql-server-linux-2017||=sqlallproducts-allversions"

> [!div class="mx-tdCol2BreakAll"]
> ||||||
> |-|-|-|-|-|
> |**_\* SQL Server \*_**|[SQL Database<br />logical server](create-login-transact-sql.md?view=azuresqldb-current)|[SQL Database<br />Managed Instance](create-login-transact-sql.md?view=azuresqldb-mi-current)|[SQL Data<br />Warehouse](create-login-transact-sql.md?view=azure-sqldw-latest)|[Parallel<br />Data Warehouse](create-login-transact-sql.md?view=aps-pdw-2016)

&nbsp;

## SQL Server

## Syntax 
  
```  
-- Syntax for SQL Server  
CREATE LOGIN login_name { WITH <option_list1> | FROM <sources> }  
  
<option_list1> ::=   
    PASSWORD = { 'password' | hashed_password HASHED } [ MUST_CHANGE ]  
    [ , <option_list2> [ ,... ] ]  
  
<option_list2> ::=    
    SID = sid  
    | DEFAULT_DATABASE = database      
    | DEFAULT_LANGUAGE = language  
    | CHECK_EXPIRATION = { ON | OFF}  
    | CHECK_POLICY = { ON | OFF}  
    | CREDENTIAL = credential_name   
  
<sources> ::=  
    WINDOWS [ WITH <windows_options>[ ,... ] ]  
    | CERTIFICATE certname  
    | ASYMMETRIC KEY asym_key_name  
  
<windows_options> ::=        
    DEFAULT_DATABASE = database  
    | DEFAULT_LANGUAGE = language  
```  
  
## Arguments  
*login_name*  
Specifies the name of the login that is created. There are four types of logins: SQL Server logins, Windows logins, certificate-mapped logins, and asymmetric key-mapped logins. When you are creating logins that are mapped from a Windows domain account, you must use the pre-Windows 2000 user logon name in the format [\<domainName>\\<login_name>]. You cannot use a UPN in the format login_name@DomainName. For an example, see example D later in this article. Authentication logins are type **sysname** and must conform to the rules for [Identifiers](../../relational-databases/databases/database-identifiers.md) and cannot contain a '**\\**'. Windows logins can contain a '**\\**'. Logins based on Active Directory users, are limited to names of less than 21 characters. 

PASSWORD **='**_password_**'*
Applies to SQL Server logins only. Specifies the password for the login that is being created. You should use a strong password. For more information, see [Strong Passwords](../../relational-databases/security/strong-passwords.md) and [Password Policy](../../relational-databases/security/password-policy.md). Beginning with  SQL Server 2012 (11.x),, stored password information is calculated using SHA-512 of the salted password. 
  
Passwords are case-sensitive. Passwords should always be at least 8 characters long, and cannot exceed 128 characters. Passwords can include a-z, A-Z, 0-9, and most non-alphanumeric characters. Passwords cannot contain single quotes, or the *login_name*. 
  
PASSWORD **=**_hashed\_password_  
Applies to the HASHED keyword only. Specifies the hashed value of the password for the login that is being created. 
  
HASHED
Applies to SQL Server logins only. Specifies that the password entered after the PASSWORD argument is already hashed. If this option is not selected, the string entered as password is hashed before it is stored in the database. This option should only be used for migrating databases from one server to another. Do not use the HASHED option to create new logins. The HASHED option cannot be used with hashes created by SQL 7 or earlier.

MUST_CHANGE
Applies to SQL Server logins only. If this option is included, SQL Server prompts the user for a new password the first time the new login is used. 
  
CREDENTIAL **=**_credential\_name_  
The name of a credential to be mapped to the new SQL Server login. The credential must already exist in the server. Currently this option only links the credential to a login. A credential cannot be mapped to the System Administrator (sa) login. 
  
SID = *sid*  
Used to recreate a login. Applies to SQL Server authentication logins only, not Windows authentication logins. Specifies the SID of the new SQL Server authentication login. If this option is not used, SQL Server automatically assigns a SID. The SID structure depends on the SQL Server version. SQL Server login SID: a 16 byte (**binary(16)**) literal value based on a GUID. For example, `SID = 0x14585E90117152449347750164BA00A7`. 
  
DEFAULT_DATABASE **=**_database_  
Specifies the default database to be assigned to the login. If this option is not included, the default database is set to master. 
  
DEFAULT_LANGUAGE **=**_language_  
Specifies the default language to be assigned to the login. If this option is not included, the default language is set to the current default language of the server. If the default language of the server is later changed, the default language of the login remains unchanged. 
  
CHECK_EXPIRATION **=** { ON | **OFF** }  
Applies to SQL Server logins only. Specifies whether password expiration policy should be enforced on this login. The default value is OFF. 
  
CHECK_POLICY **=** { **ON** | OFF }  
Applies to SQL Server logins only. Specifies that the Windows password policies of the computer on which SQL Server is running should be enforced on this login. The default value is ON. 
  
If the Windows policy requires strong passwords, passwords must contain at least three of the following four characteristics:  
  
- An uppercase character (A-Z). 
- A lowercase character (a-z). 
- A digit (0-9). 
- One of the non-alphanumeric characters, such as a space, _, @, *, ^, %, !, $, #, or &. 
  
WINDOWS  
Specifies that the login be mapped to a Windows login. 
  
CERTIFICATE *certname*  
Specifies the name of a certificate to be associated with this login. This certificate must already occur in the master database. 
  
ASYMMETRIC KEY *asym_key_name*  
Specifies the name of an asymmetric key to be associated with this login. This key must already occur in the master database. 
  
## Remarks  
- Passwords are case-sensitive.
- Prehashing of passwords is supported only when you are creating SQL Server logins.
- If MUST_CHANGE is specified, CHECK_EXPIRATION and CHECK_POLICY must be set to ON. Otherwise, the statement will fail.
- A combination of CHECK_POLICY = OFF and CHECK_EXPIRATION = ON is not supported.
- When CHECK_POLICY is set to OFF, *lockout_time* is reset and CHECK_EXPIRATION is set to OFF. 
  
> [!IMPORTANT]  
>  CHECK_EXPIRATION and CHECK_POLICY are only enforced on Windows Server 2003 and later. For more information, see [Password Policy](../../relational-databases/security/password-policy.md). 
  
- Logins created from certificates or asymmetric keys are used only for code signing. They cannot be used to connect to SQL Server. You can create a login from a certificate or asymmetric key only when the certificate or asymmetric key already exists in master. 
- For a script to transfer logins, see [How to transfer the logins and the passwords between instances of SQL Server 2005 and SQL Server 2008](http://support.microsoft.com/kb/918992).
- Creating a login automatically enables the new login and grants the login the server level **CONNECT SQL** permission. 
- The server's [authentication mode](../../relational-databases/security/choose-an-authentication-mode.md) must match the login type to permit access.
- For information about designing a permissions system, see [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md).

## Permissions  
- Only users with **ALTER ANY LOGIN** permission on the server or membership in the **securityadmin** fixed server role can create logins. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles.
- If the **CREDENTIAL** option is used, also requires **ALTER ANY CREDENTIAL** permission on the server. 
  
## After creating a login  
After creating a login, the login can connect to SQL Server, but only has the permissions granted to the **public** role. Consider performing some of the following activities. 
  
 - To connect to a database, create a database user for the login. For more information, see [CREATE USER](../../t-sql/statements/create-user-transact-sql.md). 
  
 - Create a user-defined server role by using [CREATE SERVER ROLE](../../t-sql/statements/create-server-role-transact-sql.md). Use **ALTER SERVER ROLE** … **ADD MEMBER** to add the new login to the user-defined server role. For more information, see [CREATE SERVER ROLE](../../t-sql/statements/create-server-role-transact-sql.md) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md). 
  
 - Use **sp_addsrvrolemember** to add the login to a fixed server role. For more information, see [Server-Level Roles](../../relational-databases/security/authentication-access/server-level-roles.md) and [sp_addsrvrolemember](../../relational-databases/system-stored-procedures/sp-addsrvrolemember-transact-sql.md). 
  
 - Use the **GRANT** statement, to grant server-level permissions to the new login or to a role containing the login. For more information, see [GRANT](../../t-sql/statements/grant-transact-sql.md). 
  
## Examples  
  
### A. Creating a login with a password  
 The following example creates a login for a particular user and assigns a password. 
  
```sql  
CREATE LOGIN <login_name> WITH PASSWORD = '<enterStrongPasswordHere>';  
GO  
```  
  
### B. Creating a login with a password that must be changed
 The following example creates a login for a particular user and assigns a password. The `MUST_CHANGE` option requires users to change this password the first time they connect to the server. 
  
**Applies to**: [!INCLUDE[ssKatmai](../../includes/sskatmai-md.md)] through [!INCLUDE[ssCurrent](../../includes/sscurrent-md.md)]. 
  
```sql  
CREATE LOGIN <login_name> WITH PASSWORD = '<enterStrongPasswordHere>' 
    MUST_CHANGE,  CHECK_EXPIRATION = ON;
GO  
``` 

> [!NOTE]
> The MUST_CHANGE option cannot be used when CHECK_EXPIRATION is OFF.
  
### C. Creating a login mapped to a credential  
 The following example creates the login for a particular user, using the user. This login is mapped to the credential. 
  
**Applies to**: [!INCLUDE[ssKatmai](../../includes/sskatmai-md.md)] through [!INCLUDE[ssCurrent](../../includes/sscurrent-md.md)]. 
  
```sql  
CREATE LOGIN <login_name> WITH PASSWORD = '<enterStrongPasswordHere>',   
    CREDENTIAL = <credentialName>;  
GO  
```  
  
### D. Creating a login from a certificate  
 The following example creates login for a particular user from a certificate in master. 
  
**Applies to**: [!INCLUDE[ssKatmai](../../includes/sskatmai-md.md)] through [!INCLUDE[ssCurrent](../../includes/sscurrent-md.md)]. 
  
```sql
USE MASTER;  
CREATE CERTIFICATE <certificateName>  
    WITH SUBJECT = '<login_name> certificate in master database',  
    EXPIRY_DATE = '12/05/2025';  
GO  
CREATE LOGIN <login_name> FROM CERTIFICATE <certificateName>;  
GO  
```  
  
### E. Creating a login from a Windows domain account  
 The following example creates a login from a Windows domain account. 
  
**Applies to**: [!INCLUDE[ssKatmai](../../includes/sskatmai-md.md)] through [!INCLUDE[ssCurrent](../../includes/sscurrent-md.md)]. 
  
```sql  
CREATE LOGIN [<domainName>\<login_name>] FROM WINDOWS;  
GO  
```  
  
### F. Creating a login from a SID  
 The following example first creates a SQL Server authentication login and determines the SID of the login. 
  
```sql  
CREATE LOGIN TestLogin WITH PASSWORD = 'SuperSecret52&&';  
  
SELECT name, sid FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
 My query returns 0x241C11948AEEB749B0D22646DB1A19F2 as the SID. Your query will return a different value. The following statements delete the login, and then recreate the login. Use the SID from your previous query. 
  
```sql  
DROP LOGIN TestLogin;  
GO  
  
CREATE LOGIN TestLogin   
WITH PASSWORD = 'SuperSecret52&&', SID = 0x241C11948AEEB749B0D22646DB1A19F2;  
  
SELECT * FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
## See Also  
- [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md)   
- [Principals &#40;Database Engine&#41;](../../relational-databases/security/authentication-access/principals-database-engine.md)   
- [Password Policy](../../relational-databases/security/password-policy.md)   
- [ALTER LOGIN](../../t-sql/statements/alter-login-transact-sql.md)   
- [DROP LOGIN](../../t-sql/statements/drop-login-transact-sql.md)   
- [EVENTDATA](../../t-sql/functions/eventdata-transact-sql.md)   
- [Create a Login](../../relational-databases/security/authentication-access/create-a-login.md)  
  
::: moniker-end
::: moniker range="=azuresqldb-current||=sqlallproducts-allversions"

> [!div class="mx-tdCol2BreakAll"]
> ||||||
> |-|-|-|-|-|
> |[SQL Server](create-login-transact-sql.md?view=sql-server-2016)|**_\* SQL Database<br />logical server \*_**|[SQL Database<br />Managed Instance](create-login-transact-sql.md?view=azuresqldb-mi-current)|[SQL Data<br />Warehouse](create-login-transact-sql.md?view=azure-sqldw-latest)|[Parallel<br />Data Warehouse](create-login-transact-sql.md?view=aps-pdw-2016)

&nbsp;

## Azure SQL Database logical server
  
## Syntax 
  
```
-- Syntax for Azure SQL Database  
CREATE LOGIN login_name  
 { WITH <option_list> }  
  
<option_list> ::=   
    PASSWORD = { 'password' }  
    [ , SID = sid ]  
```  

## Arguments  
*login_name*  
Specifies the name of the login that is created. Azure SQL Database logical server supports only SQL logins. 

PASSWORD **='**password**'*  
Specifies the password for the SQL login that is being created. You should use a strong password. For more information, see [Strong Passwords](../../relational-databases/security/strong-passwords.md) and [Password Policy](../../relational-databases/security/password-policy.md). Beginning with [!INCLUDE[ssSQL11](../../includes/sssql11-md.md)], stored password information is calculated using SHA-512 of the salted password. 
  
Passwords are case-sensitive. Passwords should always be at least 8 characters long, and cannot exceed 128 characters. Passwords can include a-z, A-Z, 0-9, and most non-alphanumeric characters. Passwords cannot contain single quotes, or the *login_name*. 

SID = *sid*  
Used to recreate a login. Applies to SQL Server authentication logins only, not Windows authentication logins. Specifies the SID of the new SQL Server authentication login. If this option is not used, SQL Server automatically assigns a SID. The SID structure depends on the SQL Server version. For SQL Database, this is a 32 byte (**binary(32)**) literal consisting of `0x01060000000000640000000000000000` plus 16 bytes representing a GUID. For example, `SID = 0x0106000000000064000000000000000014585E90117152449347750164BA00A7`. 
  
## Remarks  
- Passwords are case-sensitive.
- For a script to transfer logins, see [How to transfer the logins and the passwords between instances of SQL Server 2005 and SQL Server 2008](http://support.microsoft.com/kb/918992).
- Creating a login automatically enables the new login and grants the login the server level **CONNECT SQL** permission. 
- The server's [authentication mode](../../relational-databases/security/choose-an-authentication-mode.md) must match the login type to permit access.
    - For information about designing a permissions system, see [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md).
  
## Login

### SQL Database Logins
The **CREATE LOGIN** statement must be the only statement in a batch. 
  
In some methods of connecting to SQL Database, such as **sqlcmd**, you must append the SQL Database server name to the login name in the connection string by using the *\<login>*@*\<server>* notation. For example, if your login is `login1` and the fully qualified name of the SQL Database server is `servername.database.windows.net`, the *username* parameter of the connection string should be `login1@servername`. Because the total length of the *username* parameter is 128 characters, *login_name* is limited to 127 characters minus the length of the server name. In the example, `login_name` can only be 117 characters long because `servername` is 10 characters. 
  
In SQL Database, you must be connected to the master database to create a login. 
  
 SQL Server rules allow you create a SQL Server authentication login in the format \<loginname>@\<servername>. If your [!INCLUDE[ssSDS](../../includes/sssds-md.md)] server is **myazureserver** and your login is **myemail@live.com**, then you must supply your login as **myemail@live.com@myazureserver**. 
  
In SQL Database, login data required to authenticate a connection and server-level firewall rules is temporarily cached in each database. This cache is periodically refreshed. To force a refresh of the authentication cache and make sure that a database has the latest version of the logins table, execute [DBCC FLUSHAUTHCACHE](../../t-sql/database-console-commands/dbcc-flushauthcache-transact-sql.md). 
  
 For more information about SQL Database logins, see [Managing Databases and Logins in Windows Azure SQL Database](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins). 
 
## Permissions

Only the server-level principal login (created by the provisioning process) or members of the `loginmanager` database role in the master database can create new logins. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles.

## Logins
- Must have **ALTER ANY LOGIN** permission on the server or membership in the **securityadmin** fixed server role. Only Azure Active Directory (Azure AD) account with **ALTER ANY LOGIN** permission on the server or membership in the securityadmin  permission can execute this command
- Must be a member of Azure AD within the same directory used for Azure SQL logical server
  
## After creating a login  
After creating a login, the login can connect to SQL Database but only has the permissions granted to the **public** role. Consider performing some of the following activities. 
  
- To connect to a database, create a database user for the login in that database. For more information, see [CREATE USER](../../t-sql/statements/create-user-transact-sql.md). 
- To grant permissions to a user in a database, use the **ALTER SERVER ROLE** … **ADD MEMBER** statement to add the use to one of the built-in database roles or a custom role, or grant permissions to the user directly using the [GRANT](../../t-sql/statements/grant-transact-sql.md) statement. For more information, see [Non-admistrator Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#non-administrator-users), [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles, and [GRANT](grant-transact-sql.md) statement.
- To grant server-wide permissions, create a database user in the master database and use the **ALTER SERVER ROLE** … **ADD MEMBER** statement to add the use to one of the administrative server roles. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md), and [Server roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles).
- Use the **GRANT** statement, to grant server-level permissions to the new login or to a role containing the login. For more information, see [GRANT](../../t-sql/statements/grant-transact-sql.md).
  
## Examples  
  
### A. Creating a login with a password  
 The following example creates a login for a particular user and assigns a password. 
  
```sql  
CREATE LOGIN <login_name> WITH PASSWORD = '<enterStrongPasswordHere>';  
GO  
```  
  
### B. Creating a login from a SID  
 The following example first creates a SQL Server authentication login and determines the SID of the login. 
  
```sql  
CREATE LOGIN TestLogin WITH PASSWORD = 'SuperSecret52&&';  
  
SELECT name, sid FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
 My query returns 0x241C11948AEEB749B0D22646DB1A19F2 as the SID. Your query will return a different value. The following statements delete the login, and then recreate the login. Use the SID from your previous query. 
  
```sql  
DROP LOGIN TestLogin;  
GO  
  
CREATE LOGIN TestLogin   
WITH PASSWORD = 'SuperSecret52&&', SID = 0x241C11948AEEB749B0D22646DB1A19F2;  
  
SELECT * FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
## See Also  
 [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md)   
 [Principals &#40;Database Engine&#41;](../../relational-databases/security/authentication-access/principals-database-engine.md)   
 [Password Policy](../../relational-databases/security/password-policy.md)   
 [ALTER LOGIN](../../t-sql/statements/alter-login-transact-sql.md)   
 [DROP LOGIN](../../t-sql/statements/drop-login-transact-sql.md)   
 [EVENTDATA](../../t-sql/functions/eventdata-transact-sql.md)   
 [Create a Login](../../relational-databases/security/authentication-access/create-a-login.md)  

::: moniker-end
::: moniker range="=azuresqldb-mi-current||=sqlallproducts-allversions"

> [!div class="mx-tdCol2BreakAll"]
> ||||||
> |-|-|-|-|-|
> |[SQL Server](create-login-transact-sql.md?view=sql-server-2016)|[SQL Database<br />logical server](create-login-transact-sql.md?view=azuresqldb-current)|**_\* SQL Database<br />Managed Instance \*_**|[SQL Data<br />Warehouse](create-login-transact-sql.md?view=azure-sqldw-latest)|[Parallel<br />Data Warehouse](create-login-transact-sql.md?view=aps-pdw-2016)

&nbsp;

## Azure SQL Database Managed Instance

## Overview

## Syntax 
  
```sql
-- Syntax for Azure SQL Database  
CREATE LOGIN login_name  
 { WITH <option_list> }  
  
<option_list> ::=   
    PASSWORD = { 'password' }  
    [ , SID = sid ]  
```  

## Arguments  
*login_name*  
Specifies the name of the login that is created. Azure SQL Database managed instance supports only SQL logins. 

PASSWORD **='**password**'*  
Specifies the password for the SQL login that is being created. You should use a strong password. For more information, see [Strong Passwords](../../relational-databases/security/strong-passwords.md) and [Password Policy](../../relational-databases/security/password-policy.md). Beginning with [!INCLUDE[ssSQL11](../../includes/sssql11-md.md)], stored password information is calculated using SHA-512 of the salted password. 
  
Passwords are case-sensitive. Passwords should always be at least 8 characters long, and cannot exceed 128 characters. Passwords can include a-z, A-Z, 0-9, and most non-alphanumeric characters. Passwords cannot contain single quotes, or the *login_name*. 

SID = *sid*  
Used to recreate a login. Applies to SQL Server authentication logins only, not Windows authentication logins. Specifies the SID of the new SQL Server authentication login. If this option is not used, SQL Server automatically assigns a SID. The SID structure depends on the SQL Server version. For SQL Database, this is a 32 byte (**binary(32)**) literal consisting of `0x01060000000000640000000000000000` plus 16 bytes representing a GUID. For example, `SID = 0x0106000000000064000000000000000014585E90117152449347750164BA00A7`. 
  
## Remarks  
- Passwords are case-sensitive.
- For a script to transfer logins, see [How to transfer the logins and the passwords between instances of SQL Server 2005 and SQL Server 2008](http://support.microsoft.com/kb/918992).
- Creating a login automatically enables the new login and grants the login the server level **CONNECT SQL** permission. 
- The server's [authentication mode](../../relational-databases/security/choose-an-authentication-mode.md) must match the login type to permit access.
    - For information about designing a permissions system, see [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md).
  
## Login

### SQL Database Logins
The **CREATE LOGIN** statement must be the only statement in a batch. 
  
In some methods of connecting to SQL Database, such as **sqlcmd**, you must append the SQL Database server name to the login name in the connection string by using the *\<login>*@*\<server>* notation. For example, if your login is `login1` and the fully qualified name of the SQL Database server is `servername.database.windows.net`, the *username* parameter of the connection string should be `login1@servername`. Because the total length of the *username* parameter is 128 characters, *login_name* is limited to 127 characters minus the length of the server name. In the example, `login_name` can only be 117 characters long because `servername` is 10 characters. 
  
In SQL Database, you must be connected to the master database to create a login. 
  
 SQL Server rules allow you create a SQL Server authentication login in the format \<loginname>@\<servername>. If your [!INCLUDE[ssSDS](../../includes/sssds-md.md)] server is **myazureserver** and your login is **myemail@live.com**, then you must supply your login as **myemail@live.com@myazureserver**. 
  
In SQL Database, login data required to authenticate a connection and server-level firewall rules is temporarily cached in each database. This cache is periodically refreshed. To force a refresh of the authentication cache and make sure that a database has the latest version of the logins table, execute [DBCC FLUSHAUTHCACHE](../../t-sql/database-console-commands/dbcc-flushauthcache-transact-sql.md). 
  
 For more information about SQL Database logins, see [Managing Databases and Logins in Windows Azure SQL Database](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins). 
 
## Permissions

Only the server-level principal login (created by the provisioning process) or members of the `loginmanager` database role in the master database can create new logins. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles.

## Logins
- Must have **ALTER ANY LOGIN** permission on the server or membership in the **securityadmin** fixed server role. Only Azure Active Directory (Azure AD) account with **ALTER ANY LOGIN** permission on the server or membership in the securityadmin  permission can execute this command
- Must be a member of Azure AD within the same directory used for Azure SQL logical server
  
## After creating a login  
After creating a login, the login can connect to SQL Database but only has the permissions granted to the **public** role. Consider performing some of the following activities. 
  
- To connect to a database, create a database user for the login in that database. For more information, see [CREATE USER](../../t-sql/statements/create-user-transact-sql.md). 
- To grant permissions to a user in a database, use the **ALTER SERVER ROLE** … **ADD MEMBER** statement to add the use to one of the built-in database roles or a custom role, or grant permissions to the user directly using the [GRANT](../../t-sql/statements/grant-transact-sql.md) statement. For more information, see [Non-admistrator Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#non-administrator-users), [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles, and [GRANT](grant-transact-sql.md) statement.
- To grant server-wide permissions, create a database user in the master database and use the **ALTER SERVER ROLE** … **ADD MEMBER** statement to add the use to one of the administrative server roles. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md), and [Server roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles).
- Use the **GRANT** statement, to grant server-level permissions to the new login or to a role containing the login. For more information, see [GRANT](../../t-sql/statements/grant-transact-sql.md).
  
## Examples  
  
### A. Creating a login with a password  
 The following example creates a login for a particular user and assigns a password. 
  
```sql  
CREATE LOGIN <login_name> WITH PASSWORD = '<enterStrongPasswordHere>';  
GO  
```  
  
### B. Creating a login from a SID  
 The following example first creates a SQL Server authentication login and determines the SID of the login. 
  
```sql  
CREATE LOGIN TestLogin WITH PASSWORD = 'SuperSecret52&&';  
  
SELECT name, sid FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
 My query returns 0x241C11948AEEB749B0D22646DB1A19F2 as the SID. Your query will return a different value. The following statements delete the login, and then recreate the login. Use the SID from your previous query. 
  
```sql  
DROP LOGIN TestLogin;  
GO  
  
CREATE LOGIN TestLogin   
WITH PASSWORD = 'SuperSecret52&&', SID = 0x241C11948AEEB749B0D22646DB1A19F2;  
  
SELECT * FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
## See Also  
 [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md)   
 [Principals &#40;Database Engine&#41;](../../relational-databases/security/authentication-access/principals-database-engine.md)   
 [Password Policy](../../relational-databases/security/password-policy.md)   
 [ALTER LOGIN](../../t-sql/statements/alter-login-transact-sql.md)   
 [DROP LOGIN](../../t-sql/statements/drop-login-transact-sql.md)   
 [EVENTDATA](../../t-sql/functions/eventdata-transact-sql.md)   
 [Create a Login](../../relational-databases/security/authentication-access/create-a-login.md)  


  
::: moniker-end
::: moniker range="=azure-sqldw-latest||=sqlallproducts-allversions"

> [!div class="mx-tdCol2BreakAll"]
> ||||||
> |-|-|-|-|-|
> |[SQL Server](create-login-transact-sql.md?view=sql-server-2016)|[SQL Database<br />logical server](create-login-transact-sql.md?view=azuresqldb-current)|[SQL Database<br />Managed Instance]()|**_\* SQL Data<br />Warehouse \*_**|[Parallel<br />Data Warehouse](create-login-transact-sql.md?view=aps-pdw-2016)

&nbsp;

## Azure SQL Data Warehouse
  
## Syntax 
  
```
-- Syntax for Azure SQL Data Warehouse  
CREATE LOGIN login_name  
 { WITH <option_list> }  
  
<option_list> ::=   
    PASSWORD = { 'password' }  
    [ , SID = sid ]  
```  
  
## Arguments  
*login_name*  
Specifies the name of the login that is created. Azure SQL Database supports only SQL logins. 

PASSWORD **='**password**'*  
Specifies the password for the SQL login that is being created. You should use a strong password. For more information, see [Strong Passwords](../../relational-databases/security/strong-passwords.md) and [Password Policy](../../relational-databases/security/password-policy.md). Beginning with [!INCLUDE[ssSQL11](../../includes/sssql11-md.md)], stored password information is calculated using SHA-512 of the salted password. 
  
Passwords are case-sensitive. Passwords should always be at least 8 characters long, and cannot exceed 128 characters. Passwords can include a-z, A-Z, 0-9, and most non-alphanumeric characters. Passwords cannot contain single quotes, or the *login_name*. 

 SID = *sid*  
 Used to recreate a login. Applies to SQL Server authentication logins only, not Windows authentication logins. Specifies the SID of the new SQL Server authentication login. If this option is not used, SQL Server automatically assigns a SID. The SID structure depends on the SQL Server version. For SQL Data Warehouse, this is a 32 byte (**binary(32)**) literal consisting of `0x01060000000000640000000000000000` plus 16 bytes representing a GUID. For example, `SID = 0x0106000000000064000000000000000014585E90117152449347750164BA00A7`. 
  
## Remarks  
- Passwords are case-sensitive.
- For a script to transfer logins, see [How to transfer the logins and the passwords between instances of SQL Server 2005 and SQL Server 2008](http://support.microsoft.com/kb/918992).
- Creating a login automatically enables the new login and grants the login the server level **CONNECT SQL** permission. 
- The server's [authentication mode](../../relational-databases/security/choose-an-authentication-mode.md) must match the login type to permit access.
    - For information about designing a permissions system, see [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md).
  
## Logins

The **CREATE LOGIN** statement must be the only statement in a batch. 
  
In some methods of connecting to SQL Data Warehouse, such as **sqlcmd**, you must append the SQL Data Warehouse server name to the login name in the connection string by using the *\<login>*@*\<server>* notation. For example, if your login is `login1` and the fully qualified name of the SQL Data Warehouse server is `servername.database.windows.net`, the *username* parameter of the connection string should be `login1@servername`. Because the total length of the *username* parameter is 128 characters, *login_name* is limited to 127 characters minus the length of the server name. In the example, `login_name` can only be 117 characters long because `servername` is 10 characters. 
  
In SQL Data Warehouse, you must be connected to the master database to create a login. 
  
 SQL Server rules allow you create a SQL Server authentication login in the format \<loginname>@\<servername>. If your [!INCLUDE[ssSDS](../../includes/sssds-md.md)] server is **myazureserver** and your login is **myemail@live.com**, then you must supply your login as **myemail@live.com@myazureserver**. 
  
In SQL Data Warehouse, login data required to authenticate a connection and server-level firewall rules is temporarily cached in each database. This cache is periodically refreshed. To force a refresh of the authentication cache and make sure that a database has the latest version of the logins table, execute [DBCC FLUSHAUTHCACHE](../../t-sql/database-console-commands/dbcc-flushauthcache-transact-sql.md). 
  
 For more information about SQL Data Warehouse logins, see [Managing Databases and Logins in Windows Azure SQL Database](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins). 
 
## Permissions

Only the server-level principal login (created by the provisioning process) or members of the `loginmanager` database role in the master database can create new logins. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles.

## After creating a login  
After creating a login, the login can connect to SQL Data Warehouse but only has the permissions granted to the **public** role. Consider performing some of the following activities. 
  
- To connect to a database, create a database user for the login. For more information, see [CREATE USER](../../t-sql/statements/create-user-transact-sql.md).
- To grant permissions to a user in a database, use the **ALTER SERVER ROLE** … **ADD MEMBER** statement to add the use to one of the built-in database roles or a custom role, or grant permissions to the user directly using the [GRANT](grant-transact-sql.md) statement. For more information, see [Non-admistrator Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#non-administrator-users), [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles, and [GRANT](grant-transact-sql.md) statement.
- To grant server-wide permissions, create a database user in the master database and use the **ALTER SERVER ROLE** … **ADD MEMBER** statement to add the use to one of the administrative server roles. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md), and [Server roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles).

- Use the **GRANT** statement, to grant server-level permissions to the new login or to a role containing the login. For more information, see [GRANT](../../t-sql/statements/grant-transact-sql.md). 
  
## Examples  
  
### A. Creating a login with a password  
The following example creates a login for a particular user and assigns a password. 
  
```sql  
CREATE LOGIN <login_name> WITH PASSWORD = '<enterStrongPasswordHere>';  
GO  
```  

### B. Creating a login from a SID  
 The following example first creates a SQL Server authentication login and determines the SID of the login. 
  
```sql  
CREATE LOGIN TestLogin WITH PASSWORD = 'SuperSecret52&&';  
  
SELECT name, sid FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
 My query returns 0x241C11948AEEB749B0D22646DB1A19F2 as the SID. Your query will return a different value. The following statements delete the login, and then recreate the login. Use the SID from your previous query. 
  
```sql  
DROP LOGIN TestLogin;  
GO  
  
CREATE LOGIN TestLogin   
WITH PASSWORD = 'SuperSecret52&&', SID = 0x241C11948AEEB749B0D22646DB1A19F2;  
  
SELECT * FROM sys.sql_logins WHERE name = 'TestLogin';  
GO  
```  
  
## See Also  
 [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md)   
 [Principals &#40;Database Engine&#41;](../../relational-databases/security/authentication-access/principals-database-engine.md)   
 [Password Policy](../../relational-databases/security/password-policy.md)   
 [ALTER LOGIN](../../t-sql/statements/alter-login-transact-sql.md)   
 [DROP LOGIN](../../t-sql/statements/drop-login-transact-sql.md)   
 [EVENTDATA](../../t-sql/functions/eventdata-transact-sql.md)   
 [Create a Login](../../relational-databases/security/authentication-access/create-a-login.md)  
  
::: moniker-end
::: moniker range=">=aps-pdw-2016||=sqlallproducts-allversions"

> [!div class="mx-tdCol2BreakAll"]
> ||||||
> |-|-|-|-|-|
> |[SQL Server](create-login-transact-sql.md?view=sql-server-2016)|[SQL Database<br />logical server](create-login-transact-sql.md?view=azuresqldb-current)|[SQL Database<br />Managed Instance]()|[SQL Data<br />Warehouse](create-login-transact-sql.md?view=azure-sqldw-latest)|**_\* Parallel<br />Data Warehouse \*_**

&nbsp;

## Parallel Data Warehouse

  
## Syntax 
  
```
-- Syntax for Parallel Data Warehouse  
CREATE LOGIN loginName { WITH <option_list1> | FROM WINDOWS }  
  
<option_list1> ::=   
    PASSWORD = { 'password' } [ MUST_CHANGE ]  
    [ , <option_list> [ ,... ] ]  
  
<option_list> ::=    
      CHECK_EXPIRATION = { ON | OFF}  
    | CHECK_POLICY = { ON | OFF}  
```  

## Arguments  
*login_name*  
Specifies the name of the login that is created. There are four types of logins: SQL Server logins, Windows logins, certificate-mapped logins, and asymmetric key-mapped logins. When you are creating logins that are mapped from a Windows domain account, you must use the pre-Windows 2000 user logon name in the format [\<domainName>\\<login_name>]. You cannot use a UPN in the format login_name@DomainName. For an example, see example D later in this article. Authentication logins are type **sysname** and must conform to the rules for [Identifiers](../../relational-databases/databases/database-identifiers.md) and cannot contain a '**\\**'. Windows logins can contain a '**\\**'. Logins based on Active Directory users, are limited to names of less than 21 characters. 

PASSWORD **='**_password_**'*
Applies to SQL Server logins only. Specifies the password for the login that is being created. You should use a strong password. For more information, see [Strong Passwords](../../relational-databases/security/strong-passwords.md) and [Password Policy](../../relational-databases/security/password-policy.md). Beginning with  SQL Server 2012 (11.x),, stored password information is calculated using SHA-512 of the salted password. 
  
Passwords are case-sensitive. Passwords should always be at least 8 characters long, and cannot exceed 128 characters. Passwords can include a-z, A-Z, 0-9, and most non-alphanumeric characters. Passwords cannot contain single quotes, or the *login_name*. 
  
MUST_CHANGE
Applies to SQL Server logins only. If this option is included, SQL Server prompts the user for a new password the first time the new login is used. 
  
CHECK_EXPIRATION **=** { ON | **OFF** }  
Applies to SQL Server logins only. Specifies whether password expiration policy should be enforced on this login. The default value is OFF. 
  
CHECK_POLICY **=** { **ON** | OFF }  
Applies to SQL Server logins only. Specifies that the Windows password policies of the computer on which SQL Server is running should be enforced on this login. The default value is ON. 
  
If the Windows policy requires strong passwords, passwords must contain at least three of the following four characteristics:  
  
- An uppercase character (A-Z). 
- A lowercase character (a-z). 
- A digit (0-9). 
- One of the non-alphanumeric characters, such as a space, _, @, *, ^, %, !, $, #, or &. 
  
WINDOWS  
Specifies that the login be mapped to a Windows login. 
  
## Remarks  
- Passwords are case-sensitive.
- If MUST_CHANGE is specified, CHECK_EXPIRATION and CHECK_POLICY must be set to ON. Otherwise, the statement will fail.
- A combination of CHECK_POLICY = OFF and CHECK_EXPIRATION = ON is not supported.
- When CHECK_POLICY is set to OFF, *lockout_time* is reset and CHECK_EXPIRATION is set to OFF. 
  
> [!IMPORTANT]  
>  CHECK_EXPIRATION and CHECK_POLICY are only enforced on Windows Server 2003 and later. For more information, see [Password Policy](../../relational-databases/security/password-policy.md). 
  
- For a script to transfer logins, see [How to transfer the logins and the passwords between instances of SQL Server 2005 and SQL Server 2008](http://support.microsoft.com/kb/918992).
- Creating a login automatically enables the new login and grants the login the server level **CONNECT SQL** permission. 
- For information about designing a permissions system, see [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md).

## Permissions  
Only users with **ALTER ANY LOGIN** permission on the server or membership in the **securityadmin** fixed server role can create logins. For more information, see [Server-Level Roles](https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#groups-and-roles) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md).https://docs.microsoft.com/azure/sql-database/sql-database-manage-logins#additional-server-level-administrative-roles.
  
## After creating a login  
After creating a login, the login can connect to SQL Data Warehouse, but only has the permissions granted to the **public** role. Consider performing some of the following activities. 
  
 - To connect to a database, create a database user for the login. For more information, see [CREATE USER](../../t-sql/statements/create-user-transact-sql.md). 
  
 - Create a user-defined server role by using [CREATE SERVER ROLE](../../t-sql/statements/create-server-role-transact-sql.md). Use **ALTER SERVER ROLE** … **ADD MEMBER** to add the new login to the user-defined server role. For more information, see [CREATE SERVER ROLE](../../t-sql/statements/create-server-role-transact-sql.md) and [ALTER SERVER ROLE](../../t-sql/statements/alter-server-role-transact-sql.md). 
  
 - Use **sp_addsrvrolemember** to add the login to a fixed server role. For more information, see [Server-Level Roles](../../relational-databases/security/authentication-access/server-level-roles.md) and [sp_addsrvrolemember](../../relational-databases/system-stored-procedures/sp-addsrvrolemember-transact-sql.md). 
  
 - Use the **GRANT** statement, to grant server-level permissions to the new login or to a role containing the login. For more information, see [GRANT](../../t-sql/statements/grant-transact-sql.md). 
  
## Examples  
  
### G. Creating a SQL Server authentication login with a password  
 The following example creates the login `Mary7` with password `A2c3456`. 
  
```sql  
CREATE LOGIN Mary7 WITH PASSWORD = 'A2c3456$#' ;  
```  
  
### H. Using Options  
 The following example creates the login `Mary8` with password and some of the optional arguments. 
  
```sql  
CREATE LOGIN Mary8 WITH PASSWORD = 'A2c3456$#' MUST_CHANGE,  
CHECK_EXPIRATION = ON,  
CHECK_POLICY = ON;  
```  
  
### I. Creating a login from a Windows domain account  
 The following example creates a login from a Windows domain account named `Mary` in the `Contoso` domain. 
  
```sql  
CREATE LOGIN [Contoso\Mary] FROM WINDOWS;  
GO  
```  
  
## See Also  
 [Getting Started with Database Engine Permissions](../../relational-databases/security/authentication-access/getting-started-with-database-engine-permissions.md)   
 [Principals &#40;Database Engine&#41;](../../relational-databases/security/authentication-access/principals-database-engine.md)   
 [Password Policy](../../relational-databases/security/password-policy.md)   
 [ALTER LOGIN](../../t-sql/statements/alter-login-transact-sql.md)   
 [DROP LOGIN](../../t-sql/statements/drop-login-transact-sql.md)   
 [EVENTDATA](../../t-sql/functions/eventdata-transact-sql.md)   
 [Create a Login](../../relational-databases/security/authentication-access/create-a-login.md)  
  
---  

::: moniker-end

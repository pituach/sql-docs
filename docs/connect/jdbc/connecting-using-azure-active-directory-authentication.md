---
title: "Connecting using Azure Active Directory Authentication | Microsoft Docs"
ms.custom: ""
ms.date: "01/19/2018"
ms.reviewer: ""
ms.suite: "sql"
ms.tgt_pltfrm: ""
ms.prod: sql
ms.prod_service: connectivity
ms.technology: connectivity
ms.topic: conceptual
ms.assetid: 9c9d97be-de1d-412f-901d-5d9860c3df8c
caps.latest.revision: 11
author: MightyPen
ms.author: genemi
manager: craigg
---
# Connecting using Azure Active Directory Authentication

[!INCLUDE[Driver_JDBC_Download](../../includes/driver_jdbc_download.md)]

This article provides information on how to develop Java applications to use the Azure Active Directory authentication feature with Microsoft JDBC Driver 6.0 (or higher) for SQL Server.

You can use Azure Active Directory (AAD) authentication, which is a mechanism of connecting to Azure SQL Database v12 using identities in Azure Active Directory. Use Azure Active Directory authentication to centrally manage identities of database users and as an alternative to SQL Server authentication. The JDBC Driver allows you to specify your Azure Active Directory credentials in the JDBC connection string to connect to Azure SQL DB. For information on how to configure Azure Active Directory authentication visit [Connecting to SQL Database By Using Azure Active Directory Authentication](https://azure.microsoft.com/documentation/articles/sql-database-aad-authentication/). 

Two new connection properties have been added to support Azure Active Directory Authentication:
*	**authentication**:  Use this property to indicate which SQL authentication method to use for connection. Possible values are: **ActiveDirectoryIntegrated**, **ActiveDirectoryPassword**, **SqlPassword**, and the default **NotSpecified**.
	* Use 'authentication=ActiveDirectoryIntegrated' to connect to a SQL Database using integrated Windows authentication. To use this authentication mode, you need to federate the on-premise Active Directory Federation
Services (ADFS) with Azure AD in the cloud. Once this is set up as well as a Kerberos ticket, you can access Azure SQL DB without being prompted for credentials when you are logged in a domain joined machine. 
	* Use 'authentication=ActiveDirectoryPassword' to connect to a SQL Database using an Azure AD principal name and password.
	* Use 'authentication=SqlPassword' to connect to a SQL Server using userName/user and password properties.
	* Use 'authentication=NotSpecified' or leave it as default when none of these authentication methods are needed.

*	**accessToken**: Use this property to connect to a SQL database using an access token. accessToken can only be set using the Properties parameter of the getConnection() method in the DriverManager class. It cannot be used in the connection URL.  

For details see the authentication property on the [Setting the Connection Properties](../../connect/jdbc/setting-the-connection-properties.md) page.  


## Client Setup Requirements
Please make sure that the following components are installed on the client machine:
* Java 7 or above
*	Microsoft JDBC Driver 6.0 (or higher) for SQL Server
*	If you are using the access token-based authentication mode, you need [azure-activedirectory-library-for-java](https://github.com/AzureAD/azure-activedirectory-library-for-java) and its dependencies to run the examples from this article. For more information, see **Connecting using Access Token** section.
*	If you are using the ActiveDirectoryPassword authentication mode, you need [azure-activedirectory-library-for-java](https://github.com/AzureAD/azure-activedirectory-library-for-java) and its dependencies. For more information, see **Connecting using ActiveDirectoryPassword Authentication Mode** section.
*	If you are using the ActiveDirectoryIntegrated mode, you need azure-activedirectory-library-for-java and its dependencies. For more information, see **Connecting using ActiveDirectoryIntegrated Authentication Mode** section.
	
## Connecting using ActiveDirectoryIntegrated Authentication Mode
 With version 6.4, Microsoft JDBC Driver adds support for ActiveDirectoryIntegrated Authentication using a Kerberos ticket on multiple platforms (Windows/Linux and Mac).
See [Set Kerberos ticket on Windows, Linux And Mac](https://docs.microsoft.com/sql/connect/jdbc/connecting-using-azure-active-directory-authentication#set-kerberos-ticket-on-windows-linux-and-mac) for more details. Alternatively, on Windows, sqljdbc_auth.dll can also be used for ActiveDirectoryIntegrated Authentication with JDBC Driver.

> [!NOTE]
>  If you are using an older version of the driver, check this [link](../../connect/jdbc/feature-dependencies-of-microsoft-jdbc-driver-for-sql-server.md) for the respective dependencies that are required to use this authentication mode. 

The following example shows how to use 'authentication=ActiveDirectoryIntegrated' mode. Run this example on a domain joined machine that is federated with Azure Active Directory. A contained database user representing your Azure AD principal, or one of the groups, you belong to, must exist in the database and must have the CONNECT permission. 

Before building and running the example, on the client machine (on which, you want to run the example), download the [azure-activedirectory-library-for-java library](https://github.com/AzureAD/azure-activedirectory-library-for-java) and its dependencies, and include them in the Java build path

Replace the server/database name with your server/database name in the following lines before executing the example:

```
ds.setServerName("aad-managed-demo.database.windows.net"); // replace 'aad-managed-demo' with your server name
ds.setDatabaseName("demo"); // replace with your database name
```

The example to use ActiveDirectoryIntegrated authentication mode:
```
import java.sql.Connection;
import java.sql.ResultSet;
import com.microsoft.sqlserver.jdbc.SQLServerDataSource;

public class IntegratedExample {

	public static void main(String[] args) throws Exception {
		SQLServerDataSource ds = new SQLServerDataSource();

		ds.setServerName("aad-managed-demo.database.windows.net"); // Replace with your server name
		ds.setDatabaseName("demo"); // Replace with your database name
		ds.setAuthentication("ActiveDirectoryIntegrated");
		ds.setHostNameInCertificate("*.database.windows.net");

		Connection connection = ds.getConnection();

		ResultSet rs = connection.createStatement().executeQuery("SELECT SUSER_SNAME()");
		if(rs.next()){
			System.out.println("You have successfully logged on as: " + rs.getString(1));
		}
	}
}
```
Running this example on a client machine automatically uses your Kerberos ticket and no password is required. If a connection is established, you should see the following message:
```
You have successfully logged on as: <your domain user name>
```

### Set Kerberos ticket on Windows, Linux And Mac

You need to set up a Kerberos ticket linking your current user to a Windows domain account. A summary of key steps is included below.

#### Windows
JDK comes with `kinit` which you can use to get a TGT from KDC (Key Distribution Center) on a domain joined machine that is federated with Azure Active Directory.

##### Step 1: Ticket Granting Ticket retrieval
- **Run on**: Windows
- **Action**:
  - Use the command `kinit username@DOMAIN.COMPANY.COM` to get a TGT from KDC, then it will prompt you for your domain password.
  - Use `klist` to see the available tickets. If the kinit was successful, you should see a ticket from krbtgt/DOMAIN.COMPANY.COM@ DOMAIN.COMPANY.COM.

> [!NOTE]
>  You may need to specify a `.ini` file with `-Djava.security.krb5.conf` for your application to locate KDC.

#### Linux and Mac

##### Requirements
Access to a Windows domain-joined machine in order to query your Kerberos Domain Controller

##### Step 1: Find Kerberos KDC
- **Run on**: Windows command line
- **Action**: `nltest /dsgetdc:DOMAIN.COMPANY.COM` (where “DOMAIN.COMPANY.COM” maps to your domain’s name)
- **Sample Output**
  ```
  DC: \\co1-red-dc-33.domain.company.com
  Address: \\2111:4444:2111:33:1111:ecff:ffff:3333
  ...
  The command completed successfully
  ```
- **Information to extract**
  The DC name, in this case `co1-red-dc-33.domain.company.com`

##### Step 2: Configuring KDC in krb5.conf
- **Run on**: Linux/Mac
- **Action**: Edit the /etc/krb5.conf in an editor of your choice. Configure the following keys
  ```
  [libdefaults]
    default_realm = DOMAIN.COMPANY.COM
   
  [realms]
  DOMAIN.COMPANY.COM = {
     kdc = co1-red-dc-28.domain.company.com
  }
  ```
  Then save the krb5.conf file and exit

> [!NOTE]
>  Domain must be in ALL CAPS.

##### Step 3: Testing the Ticket Granting Ticket retrieval
- **Run on**: Linux/Mac
- **Action**:
  - Use the command `kinit username@DOMAIN.COMPANY.COM` to get a TGT from KDC, then it will prompt you for your domain password.
  - Use `klist` to see the available tickets. If the kinit was successful, you should see a ticket from krbtgt/DOMAIN.COMPANY.COM@ DOMAIN.COMPANY.COM.

## Connecting using ActiveDirectoryPassword Authentication Mode
The following example shows how to use 'authentication=ActiveDirectoryPassword' mode.

Before building and running the example:
1.	On the client machine (on which, you want to run the example), download the [azure-activedirectory-library-for-java library](https://github.com/AzureAD/azure-activedirectory-library-for-java) and its dependencies, and include them in the Java build path
2.	Locate the following lines of code and replace the server/database name with your server/database name.
	```
	ds.setServerName("aad-managed-demo.database.windows.net"); // replace 'aad-managed-demo' with your server name
	ds.setDatabaseName("demo"); // replace with your database name
	```
3.	Locate the following lines of code and replace user name, with the name of the Azure AD user you want to connect as.
	```
	ds.setUser("bob@cqclinic.onmicrosoft.com"); // replace with your user name
	ds.setPassword("password"); 	// replace with your password
	```

The example to use ActiveDirectoryPassword authentication mode:
```
import java.sql.Connection;
import java.sql.ResultSet;
import com.microsoft.sqlserver.jdbc.SQLServerDataSource;

public class UserPasswordExample {
	
	public static void main(String[] args) throws Exception{
		SQLServerDataSource ds = new SQLServerDataSource();
		
		ds.setServerName("aad-managed-demo.database.windows.net"); // Replace with your server name
		ds.setDatabaseName("demo"); // Replace with your database
		ds.setUser("bob@cqclinic.onmicrosoft.com"); // Replace with your user name
		ds.setPassword("password"); // Replace with your password
		ds.setAuthentication("ActiveDirectoryPassword");
		ds.setHostNameInCertificate("*.database.windows.net");
		
		Connection connection = ds.getConnection();
		
		ResultSet rs = connection.createStatement().executeQuery("SELECT SUSER_SNAME()");
		if(rs.next()){
			System.out.println("You have successfully logged on as: " + rs.getString(1));
		}
	}
}
```
If connection is established, you should see the following message as output:
```
You have successfully logged on as: <your user name>
```

> [!NOTE]  
> A contained user database must exist and a contained database user representing the specified Azure AD user or one of the groups, the specified Azure AD user belongs to, must exist in the database, and must have the CONNECT permission (except for Azure Active Directory server admin or group)


## Connecting using Access Token
Applications/services can retrieve an access token from the Azure Active Directory and use that to connect to SQL Azure Database. Note that accessToken can only be set using the Properties parameter of the getConnection() method in the DriverManager class. It cannot be used in the connection string.
 
The example below contains a simple Java application that connects to Azure SQL Database using access token-based authentication. Before building and running the example, perform the following steps:
1.	Create an application account in Azure Active Directory for your service.
	1. Sign in to the Azure management portal
	2. Click on Azure Active Directory in the left hand navigation
	3. Click the "App registrations" tab.
	4. In the drawer, click "New application registration".
	5. Enter mytokentest as a friendly name for the application, select "Web App/API".
	6. We do not need SIGN-ON URL. Just provide anything: "http://mytokentest".
	7. Click "Create" at the bottom.
	9. While still in the Azure portal, click the "Settings" tab of your application, and open the "Properties" tab.
	10. Find the "Application ID" (AKA Client ID) value and copy it aside, you need this later when configuring your application (for example, 1846943b-ad04-4808-aa13-4702d908b5c1). See the following snapshot.
	11. Under section “Keys”, create a key by filling in the name field, selecting the duration of the key, and saving the configuration (leave the value field empty). After saving, the value field should be filled automatically, copy the generated value. This is the client Secret.
	12. Click Azure Active Directory on the left side panel. Under "App Registrations", find the "End points" tab. Copy the URL under "OATH 2.0 TOKEN ENDPOINT", this is your STS URL.
	
	![JDBC_AAD_Token](../../connect/jdbc/media/jdbc_aad_token.png)  
2. Log on to your Azure SQL Server’s user database as an Azure Active Directory admin and using a T-SQL command
provision a contained database user for your application principal. See the [Connecting to SQL Database or SQL Data Warehouse By Using Azure Active Directory Authentication](https://azure.microsoft.com/documentation/articles/sql-database-aad-authentication/)
 for more details on how to create an Azure Active Directory admin and a contained database user.

	```
	CREATE USER [mytokentest] FROM EXTERNAL PROVIDER
	```

3.	On the client machine (on which, you want to run the example), download the [azure-activedirectory-library-for-java](https://github.com/AzureAD/azure-activedirectory-library-for-java) library and its dependencies, and include them in the Java build path. Note that the azure-activedirectory-library-for-java is only needed to run this specific example as it uses the APIs from this library to retrieve the access token from Azure AD. If you already have an access token, you can skip this step. Note that you also need to remove the section in the example that retrieves access token.

In the following example, replace the STS URL, Client ID, Client Secret, server and database name with your values.

```
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import com.microsoft.sqlserver.jdbc.SQLServerDataSource;

// The azure-activedirectory-library-for-java is needed to retrieve the access token from the AD. 
import com.microsoft.aad.adal4j.AuthenticationContext;
import com.microsoft.aad.adal4j.AuthenticationResult;
import com.microsoft.aad.adal4j.ClientCredential;


public class TokenBasedExample {

	public static void main(String[] args) throws Exception{

		// Retrieve the access token from the AD.
		String spn = "https://database.windows.net/";
		String stsurl = "https://login.microsoftonline.com/..."; // Replace with your STS URL.
		String clientId = "1846943b-ad04-4808-aa13-4702d908b5c1"; // Replace with your client ID.
		String clientSecret = "..."; // Replace with your client secret.

		AuthenticationContext context = new AuthenticationContext(stsurl, false, Executors.newFixedThreadPool(1));
		ClientCredential cred = new ClientCredential(clientId, clientSecret);

		Future<AuthenticationResult> future = context.acquireToken(spn, cred, null);
		String accessToken = future.get().getAccessToken();

		System.out.println("Access Token: " + accessToken);		
		
		// Connect with the access token.
		SQLServerDataSource ds = new SQLServerDataSource();

		ds.setServerName("aad-managed-demo.database.windows.net"); // Replace with your server name.
		ds.setDatabaseName("demo"); // Replace with your database name.
		ds.setAccessToken(accessToken);
		ds.setHostNameInCertificate("*.database.windows.net");

		Connection connection = ds.getConnection();

		ResultSet rs = connection.createStatement().executeQuery("SELECT SUSER_SNAME()");
		if(rs.next()){
			System.out.println("You have successfully logged on as: " + rs.getString(1));
		}
	}
}
``` 

If the connection is successful, you should see the following message as output:
```
Access Token: <your access token>
You have successfully logged on as: <your client ID>	
``` 

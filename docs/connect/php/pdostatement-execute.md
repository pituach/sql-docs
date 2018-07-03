---
title: "PDOStatement::execute | Microsoft Docs"
ms.custom: ""
ms.date: "05/22/2018"
ms.prod: sql
ms.prod_service: connectivity
ms.reviewer: ""
ms.suite: "sql"
ms.technology: connectivity
ms.tgt_pltfrm: ""
ms.topic: conceptual
ms.assetid: c2e80566-fa41-4918-8521-cf2e05374cbd
caps.latest.revision: 12
author: MightyPen
ms.author: genemi
manager: craigg
---
# PDOStatement::execute
[!INCLUDE[Driver_PHP_Download](../../includes/driver_php_download.md)]

Executes a statement.  
  
## Syntax  
  
```  
  
bool PDOStatement::execute ([ $input ] );  
```  
  
#### Parameters  
*$input*: (Optional) An associative array containing the values for parameter markers.  
  
## Return Value  
true on success, false otherwise.  
  
## Remarks  
Statements executed with PDOStatement::execute must first be prepared with [PDO::prepare](../../connect/php/pdo-prepare.md). See [Direct Statement Execution and Prepared Statement Execution in the PDO_SQLSRV Driver](../../connect/php/direct-statement-execution-prepared-statement-execution-pdo-sqlsrv-driver.md) for information on how to specify direct or prepared statement execution.  
  
All values of the input parameters array are treated as PDO::PARAM_STR values.  
  
If the prepared statement includes parameter markers, you must either call PDOStatement::bindParam to bind the PHP variables to the parameter markers or pass an array of input-only parameter values.  
  
Support for PDO was added in version 2.0 of the [!INCLUDE[ssDriverPHP](../../includes/ssdriverphp_md.md)].  
  
## Example  
  
```  
<?php  
$database = "AdventureWorks";  
$server = "(local)";  
$conn = new PDO( "sqlsrv:server=$server ; Database = $database", "", "");  
  
$query = "select * from Person.ContactType";  
$stmt = $conn->prepare( $query );  
$stmt->execute();  
  
while ( $row = $stmt->fetch( PDO::FETCH_ASSOC ) ){  
   print "$row[Name]\n";  
}  
  
echo "\n";  
$param = "Owner";  
$query = "select * from Person.ContactType where name = ?";  
$stmt = $conn->prepare( $query );  
$stmt->execute(array($param));  
  
while ( $row = $stmt->fetch( PDO::FETCH_ASSOC ) ){  
   print "$row[Name]\n";  
}  
?>  
```  
  
> [!NOTE]
> It is recommended to use strings as inputs when binding values to a [decimal or numeric column](../../t-sql/data-types/decimal-and-numeric-transact-sql.md) to ensure precision and accuracy as PHP has limited precision for [floating point numbers](http://php.net/manual/en/language.types.float.php). The same applies to bigint columns, especially when the values are outside the range of an [integer](../../t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql.md).

## See Also  
[PDOStatement Class](../../connect/php/pdostatement-class.md)

[PDO](http://php.net/manual/book.pdo.php)  
  

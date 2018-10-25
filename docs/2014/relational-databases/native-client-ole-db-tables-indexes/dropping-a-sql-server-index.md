---
title: "Dropping a SQL Server Index | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.technology: native-client
ms.topic: "reference"
helpviewer_keywords: 
  - "removing indexes"
  - "deleting indexes"
  - "DropIndex function"
  - "dropping indexes"
  - "SQL Server Native Client OLE DB provider, indexes"
  - "indexes [OLE DB]"
ms.assetid: add3ba14-10b1-4723-b7c0-3e83689e9fdd
author: MightyPen
ms.author: genemi
manager: craigg
---
# Dropping a SQL Server Index
  The [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Native Client OLE DB provider exposes the **IIndexDefinition::DropIndex** function. This allows consumers to remove an index from a [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] table.  
  
 The [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Native Client OLE DB provider exposes some [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] PRIMARY KEY and UNIQUE constraints as indexes. The table owner, database owner, and some administrative role members can modify a [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] table, dropping a constraint. By default, only the table owner can drop an existing index. Therefore, **DropIndex** success or failure depends not only on the application user's access rights but also on the type of index indicated.  
  
 Consumers specify the table name as a Unicode character string in the *pwszName* member of the *uName* union in the *pTableID* parameter. The *eKind* member of *pTableID* must be DBKIND_NAME.  
  
 Consumers specify the index name as a Unicode character string in the *pwszName* member of the *uName* union in the *pIndexID* parameter. The *eKind* member of *pIndexID* must be DBKIND_NAME. The [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] Native Client OLE DB provider does not support the OLE DB feature of dropping all indexes on a table when *pIndexID* is null. If *pIndexID* is null, E_INVALIDARG is returned.  
  
## See Also  
 [Tables and Indexes](tables-and-indexes.md)   
 [ALTER TABLE &#40;Transact-SQL&#41;](/sql/t-sql/statements/alter-table-transact-sql)   
 [DROP INDEX &#40;Transact-SQL&#41;](/sql/t-sql/statements/drop-index-transact-sql)  
  
  

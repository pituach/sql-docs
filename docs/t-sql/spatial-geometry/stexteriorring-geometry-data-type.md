---
title: "STExteriorRing (geometry Data Type) | Microsoft Docs"
ms.custom: ""
ms.date: "08/03/2017"
ms.prod: sql
ms.prod_service: "database-engine, sql-database"
ms.reviewer: ""
ms.suite: "sql"
ms.technology: t-sql
ms.tgt_pltfrm: ""
ms.topic: "language-reference"
f1_keywords: 
  - "STExteriorRing_TSQL"
  - "STExteriorRing (geometry Data Type)"
dev_langs: 
  - "TSQL"
helpviewer_keywords: 
  - "STExteriorRing (geometry Data Type)"
ms.assetid: b402b36f-05bf-4c6d-8cd6-76c0fff19db2
caps.latest.revision: 20
author: "douglaslMS"
ms.author: "douglasl"
manager: craigg
---
# STExteriorRing (geometry Data Type)
[!INCLUDE[tsql-appliesto-ss2008-asdb-xxxx-xxx-md](../../includes/tsql-appliesto-ss2008-asdb-xxxx-xxx-md.md)]

Returns the exterior ring of a **geometry** instance that is a polygon.
  
## Syntax  
  
```  
  
.STExteriorRing ( )  
```  
  
## Return Types  
 [!INCLUDE[ssNoVersion](../../includes/ssnoversion-md.md)] return type: **geometry**  
  
 CLR return type: **SqlGeometry**  
  
 Open Geospatial Consortium (OGC) type: **LineString**  
  
## Remarks  
 This method returns **null** if the **geometry** instance is not a polygon.  
  
## Examples  
 The following example creates a `Polygon` instance and uses `STExteriorRing()` to return the exterior ring of the polygon as a **LineString**.  
  
```  
DECLARE @g geometry;  
SET @g = geometry::STGeomFromText('POLYGON((0 0, 3 0, 3 3, 0 3, 0 0),(2 2, 2 1, 1 1, 1 2, 2 2))', 0);  
SELECT @g.STExteriorRing().ToString();  
```  
  
## See Also  
 [OGC Methods on Geometry Instances](../../t-sql/spatial-geometry/ogc-methods-on-geometry-instances.md)  
  
  


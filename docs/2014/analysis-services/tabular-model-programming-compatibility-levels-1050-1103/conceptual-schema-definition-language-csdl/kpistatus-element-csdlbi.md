---
title: "KpiStatus Element (CSDLBI) | Microsoft Docs"
ms.custom: ""
ms.date: "06/13/2017"
ms.prod: "sql-server-2014"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "analysis-services"
  - "docset-sql-devref"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 6fee5b82-caa8-46a1-ad68-bbce3e11e01e
caps.latest.revision: 11
author: minewiskan
ms.author: owend
manager: craigg
---
# KpiStatus Element (CSDLBI)
  The KpiStatus element defines a reference to the column that contains the value used as the status indicator in a Key Performance Indicator (KPI).  
  
## Elements and Attributes  
 The following table lists the elements and attributes that define the KpiStatus element.  
  
|Name|Is Required|Description|  
|----------|-----------------|-----------------|  
|PropertyRef|Yes|A reference to a column that contains the value used as the status indicator in a KPI.<br /><br /> This element MUST contain exactly one column reference, as defined by the TPropertyRefcomplex type.|  
  
## Example  
 **Tabular**  
  
 The following sample, in CSDLBI version 1.1, shows a KPI from the AdventureWorks tabular model sample. The KpiStatus element refers to a column (represented as a PropertyRef) that contains the value.  
  
```  
  
<Property Name="InternetCurrSalesPerf" Type="Double">  
   <bi:Measure>  
     <bi:Kpi StatusGraphic="Three Stars Colored">  
       <bi:KpiGoal>  
         <bi:PropertyRef Name="v_InternetCurrSalesPerf_Goal" />  
       </bi:KpiGoal>  
       <bi:KpiStatus>  
         <bi:PropertyRef Name="v_InternetCurrSalesPerf_Status" />  
       </bi:KpiStatus>  
     </bi:Kpi>  
   </bi:Measure>  
</Property>  
  
```  
  
## Example  
 **Multidimensional**  
  
 The following sample, in CSDLBI version 1.1, shows a KPI from the Contoso Operations cube. The KpiStatus element references a measure that calculates the value for the KPI status.  
  
```  
<bi:Measure   
       Caption="Sum of SalesAmount"   
       ReferenceName="Sum of SalesAmount"   
       FormatString="\$#,0.00;(\$#,0.00);\$#,0.00">  
  
    <bi:Kpi   
       StatusGraphic="Three Circles Colored">  
  
      <bi:KpiGoal>  
         <bi:PropertyRef   
          Name="v_Sum_of_SalesAmount_Goal" />  
       </bi:KpiGoal>  
  
       <bi:KpiStatus>  
          <bi:PropertyRef   
          Name="v_Sum_of_SalesAmount_Status" />  
        </bi:KpiStatus>  
  
       </bi:Kpi>  
</bi:Measure>  
  
```  
  
## See Also  
 [KPI Element &#40;CSDLBI&#41;](kpi-element-csdlbi.md)  
  
  

using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using FiratManagementSystemApi.Groups;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.StockInfos
{
    
    public class StockInfoWithNavigationPropertiesDto 
    {
    
        public StockInfoDto  StockInfo  {get; set;}
        
        public GroupDto Group { get; set; }
        
        public ApprovalTierDto ApprovalTier { get; set; }
        
       


        

        
       


        
    }
}

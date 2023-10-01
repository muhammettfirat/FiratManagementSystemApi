using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using FiratManagementSystemApi.AuditInfos;
using FiratManagementSystemApi.Groups;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.CompanyInfos
{
    
    public class CompanyInfoWithNavigationPropertiesDto 
    {
    
        public CompanyInfoDto  CompanyInfo  {get; set;}
        
        public GroupDto Group { get; set; }
        
        public ApprovalTierDto ApprovalTier { get; set; }
        
       


        

        
       


        
    }
}

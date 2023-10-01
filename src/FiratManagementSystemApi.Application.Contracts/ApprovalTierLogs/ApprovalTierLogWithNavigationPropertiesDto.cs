using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using FiratManagementSystemApi.AuditInfos;
using FiratManagementSystemApi.TierAuthorizations;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.ApprovalTierLogs
{
    
    public class ApprovalTierLogWithNavigationPropertiesDto 
    {
    
        public ApprovalTierLogDto  ApprovalTierLog  {get; set;}
        
        public AuditInfoDto AuditInfo { get; set; }
        
        public TierAuthorizationDto TierAuthorization { get; set; }
        
        public ApprovalTierDto ApprovalTier { get; set; }
        
       


        

        
       


        
    }
}

using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using FiratManagementSystemApi.ApprovalTierLogs;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.TierAuthorizations
{
    
    public class TierAuthorizationWithNavigationPropertiesDto 
    {
    
        public TierAuthorizationDto  TierAuthorization  {get; set;}
        
        public ApprovalTierDto ApprovalTier { get; set; }
        
       


        

        
       


        
    }
}

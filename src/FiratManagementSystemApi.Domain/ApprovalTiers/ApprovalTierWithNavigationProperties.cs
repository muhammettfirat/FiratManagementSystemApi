using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using FiratManagementSystemApi.CompanyInfos;
using FiratManagementSystemApi.TierAuthorizations;
using FiratManagementSystemApi.ApprovalTierLogs;
using FiratManagementSystemApi.StockInfos;

namespace FiratManagementSystemApi.ApprovalTiers
{
    
    public class ApprovalTierWithNavigationProperties 
    {
    
        public ApprovalTier  ApprovalTier  {get; set;}
        
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        

        
       


        
    }
}

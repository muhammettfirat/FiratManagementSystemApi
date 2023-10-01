using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
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
    
    public class CompanyInfoWithNavigationProperties 
    {
    
        public CompanyInfo  CompanyInfo  {get; set;}
        
        public Group Group { get; set; }
        
        public ApprovalTier ApprovalTier { get; set; }
        
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        

        
       


        
    }
}

using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using FiratManagementSystemApi.ApprovalTierLogs;
using FiratManagementSystemApi.CompanyInfos;

namespace FiratManagementSystemApi.AuditInfos
{
    
    public class AuditInfoWithNavigationProperties 
    {
    
        public AuditInfo  AuditInfo  {get; set;}
        
        public CompanyInfo CompanyInfo { get; set; }
        
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        

        
       


        
    }
}

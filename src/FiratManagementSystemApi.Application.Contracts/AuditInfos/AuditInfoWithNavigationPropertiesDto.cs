using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using FiratManagementSystemApi.ApprovalTierLogs;
using FiratManagementSystemApi.CompanyInfos;

namespace FiratManagementSystemApi.AuditInfos
{
    
    public class AuditInfoWithNavigationPropertiesDto 
    {
    
        public AuditInfoDto  AuditInfo  {get; set;}
        
        public CompanyInfoDto CompanyInfo { get; set; }
        
       


        

        
       


        
    }
}

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

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace FiratManagementSystemApi.CompanyInfos
{
    
    public  class CompanyInfo : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public UNKNOWN_TYPE CustomerType { get; set; }
        public UNKNOWN_TYPE CustomerCode { get; set; }
        public DateTime StartedWorkingDate { get; set; }
        public DateTime AuditPeriodMonth { get; set; }
        [StringLength(50,MinimumLength=1)]
        public string ApprovalStatus { get; set; }
        
        public Guid? GroupId { get; set; }    
        public Guid? ApprovalTierId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public CompanyInfo()
        {

        }

        
        public CompanyInfo
        (
            Guid id
          ,string approvalStatus 
          ,DateTime startedWorkingDate  
          ,DateTime auditPeriodMonth  
          ,Guid? groupId
          ,Guid? approvalTierId
            

        )


        {
               Id = id;
                ApprovalStatus=approvalStatus;
                StartedWorkingDate=startedWorkingDate;         
                AuditPeriodMonth=auditPeriodMonth;         
                GroupId=groupId;
                ApprovalTierId=approvalTierId;

        }


        
    }
}

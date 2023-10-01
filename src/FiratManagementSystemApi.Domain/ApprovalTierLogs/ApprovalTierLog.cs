using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using FiratManagementSystemApi.AuditInfos;
using FiratManagementSystemApi.TierAuthorizations;
using FiratManagementSystemApi.ApprovalTiers;

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace FiratManagementSystemApi.ApprovalTierLogs
{
    
    public  class ApprovalTierLog : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public UNKNOWN_TYPE RelatedId { get; set; }
        [StringLength(1,MinimumLength=0)]
        public string RelatedFileType { get; set; }
        public DateTime AuditDate { get; set; }
        public UNKNOWN_TYPE ApprovalPersonnelId { get; set; }
        [StringLength(50,MinimumLength=1)]
        public string ApprovalStatus { get; set; }
        [StringLength(100,MinimumLength=1)]
        public string ApprovalTierName { get; set; }
        public DateTime OperationDate { get; set; }
        public Guid? AuditInfoId { get; set; }    
        public Guid? TierAuthorizationId { get; set; }    
        public Guid? ApprovalTierId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public ApprovalTierLog()
        {

        }

        
        public ApprovalTierLog
        (
            Guid id
          ,string relatedFileType 
          ,string approvalStatus 
          ,string approvalTierName 
          ,DateTime auditDate  
          ,DateTime operationDate  
          ,Guid? auditInfoId
          ,Guid? tierAuthorizationId
          ,Guid? approvalTierId
            

        )


        {
               Id = id;
                RelatedFileType=relatedFileType;
                ApprovalStatus=approvalStatus;
                ApprovalTierName=approvalTierName;
                AuditDate=auditDate;         
                OperationDate=operationDate;         
                AuditInfoId=auditInfoId;
                TierAuthorizationId=tierAuthorizationId;
                ApprovalTierId=approvalTierId;

        }


        
    }
}

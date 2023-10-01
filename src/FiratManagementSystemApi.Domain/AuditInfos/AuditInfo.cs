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

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace FiratManagementSystemApi.AuditInfos
{
    
    public  class AuditInfo : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public DateTime AuditDate { get; set; }
        public UNKNOWN_TYPE AuditPersonnel01 { get; set; }
        public UNKNOWN_TYPE AuditPersonnel02 { get; set; }
        public UNKNOWN_TYPE AuditPersonnel03 { get; set; }
        public UNKNOWN_TYPE AuditPersonnel04 { get; set; }
        [StringLength(100,MinimumLength=1)]
        public string CompanyPersonnel01 { get; set; }
        [StringLength(100,MinimumLength=1)]
        public string CompanyPersonnel02 { get; set; }
        [StringLength(100,MinimumLength=1)]
        public string CompanyPersonnel03 { get; set; }
        [StringLength(100,MinimumLength=1)]
        public string CompanyPersonnel04 { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string Description { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string DecisionTaken { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string AuditResultMissing { get; set; }
        [Range(0,1 )]
        public int? AuditEvaluationResult { get; set; }
        [StringLength(250,MinimumLength=1)]
        public string ExpectedDocument { get; set; }
        public int? Score { get; set; }
        
        public Guid? CompanyInfoId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public AuditInfo()
        {

        }

        
        public AuditInfo
        (
            Guid id
          ,string companyPersonnel01 
          ,string companyPersonnel02 
          ,string companyPersonnel03 
          ,string companyPersonnel04 
          ,string description 
          ,string decisionTaken 
          ,string auditResultMissing 
          ,string expectedDocument 
          ,DateTime auditDate  
          ,int? auditEvaluationResult

          ,int? score

          ,Guid? companyInfoId
            

        )


        {
               Id = id;
                CompanyPersonnel01=companyPersonnel01;
                CompanyPersonnel02=companyPersonnel02;
                CompanyPersonnel03=companyPersonnel03;
                CompanyPersonnel04=companyPersonnel04;
                Description=description;
                DecisionTaken=decisionTaken;
                AuditResultMissing=auditResultMissing;
                ExpectedDocument=expectedDocument;
                AuditDate=auditDate;         
                AuditEvaluationResult=auditEvaluationResult;
                Score=score;
                CompanyInfoId=companyInfoId;

        }


        
    }
}

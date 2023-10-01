using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


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

namespace FiratManagementSystemApi.StockInfos
{
    
    public  class StockInfo : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public UNKNOWN_TYPE RelatedTierID { get; set; }
        [StringLength(5,MinimumLength=1)]
        public string RelatedFile { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string ManufacturingLocationAddress { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string ManufacturersAddress { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string EvaluationDescription { get; set; }
        public DateTime EvaluationDate { get; set; }
        [Range(0,1 )]
        public int? AuditEvaluationResult { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string AuditResultMissing { get; set; }
        [StringLength(250,MinimumLength=1)]
        public string ExpectedDocument { get; set; }
        [StringLength(500,MinimumLength=1)]
        public string DecisionTaken { get; set; }
        [StringLength(50,MinimumLength=1)]
        public string ApprovalStatus { get; set; }
        public Guid? GroupId { get; set; }    
        public Guid? ApprovalTierId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public StockInfo()
        {

        }

        
        public StockInfo
        (
            Guid id
          ,string relatedFile 
          ,string manufacturingLocationAddress 
          ,string manufacturersAddress 
          ,string evaluationDescription 
          ,string auditResultMissing 
          ,string expectedDocument 
          ,string decisionTaken 
          ,string approvalStatus 
          ,DateTime evaluationDate  
          ,int? auditEvaluationResult

          ,Guid? groupId
          ,Guid? approvalTierId
            

        )


        {
               Id = id;
                RelatedFile=relatedFile;
                ManufacturingLocationAddress=manufacturingLocationAddress;
                ManufacturersAddress=manufacturersAddress;
                EvaluationDescription=evaluationDescription;
                AuditResultMissing=auditResultMissing;
                ExpectedDocument=expectedDocument;
                DecisionTaken=decisionTaken;
                ApprovalStatus=approvalStatus;
                EvaluationDate=evaluationDate;         
                AuditEvaluationResult=auditEvaluationResult;
                GroupId=groupId;
                ApprovalTierId=approvalTierId;

        }


        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using FiratManagementSystemApi.Groups;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.StockInfos
{

    public class StockInfoDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        public UNKNOWN_TYPE RelatedTierID { get; set; }
        public string RelatedFile { get; set; }
        public string ManufacturingLocationAddress { get; set; }
        public string ManufacturersAddress { get; set; }
        public string EvaluationDescription { get; set; }
        public DateTime EvaluationDate { get; set; }
        public int? AuditEvaluationResult { get; set; }
        public string AuditResultMissing { get; set; }
        public string ExpectedDocument { get; set; }
        public string DecisionTaken { get; set; }
        public string ApprovalStatus { get; set; }
        public Guid? GroupId { get; set; }
        
        public Guid? ApprovalTierId { get; set; }
        
        public string ConcurrencyStamp { get; set; }      
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}



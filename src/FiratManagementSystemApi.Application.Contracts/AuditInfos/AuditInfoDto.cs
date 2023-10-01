using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using FiratManagementSystemApi.CompanyInfos;

namespace FiratManagementSystemApi.AuditInfos
{

    public class AuditInfoDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        public DateTime AuditDate { get; set; }
        public UNKNOWN_TYPE AuditPersonnel01 { get; set; }
        public UNKNOWN_TYPE AuditPersonnel02 { get; set; }
        public UNKNOWN_TYPE AuditPersonnel03 { get; set; }
        public UNKNOWN_TYPE AuditPersonnel04 { get; set; }
        public string CompanyPersonnel01 { get; set; }
        public string CompanyPersonnel02 { get; set; }
        public string CompanyPersonnel03 { get; set; }
        public string CompanyPersonnel04 { get; set; }
        public string Description { get; set; }
        public string DecisionTaken { get; set; }
        public string AuditResultMissing { get; set; }
        public int? AuditEvaluationResult { get; set; }
        public string ExpectedDocument { get; set; }
        public int? Score { get; set; }
        public Guid? CompanyInfoId { get; set; }
        
        public string ConcurrencyStamp { get; set; }      
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}



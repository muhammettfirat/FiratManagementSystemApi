using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using FiratManagementSystemApi.Groups;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.CompanyInfos
{

    public class CompanyInfoDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        public UNKNOWN_TYPE CustomerType { get; set; }
        public UNKNOWN_TYPE CustomerCode { get; set; }
        public DateTime StartedWorkingDate { get; set; }
        public DateTime AuditPeriodMonth { get; set; }
        public string ApprovalStatus { get; set; }
        public Guid? GroupId { get; set; }
        
        public Guid? ApprovalTierId { get; set; }
        
        public string ConcurrencyStamp { get; set; }      
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}



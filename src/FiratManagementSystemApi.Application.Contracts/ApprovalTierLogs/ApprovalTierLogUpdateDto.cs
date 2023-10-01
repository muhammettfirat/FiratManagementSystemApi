using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using FiratManagementSystemApi.AuditInfos;
using FiratManagementSystemApi.TierAuthorizations;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.ApprovalTierLogs
{

    public class ApprovalTierLogUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public UNKNOWN_TYPE RelatedId { get; set; }
        public string RelatedFileType { get; set; }
        public DateTime AuditDate { get; set; }
        public UNKNOWN_TYPE ApprovalPersonnelId { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovalTierName { get; set; }
        public DateTime OperationDate { get; set; }
        public Guid? AuditInfoId { get; set; }
        
        public Guid? TierAuthorizationId { get; set; }
        
        public Guid? ApprovalTierId { get; set; }
        
        public string ConcurrencyStamp { get; set; }
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}



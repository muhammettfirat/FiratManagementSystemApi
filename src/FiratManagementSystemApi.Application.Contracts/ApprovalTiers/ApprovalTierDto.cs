using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FiratManagementSystemApi.ApprovalTiers
{

    public class ApprovalTierDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        [Required]
        public int? Code { get; set; }
        [Required]
        public string Definition { get; set; }
        public bool? FinalTiers { get; set; }
        public string ConcurrencyStamp { get; set; }      
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}



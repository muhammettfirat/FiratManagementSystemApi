using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FiratManagementSystemApi.DocumentTypes
{

    public class DocumentTypeDto:FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        
        [Required]
        public string Code { get; set; }
        [Required]
        public string Definition { get; set; }
        public string ConcurrencyStamp { get; set; }      
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}



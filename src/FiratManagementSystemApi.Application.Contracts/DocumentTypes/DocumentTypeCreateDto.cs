using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FiratManagementSystemApi.DocumentTypes
{

    public class DocumentTypeCreateDto
    {
        
        [Required]
        public string Code { get; set; }
        [Required]
        public string Definition { get; set; }
        
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove

       


        
        

    }
}



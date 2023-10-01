using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FiratManagementSystemApi.Groups
{

    public class GroupUpdateDto: IHasConcurrencyStamp
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Definition { get; set; }
        public string ConcurrencyStamp { get; set; }
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove




        
        

    }
}



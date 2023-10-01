using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using FiratManagementSystemApi.ApprovalTiers;

namespace FiratManagementSystemApi.TierAuthorizations
{

    public class TierAuthorizationCreateDto
    {
        
        public UNKNOWN_TYPE PersonnelId { get; set; }
        public string PersonnelName { get; set; }
        public string EmailInfo { get; set; }
        public Guid? ApprovalTierId { get; set; }
        
        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove

       


        
        

    }
}



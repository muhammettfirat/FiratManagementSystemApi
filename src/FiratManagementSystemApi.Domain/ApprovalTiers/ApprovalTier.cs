using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using FiratManagementSystemApi.CompanyInfos;
using FiratManagementSystemApi.TierAuthorizations;
using FiratManagementSystemApi.ApprovalTierLogs;
using FiratManagementSystemApi.StockInfos;

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace FiratManagementSystemApi.ApprovalTiers
{
    
    public  class ApprovalTier : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [Required]
        public int? Code { get; set; }
        [Required]
        [StringLength(100,MinimumLength=1)]
        public string Definition { get; set; }
        public bool? FinalTiers { get; set; }
        
        
        
        
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public ApprovalTier()
        {

        }

        
        public ApprovalTier
        (
            Guid id
          ,string definition 
          ,int? code

          ,bool? finalTiers
            

        )


        {
               Id = id;
                Definition=definition;
                Code=code;
                 FinalTiers=finalTiers; 

        }


        
    }
}

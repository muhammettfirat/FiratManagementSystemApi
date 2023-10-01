using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;


using FiratManagementSystemApi.ApprovalTierLogs;
using FiratManagementSystemApi.ApprovalTiers;

        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace FiratManagementSystemApi.TierAuthorizations
{
    
    public  class TierAuthorization : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        public UNKNOWN_TYPE PersonnelId { get; set; }
        [StringLength(100,MinimumLength=1)]
        public string PersonnelName { get; set; }
        [StringLength(100,MinimumLength=1)]
        public string EmailInfo { get; set; }
        
        public Guid? ApprovalTierId { get; set; }    
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public TierAuthorization()
        {

        }

        
        public TierAuthorization
        (
            Guid id
          ,string personnelName 
          ,string emailInfo 
          ,Guid? approvalTierId
            

        )


        {
               Id = id;
                PersonnelName=personnelName;
                EmailInfo=emailInfo;
                ApprovalTierId=approvalTierId;

        }


        
    }
}

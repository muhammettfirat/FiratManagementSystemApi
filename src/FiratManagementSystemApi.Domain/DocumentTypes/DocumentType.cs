using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;



        /// <summary>
        ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
        ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
        ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

        ///  In order to be able to customize the abstract classes produced with Code Generator,
        ///  it is necessary to inherit the abstract class and customize it.
        ///  Restarting Code Generator, any customizations will be lost!!!
        /// </summary>

namespace FiratManagementSystemApi.DocumentTypes
{
    
    public  class DocumentType : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        
        [Required]
        public string Code { get; set; }
        [Required]
        [StringLength(500,MinimumLength=1)]
        public string Definition { get; set; }
        public Guid? TenantId { get; set; }
        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove


        public DocumentType()
        {

        }

        
        public DocumentType
        (
            Guid id
          ,string code 
          ,string definition 
            

        )


        {
               Id = id;
                Code=code;
                Definition=definition;

        }


        
    }
}

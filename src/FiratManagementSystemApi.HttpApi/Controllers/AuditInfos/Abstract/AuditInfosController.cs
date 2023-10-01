



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.AuditInfos;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.AuditInfos
{
    
    [Route("api/audit-infos")]
    
    public abstract class AuditInfosController : AbpController,IAuditInfosAppService
    {
        private readonly IAuditInfosAppService _auditInfosAppService;

        

        public AuditInfosController(IAuditInfosAppService auditInfosAppService)
       {
        _auditInfosAppService = auditInfosAppService;
       }

        [HttpPost]
        
        public virtual Task<AuditInfoDto> CreateAsync( AuditInfoCreateDto  input)
        {
            
                return _auditInfosAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AuditInfoDto> UpdateAsync(Guid id,  AuditInfoUpdateDto  input)
        {
            return _auditInfosAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AuditInfoDto>> GetListAsync(GetAuditInfosInput input)
        {
            return _auditInfosAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AuditInfoDto> GetAsync( Guid id)
        {
            return _auditInfosAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _auditInfosAppService.DeleteAsync(id);
        }
    }
}

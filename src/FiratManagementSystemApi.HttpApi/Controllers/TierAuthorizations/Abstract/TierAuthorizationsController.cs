



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.TierAuthorizations;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.TierAuthorizations
{
    
    [Route("api/tier-authorizations")]
    
    public abstract class TierAuthorizationsController : AbpController,ITierAuthorizationsAppService
    {
        private readonly ITierAuthorizationsAppService _tierAuthorizationsAppService;

        

        public TierAuthorizationsController(ITierAuthorizationsAppService tierAuthorizationsAppService)
       {
        _tierAuthorizationsAppService = tierAuthorizationsAppService;
       }

        [HttpPost]
        
        public virtual Task<TierAuthorizationDto> CreateAsync( TierAuthorizationCreateDto  input)
        {
            
                return _tierAuthorizationsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TierAuthorizationDto> UpdateAsync(Guid id,  TierAuthorizationUpdateDto  input)
        {
            return _tierAuthorizationsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TierAuthorizationDto>> GetListAsync(GetTierAuthorizationsInput input)
        {
            return _tierAuthorizationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TierAuthorizationDto> GetAsync( Guid id)
        {
            return _tierAuthorizationsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _tierAuthorizationsAppService.DeleteAsync(id);
        }
    }
}

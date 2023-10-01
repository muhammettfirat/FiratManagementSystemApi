



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.ApprovalTiers;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.ApprovalTiers
{
    
    [Route("api/approval-tiers")]
    
    public abstract class ApprovalTiersController : AbpController,IApprovalTiersAppService
    {
        private readonly IApprovalTiersAppService _approvalTiersAppService;

        

        public ApprovalTiersController(IApprovalTiersAppService approvalTiersAppService)
       {
        _approvalTiersAppService = approvalTiersAppService;
       }

        [HttpPost]
        
        public virtual Task<ApprovalTierDto> CreateAsync( ApprovalTierCreateDto  input)
        {
            
                return _approvalTiersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ApprovalTierDto> UpdateAsync(Guid id,  ApprovalTierUpdateDto  input)
        {
            return _approvalTiersAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ApprovalTierDto>> GetListAsync(GetApprovalTiersInput input)
        {
            return _approvalTiersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ApprovalTierDto> GetAsync( Guid id)
        {
            return _approvalTiersAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _approvalTiersAppService.DeleteAsync(id);
        }
    }
}

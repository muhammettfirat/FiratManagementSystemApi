



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.ApprovalTierLogs;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.ApprovalTierLogs
{
    
    [Route("api/approval-tier-logs")]
    
    public abstract class ApprovalTierLogsController : AbpController,IApprovalTierLogsAppService
    {
        private readonly IApprovalTierLogsAppService _approvalTierLogsAppService;

        

        public ApprovalTierLogsController(IApprovalTierLogsAppService approvalTierLogsAppService)
       {
        _approvalTierLogsAppService = approvalTierLogsAppService;
       }

        [HttpPost]
        
        public virtual Task<ApprovalTierLogDto> CreateAsync( ApprovalTierLogCreateDto  input)
        {
            
                return _approvalTierLogsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ApprovalTierLogDto> UpdateAsync(Guid id,  ApprovalTierLogUpdateDto  input)
        {
            return _approvalTierLogsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ApprovalTierLogDto>> GetListAsync(GetApprovalTierLogsInput input)
        {
            return _approvalTierLogsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ApprovalTierLogDto> GetAsync( Guid id)
        {
            return _approvalTierLogsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _approvalTierLogsAppService.DeleteAsync(id);
        }
    }
}

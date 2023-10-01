

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.ApprovalTiers

{
    public interface IApprovalTiersAppService: IApplicationService
    {
        

        Task<PagedResultDto< ApprovalTierDto >> GetListAsync(GetApprovalTiersInput input);

        Task<ApprovalTierDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ApprovalTierDto> CreateAsync(ApprovalTierCreateDto input);

        Task<ApprovalTierDto> UpdateAsync(Guid id, ApprovalTierUpdateDto input);

        
    }
}



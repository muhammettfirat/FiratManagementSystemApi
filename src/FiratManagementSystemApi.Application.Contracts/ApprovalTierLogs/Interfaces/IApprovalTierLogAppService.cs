

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.ApprovalTierLogs

{
    public interface IApprovalTierLogsAppService: IApplicationService
    {
        

        Task<PagedResultDto< ApprovalTierLogDto >> GetListAsync(GetApprovalTierLogsInput input);

        Task<ApprovalTierLogDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ApprovalTierLogDto> CreateAsync(ApprovalTierLogCreateDto input);

        Task<ApprovalTierLogDto> UpdateAsync(Guid id, ApprovalTierLogUpdateDto input);

        
    }
}



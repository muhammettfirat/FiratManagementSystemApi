

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.AuditInfos

{
    public interface IAuditInfosAppService: IApplicationService
    {
        

        Task<PagedResultDto< AuditInfoDto >> GetListAsync(GetAuditInfosInput input);

        Task<AuditInfoDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<AuditInfoDto> CreateAsync(AuditInfoCreateDto input);

        Task<AuditInfoDto> UpdateAsync(Guid id, AuditInfoUpdateDto input);

        
    }
}



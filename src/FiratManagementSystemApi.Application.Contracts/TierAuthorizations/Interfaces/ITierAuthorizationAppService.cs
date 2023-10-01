

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.TierAuthorizations

{
    public interface ITierAuthorizationsAppService: IApplicationService
    {
        

        Task<PagedResultDto< TierAuthorizationDto >> GetListAsync(GetTierAuthorizationsInput input);

        Task<TierAuthorizationDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TierAuthorizationDto> CreateAsync(TierAuthorizationCreateDto input);

        Task<TierAuthorizationDto> UpdateAsync(Guid id, TierAuthorizationUpdateDto input);

        
    }
}



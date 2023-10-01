

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.Groups

{
    public interface IGroupsAppService: IApplicationService
    {
        

        Task<PagedResultDto< GroupDto >> GetListAsync(GetGroupsInput input);

        Task<GroupDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<GroupDto> CreateAsync(GroupCreateDto input);

        Task<GroupDto> UpdateAsync(Guid id, GroupUpdateDto input);

        
    }
}



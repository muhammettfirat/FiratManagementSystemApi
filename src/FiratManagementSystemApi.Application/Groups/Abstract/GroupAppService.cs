
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using FiratManagementSystemApi.Permissions;
using FiratManagementSystemApi.Groups;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.Groups
{
public abstract class GroupsAppService :ApplicationService, IGroupsAppService
{
    private readonly IGroupRepository _groupRepository;
    private readonly GroupManager _groupManager;

    public GroupsAppService(IGroupRepository groupRepository,GroupManager groupManager)
    {
        _groupRepository = groupRepository;
        _groupManager= groupManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.Groups.Create)]
    public virtual async Task<GroupDto> CreateAsync(GroupCreateDto input)
        {

            var group = await _groupManager.CreateAsync(
                input.Code,
                input.Definition,
            );
           
            
            return ObjectMapper.Map<Group, GroupDto>(group);
        }

        [Authorize(FiratManagementSystemApiPermissions.Groups.Create)]
    public virtual async Task<PagedResultDto<GroupDto>> GetListAsync(GetGroupsInput input)
        {
            var totalCount = await _groupRepository.GetCountAsync(input.FilterText, input.Code, input.Definition);
            var items = await _groupRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Definition
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<GroupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< Group>, List<GroupDto>>(items)
            };
        }


   

    public virtual async Task< GroupDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Group, GroupDto>(await _groupRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.Groups.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _groupRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.Groups.Edit)]
     public virtual async Task<GroupDto> UpdateAsync(Guid id, GroupUpdateDto input)
         {
    
            var group = await _groupManager.UpdateAsync(
                id,
                input.Code,
                input.Definition,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<Group, GroupDto>(group);
         }
    



         

        
         

}
}
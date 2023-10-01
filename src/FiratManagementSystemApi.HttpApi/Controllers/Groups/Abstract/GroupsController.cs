



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.Groups;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.Groups
{
    
    [Route("api/groups")]
    
    public abstract class GroupsController : AbpController,IGroupsAppService
    {
        private readonly IGroupsAppService _groupsAppService;

        

        public GroupsController(IGroupsAppService groupsAppService)
       {
        _groupsAppService = groupsAppService;
       }

        [HttpPost]
        
        public virtual Task<GroupDto> CreateAsync( GroupCreateDto  input)
        {
            
                return _groupsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<GroupDto> UpdateAsync(Guid id,  GroupUpdateDto  input)
        {
            return _groupsAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<GroupDto>> GetListAsync(GetGroupsInput input)
        {
            return _groupsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<GroupDto> GetAsync( Guid id)
        {
            return _groupsAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _groupsAppService.DeleteAsync(id);
        }
    }
}

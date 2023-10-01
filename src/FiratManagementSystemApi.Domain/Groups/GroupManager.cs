using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.Groups
{
    public class GroupManager : DomainService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupManager(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> CreateAsync(
              string code, 
              string definition, 
        )
        {

            var group = new Group(
             GuidGenerator.Create(),
               code, 
               definition, 
             );

            return await _groupRepository.InsertAsync(group);
        }

        public async Task<Group> UpdateAsync(
           Guid id,
          string code, 
          string definition, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _groupRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var group = await AsyncExecuter.FirstOrDefaultAsync(query);

                group.Code=code;
                group.Definition=definition;

         group.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _groupRepository.UpdateAsync(group);
        }

    }
}
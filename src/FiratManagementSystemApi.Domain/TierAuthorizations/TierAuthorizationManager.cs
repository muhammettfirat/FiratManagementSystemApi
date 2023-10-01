using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.TierAuthorizations
{
    public class TierAuthorizationManager : DomainService
    {
        private readonly ITierAuthorizationRepository _tierAuthorizationRepository;

        public TierAuthorizationManager(ITierAuthorizationRepository tierAuthorizationRepository)
        {
            _tierAuthorizationRepository = tierAuthorizationRepository;
        }

        public async Task<TierAuthorization> CreateAsync(
              string personnelName, 
              string emailInfo, 
              Guid? approvalTierId,
        )
        {

            var tierAuthorization = new TierAuthorization(
             GuidGenerator.Create(),
               personnelName, 
               emailInfo, 
               approvalTierId,
             );

            return await _tierAuthorizationRepository.InsertAsync(tierAuthorization);
        }

        public async Task<TierAuthorization> UpdateAsync(
           Guid id,
          string personnelName, 
          string emailInfo, 
          Guid? approvalTierId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _tierAuthorizationRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var tierAuthorization = await AsyncExecuter.FirstOrDefaultAsync(query);

                tierAuthorization.PersonnelName=personnelName;
                tierAuthorization.EmailInfo=emailInfo;
                tierAuthorization.ApprovalTierId=approvalTierId;

         tierAuthorization.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _tierAuthorizationRepository.UpdateAsync(tierAuthorization);
        }

    }
}
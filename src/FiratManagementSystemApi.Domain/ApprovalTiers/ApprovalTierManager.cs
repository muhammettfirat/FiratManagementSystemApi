using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.ApprovalTiers
{
    public class ApprovalTierManager : DomainService
    {
        private readonly IApprovalTierRepository _approvalTierRepository;

        public ApprovalTierManager(IApprovalTierRepository approvalTierRepository)
        {
            _approvalTierRepository = approvalTierRepository;
        }

        public async Task<ApprovalTier> CreateAsync(
              string definition, 
              int? code, 
    
              bool? finalTiers, 
        )
        {

            var approvalTier = new ApprovalTier(
             GuidGenerator.Create(),
               definition, 
               code, 
    
                finalTiers, 
             );

            return await _approvalTierRepository.InsertAsync(approvalTier);
        }

        public async Task<ApprovalTier> UpdateAsync(
           Guid id,
          string definition, 
          int? code, 

          bool? finalTiers, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _approvalTierRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var approvalTier = await AsyncExecuter.FirstOrDefaultAsync(query);

                approvalTier.Definition=definition;
                 approvalTier.Code=code;
                approvalTier.FinalTiers=finalTiers;  

         approvalTier.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _approvalTierRepository.UpdateAsync(approvalTier);
        }

    }
}
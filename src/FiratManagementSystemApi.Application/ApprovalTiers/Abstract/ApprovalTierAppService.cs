
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
using FiratManagementSystemApi.ApprovalTiers;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.ApprovalTiers
{
public abstract class ApprovalTiersAppService :ApplicationService, IApprovalTiersAppService
{
    private readonly IApprovalTierRepository _approvalTierRepository;
    private readonly ApprovalTierManager _approvalTierManager;

    public ApprovalTiersAppService(IApprovalTierRepository approvalTierRepository,ApprovalTierManager approvalTierManager)
    {
        _approvalTierRepository = approvalTierRepository;
        _approvalTierManager= approvalTierManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.ApprovalTiers.Create)]
    public virtual async Task<ApprovalTierDto> CreateAsync(ApprovalTierCreateDto input)
        {

            var approvalTier = await _approvalTierManager.CreateAsync(
                input.Definition,
                input.Code,
                input.FinalTiers, 
            );
           
            
            return ObjectMapper.Map<ApprovalTier, ApprovalTierDto>(approvalTier);
        }

        [Authorize(FiratManagementSystemApiPermissions.ApprovalTiers.Create)]
    public virtual async Task<PagedResultDto<ApprovalTierDto>> GetListAsync(GetApprovalTiersInput input)
        {
            var totalCount = await _approvalTierRepository.GetCountAsync(input.FilterText, input.Definition);
            var items = await _approvalTierRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Definition
            ,input.CodeMin
            ,input.CodeMax 
            ,input.FinalTiers
            
            
          
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<ApprovalTierDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< ApprovalTier>, List<ApprovalTierDto>>(items)
            };
        }


   

    public virtual async Task< ApprovalTierDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ApprovalTier, ApprovalTierDto>(await _approvalTierRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.ApprovalTiers.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _approvalTierRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.ApprovalTiers.Edit)]
     public virtual async Task<ApprovalTierDto> UpdateAsync(Guid id, ApprovalTierUpdateDto input)
         {
    
            var approvalTier = await _approvalTierManager.UpdateAsync(
                id,
                input.Definition,
                input.Code,
                input.FinalTiers, 
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<ApprovalTier, ApprovalTierDto>(approvalTier);
         }
    



         

        
         

}
}
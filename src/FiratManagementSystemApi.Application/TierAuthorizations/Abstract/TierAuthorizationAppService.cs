
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
using FiratManagementSystemApi.TierAuthorizations;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.TierAuthorizations
{
public abstract class TierAuthorizationsAppService :ApplicationService, ITierAuthorizationsAppService
{
    private readonly ITierAuthorizationRepository _tierAuthorizationRepository;
    private readonly TierAuthorizationManager _tierAuthorizationManager;

    public TierAuthorizationsAppService(ITierAuthorizationRepository tierAuthorizationRepository,TierAuthorizationManager tierAuthorizationManager)
    {
        _tierAuthorizationRepository = tierAuthorizationRepository;
        _tierAuthorizationManager= tierAuthorizationManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.TierAuthorizations.Create)]
    public virtual async Task<TierAuthorizationDto> CreateAsync(TierAuthorizationCreateDto input)
        {

            var tierAuthorization = await _tierAuthorizationManager.CreateAsync(
                input.PersonnelName,
                input.EmailInfo,
                input.ApprovalTierId,
            );
           
            
            return ObjectMapper.Map<TierAuthorization, TierAuthorizationDto>(tierAuthorization);
        }

        [Authorize(FiratManagementSystemApiPermissions.TierAuthorizations.Create)]
    public virtual async Task<PagedResultDto<TierAuthorizationDto>> GetListAsync(GetTierAuthorizationsInput input)
        {
            var totalCount = await _tierAuthorizationRepository.GetCountAsync(input.FilterText, input.PersonnelName, input.EmailInfo);
            var items = await _tierAuthorizationRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.PersonnelName
            ,input.EmailInfo
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<TierAuthorizationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< TierAuthorization>, List<TierAuthorizationDto>>(items)
            };
        }


   

    public virtual async Task< TierAuthorizationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<TierAuthorization, TierAuthorizationDto>(await _tierAuthorizationRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.TierAuthorizations.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _tierAuthorizationRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.TierAuthorizations.Edit)]
     public virtual async Task<TierAuthorizationDto> UpdateAsync(Guid id, TierAuthorizationUpdateDto input)
         {
    
            var tierAuthorization = await _tierAuthorizationManager.UpdateAsync(
                id,
                input.PersonnelName,
                input.EmailInfo,
                input.ApprovalTierId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<TierAuthorization, TierAuthorizationDto>(tierAuthorization);
         }
    



         

        
         

}
}
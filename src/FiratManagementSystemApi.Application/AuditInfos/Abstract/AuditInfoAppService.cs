
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
using FiratManagementSystemApi.AuditInfos;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.AuditInfos
{
public abstract class AuditInfosAppService :ApplicationService, IAuditInfosAppService
{
    private readonly IAuditInfoRepository _auditInfoRepository;
    private readonly AuditInfoManager _auditInfoManager;

    public AuditInfosAppService(IAuditInfoRepository auditInfoRepository,AuditInfoManager auditInfoManager)
    {
        _auditInfoRepository = auditInfoRepository;
        _auditInfoManager= auditInfoManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.AuditInfos.Create)]
    public virtual async Task<AuditInfoDto> CreateAsync(AuditInfoCreateDto input)
        {

            var auditInfo = await _auditInfoManager.CreateAsync(
                input.CompanyPersonnel01,
                input.CompanyPersonnel02,
                input.CompanyPersonnel03,
                input.CompanyPersonnel04,
                input.Description,
                input.DecisionTaken,
                input.AuditResultMissing,
                input.ExpectedDocument,
                input.AuditDate,
                input.AuditEvaluationResult,
                input.Score,
                input.CompanyInfoId,
            );
           
            
            return ObjectMapper.Map<AuditInfo, AuditInfoDto>(auditInfo);
        }

        [Authorize(FiratManagementSystemApiPermissions.AuditInfos.Create)]
    public virtual async Task<PagedResultDto<AuditInfoDto>> GetListAsync(GetAuditInfosInput input)
        {
            var totalCount = await _auditInfoRepository.GetCountAsync(input.FilterText, input.CompanyPersonnel01, input.CompanyPersonnel02, input.CompanyPersonnel03, input.CompanyPersonnel04, input.Description, input.DecisionTaken, input.AuditResultMissing, input.ExpectedDocument);
            var items = await _auditInfoRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.CompanyPersonnel01
            ,input.CompanyPersonnel02
            ,input.CompanyPersonnel03
            ,input.CompanyPersonnel04
            ,input.Description
            ,input.DecisionTaken
            ,input.AuditResultMissing
            ,input.ExpectedDocument
            ,input.AuditDateMin
            ,input.AuditDateMax 
            ,input.AuditEvaluationResultMin
            ,input.AuditEvaluationResultMax 
            ,input.ScoreMin
            ,input.ScoreMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<AuditInfoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< AuditInfo>, List<AuditInfoDto>>(items)
            };
        }


   

    public virtual async Task< AuditInfoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AuditInfo, AuditInfoDto>(await _auditInfoRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.AuditInfos.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _auditInfoRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.AuditInfos.Edit)]
     public virtual async Task<AuditInfoDto> UpdateAsync(Guid id, AuditInfoUpdateDto input)
         {
    
            var auditInfo = await _auditInfoManager.UpdateAsync(
                id,
                input.CompanyPersonnel01,
                input.CompanyPersonnel02,
                input.CompanyPersonnel03,
                input.CompanyPersonnel04,
                input.Description,
                input.DecisionTaken,
                input.AuditResultMissing,
                input.ExpectedDocument,
                input.AuditDate,
                input.AuditEvaluationResult,
                input.Score,
                input.CompanyInfoId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<AuditInfo, AuditInfoDto>(auditInfo);
         }
    



         

        
         

}
}
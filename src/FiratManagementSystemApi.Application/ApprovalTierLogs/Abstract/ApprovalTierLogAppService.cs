
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
using FiratManagementSystemApi.ApprovalTierLogs;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.ApprovalTierLogs
{
public abstract class ApprovalTierLogsAppService :ApplicationService, IApprovalTierLogsAppService
{
    private readonly IApprovalTierLogRepository _approvalTierLogRepository;
    private readonly ApprovalTierLogManager _approvalTierLogManager;

    public ApprovalTierLogsAppService(IApprovalTierLogRepository approvalTierLogRepository,ApprovalTierLogManager approvalTierLogManager)
    {
        _approvalTierLogRepository = approvalTierLogRepository;
        _approvalTierLogManager= approvalTierLogManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.ApprovalTierLogs.Create)]
    public virtual async Task<ApprovalTierLogDto> CreateAsync(ApprovalTierLogCreateDto input)
        {

            var approvalTierLog = await _approvalTierLogManager.CreateAsync(
                input.RelatedFileType,
                input.ApprovalStatus,
                input.ApprovalTierName,
                input.AuditDate,
                input.OperationDate,
                input.AuditInfoId,
                input.TierAuthorizationId,
                input.ApprovalTierId,
            );
           
            
            return ObjectMapper.Map<ApprovalTierLog, ApprovalTierLogDto>(approvalTierLog);
        }

        [Authorize(FiratManagementSystemApiPermissions.ApprovalTierLogs.Create)]
    public virtual async Task<PagedResultDto<ApprovalTierLogDto>> GetListAsync(GetApprovalTierLogsInput input)
        {
            var totalCount = await _approvalTierLogRepository.GetCountAsync(input.FilterText, input.RelatedFileType, input.ApprovalStatus, input.ApprovalTierName);
            var items = await _approvalTierLogRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.RelatedFileType
            ,input.ApprovalStatus
            ,input.ApprovalTierName
            ,input.AuditDateMin
            ,input.AuditDateMax 
            ,input.OperationDateMin
            ,input.OperationDateMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<ApprovalTierLogDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< ApprovalTierLog>, List<ApprovalTierLogDto>>(items)
            };
        }


   

    public virtual async Task< ApprovalTierLogDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ApprovalTierLog, ApprovalTierLogDto>(await _approvalTierLogRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.ApprovalTierLogs.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _approvalTierLogRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.ApprovalTierLogs.Edit)]
     public virtual async Task<ApprovalTierLogDto> UpdateAsync(Guid id, ApprovalTierLogUpdateDto input)
         {
    
            var approvalTierLog = await _approvalTierLogManager.UpdateAsync(
                id,
                input.RelatedFileType,
                input.ApprovalStatus,
                input.ApprovalTierName,
                input.AuditDate,
                input.OperationDate,
                input.AuditInfoId,
                input.TierAuthorizationId,
                input.ApprovalTierId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<ApprovalTierLog, ApprovalTierLogDto>(approvalTierLog);
         }
    



         

        
         

}
}

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
using FiratManagementSystemApi.StockInfos;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.StockInfos
{
public abstract class StockInfosAppService :ApplicationService, IStockInfosAppService
{
    private readonly IStockInfoRepository _stockInfoRepository;
    private readonly StockInfoManager _stockInfoManager;

    public StockInfosAppService(IStockInfoRepository stockInfoRepository,StockInfoManager stockInfoManager)
    {
        _stockInfoRepository = stockInfoRepository;
        _stockInfoManager= stockInfoManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.StockInfos.Create)]
    public virtual async Task<StockInfoDto> CreateAsync(StockInfoCreateDto input)
        {

            var stockInfo = await _stockInfoManager.CreateAsync(
                input.RelatedFile,
                input.ManufacturingLocationAddress,
                input.ManufacturersAddress,
                input.EvaluationDescription,
                input.AuditResultMissing,
                input.ExpectedDocument,
                input.DecisionTaken,
                input.ApprovalStatus,
                input.EvaluationDate,
                input.AuditEvaluationResult,
                input.GroupId,
                input.ApprovalTierId,
            );
           
            
            return ObjectMapper.Map<StockInfo, StockInfoDto>(stockInfo);
        }

        [Authorize(FiratManagementSystemApiPermissions.StockInfos.Create)]
    public virtual async Task<PagedResultDto<StockInfoDto>> GetListAsync(GetStockInfosInput input)
        {
            var totalCount = await _stockInfoRepository.GetCountAsync(input.FilterText, input.RelatedFile, input.ManufacturingLocationAddress, input.ManufacturersAddress, input.EvaluationDescription, input.AuditResultMissing, input.ExpectedDocument, input.DecisionTaken, input.ApprovalStatus);
            var items = await _stockInfoRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.RelatedFile
            ,input.ManufacturingLocationAddress
            ,input.ManufacturersAddress
            ,input.EvaluationDescription
            ,input.AuditResultMissing
            ,input.ExpectedDocument
            ,input.DecisionTaken
            ,input.ApprovalStatus
            ,input.EvaluationDateMin
            ,input.EvaluationDateMax 
            ,input.AuditEvaluationResultMin
            ,input.AuditEvaluationResultMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<StockInfoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< StockInfo>, List<StockInfoDto>>(items)
            };
        }


   

    public virtual async Task< StockInfoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StockInfo, StockInfoDto>(await _stockInfoRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.StockInfos.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _stockInfoRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.StockInfos.Edit)]
     public virtual async Task<StockInfoDto> UpdateAsync(Guid id, StockInfoUpdateDto input)
         {
    
            var stockInfo = await _stockInfoManager.UpdateAsync(
                id,
                input.RelatedFile,
                input.ManufacturingLocationAddress,
                input.ManufacturersAddress,
                input.EvaluationDescription,
                input.AuditResultMissing,
                input.ExpectedDocument,
                input.DecisionTaken,
                input.ApprovalStatus,
                input.EvaluationDate,
                input.AuditEvaluationResult,
                input.GroupId,
                input.ApprovalTierId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<StockInfo, StockInfoDto>(stockInfo);
         }
    



         

        
         

}
}
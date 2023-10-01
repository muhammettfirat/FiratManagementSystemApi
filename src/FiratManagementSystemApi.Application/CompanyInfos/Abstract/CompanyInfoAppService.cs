
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
using FiratManagementSystemApi.CompanyInfos;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.CompanyInfos
{
public abstract class CompanyInfosAppService :ApplicationService, ICompanyInfosAppService
{
    private readonly ICompanyInfoRepository _companyInfoRepository;
    private readonly CompanyInfoManager _companyInfoManager;

    public CompanyInfosAppService(ICompanyInfoRepository companyInfoRepository,CompanyInfoManager companyInfoManager)
    {
        _companyInfoRepository = companyInfoRepository;
        _companyInfoManager= companyInfoManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.CompanyInfos.Create)]
    public virtual async Task<CompanyInfoDto> CreateAsync(CompanyInfoCreateDto input)
        {

            var companyInfo = await _companyInfoManager.CreateAsync(
                input.ApprovalStatus,
                input.StartedWorkingDate,
                input.AuditPeriodMonth,
                input.GroupId,
                input.ApprovalTierId,
            );
           
            
            return ObjectMapper.Map<CompanyInfo, CompanyInfoDto>(companyInfo);
        }

        [Authorize(FiratManagementSystemApiPermissions.CompanyInfos.Create)]
    public virtual async Task<PagedResultDto<CompanyInfoDto>> GetListAsync(GetCompanyInfosInput input)
        {
            var totalCount = await _companyInfoRepository.GetCountAsync(input.FilterText, input.ApprovalStatus);
            var items = await _companyInfoRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.ApprovalStatus
            ,input.StartedWorkingDateMin
            ,input.StartedWorkingDateMax 
            ,input.AuditPeriodMonthMin
            ,input.AuditPeriodMonthMax 
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<CompanyInfoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< CompanyInfo>, List<CompanyInfoDto>>(items)
            };
        }


   

    public virtual async Task< CompanyInfoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyInfo, CompanyInfoDto>(await _companyInfoRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.CompanyInfos.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _companyInfoRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.CompanyInfos.Edit)]
     public virtual async Task<CompanyInfoDto> UpdateAsync(Guid id, CompanyInfoUpdateDto input)
         {
    
            var companyInfo = await _companyInfoManager.UpdateAsync(
                id,
                input.ApprovalStatus,
                input.StartedWorkingDate,
                input.AuditPeriodMonth,
                input.GroupId,
                input.ApprovalTierId,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<CompanyInfo, CompanyInfoDto>(companyInfo);
         }
    



         

        
         

}
}
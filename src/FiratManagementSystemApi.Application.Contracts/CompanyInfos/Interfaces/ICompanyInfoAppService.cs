

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.CompanyInfos

{
    public interface ICompanyInfosAppService: IApplicationService
    {
        

        Task<PagedResultDto< CompanyInfoDto >> GetListAsync(GetCompanyInfosInput input);

        Task<CompanyInfoDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyInfoDto> CreateAsync(CompanyInfoCreateDto input);

        Task<CompanyInfoDto> UpdateAsync(Guid id, CompanyInfoUpdateDto input);

        
    }
}



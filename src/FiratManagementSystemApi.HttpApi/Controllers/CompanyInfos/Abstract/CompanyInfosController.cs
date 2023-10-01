



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.CompanyInfos;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.CompanyInfos
{
    
    [Route("api/company-infos")]
    
    public abstract class CompanyInfosController : AbpController,ICompanyInfosAppService
    {
        private readonly ICompanyInfosAppService _companyInfosAppService;

        

        public CompanyInfosController(ICompanyInfosAppService companyInfosAppService)
       {
        _companyInfosAppService = companyInfosAppService;
       }

        [HttpPost]
        
        public virtual Task<CompanyInfoDto> CreateAsync( CompanyInfoCreateDto  input)
        {
            
                return _companyInfosAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyInfoDto> UpdateAsync(Guid id,  CompanyInfoUpdateDto  input)
        {
            return _companyInfosAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyInfoDto>> GetListAsync(GetCompanyInfosInput input)
        {
            return _companyInfosAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyInfoDto> GetAsync( Guid id)
        {
            return _companyInfosAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _companyInfosAppService.DeleteAsync(id);
        }
    }
}

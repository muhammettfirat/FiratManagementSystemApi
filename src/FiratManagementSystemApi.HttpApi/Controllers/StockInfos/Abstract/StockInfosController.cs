



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.StockInfos;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.StockInfos
{
    
    [Route("api/stock-infos")]
    
    public abstract class StockInfosController : AbpController,IStockInfosAppService
    {
        private readonly IStockInfosAppService _stockInfosAppService;

        

        public StockInfosController(IStockInfosAppService stockInfosAppService)
       {
        _stockInfosAppService = stockInfosAppService;
       }

        [HttpPost]
        
        public virtual Task<StockInfoDto> CreateAsync( StockInfoCreateDto  input)
        {
            
                return _stockInfosAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StockInfoDto> UpdateAsync(Guid id,  StockInfoUpdateDto  input)
        {
            return _stockInfosAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<StockInfoDto>> GetListAsync(GetStockInfosInput input)
        {
            return _stockInfosAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StockInfoDto> GetAsync( Guid id)
        {
            return _stockInfosAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _stockInfosAppService.DeleteAsync(id);
        }
    }
}

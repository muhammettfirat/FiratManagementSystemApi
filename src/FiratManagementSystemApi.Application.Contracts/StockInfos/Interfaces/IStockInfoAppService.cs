

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.StockInfos

{
    public interface IStockInfosAppService: IApplicationService
    {
        

        Task<PagedResultDto< StockInfoDto >> GetListAsync(GetStockInfosInput input);

        Task<StockInfoDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<StockInfoDto> CreateAsync(StockInfoCreateDto input);

        Task<StockInfoDto> UpdateAsync(Guid id, StockInfoUpdateDto input);

        
    }
}



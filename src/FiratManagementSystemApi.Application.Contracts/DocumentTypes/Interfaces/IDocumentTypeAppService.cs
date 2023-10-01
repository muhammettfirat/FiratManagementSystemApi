

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using FiratManagementSystemApi.Shared;


namespace FiratManagementSystemApi.DocumentTypes

{
    public interface IDocumentTypesAppService: IApplicationService
    {
        

        Task<PagedResultDto< DocumentTypeDto >> GetListAsync(GetDocumentTypesInput input);

        Task<DocumentTypeDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<DocumentTypeDto> CreateAsync(DocumentTypeCreateDto input);

        Task<DocumentTypeDto> UpdateAsync(Guid id, DocumentTypeUpdateDto input);

        
    }
}



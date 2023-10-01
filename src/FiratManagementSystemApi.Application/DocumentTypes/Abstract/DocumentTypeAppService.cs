
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
using FiratManagementSystemApi.DocumentTypes;
using FiratManagementSystemApi.Shared;


/// <summary>
    ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
    ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>




namespace FiratManagementSystemApi.DocumentTypes
{
public abstract class DocumentTypesAppService :ApplicationService, IDocumentTypesAppService
{
    private readonly IDocumentTypeRepository _documentTypeRepository;
    private readonly DocumentTypeManager _documentTypeManager;

    public DocumentTypesAppService(IDocumentTypeRepository documentTypeRepository,DocumentTypeManager documentTypeManager)
    {
        _documentTypeRepository = documentTypeRepository;
        _documentTypeManager= documentTypeManager;
    }

    
        [Authorize(FiratManagementSystemApiPermissions.DocumentTypes.Create)]
    public virtual async Task<DocumentTypeDto> CreateAsync(DocumentTypeCreateDto input)
        {

            var documentType = await _documentTypeManager.CreateAsync(
                input.Code,
                input.Definition,
            );
           
            
            return ObjectMapper.Map<DocumentType, DocumentTypeDto>(documentType);
        }

        [Authorize(FiratManagementSystemApiPermissions.DocumentTypes.Create)]
    public virtual async Task<PagedResultDto<DocumentTypeDto>> GetListAsync(GetDocumentTypesInput input)
        {
            var totalCount = await _documentTypeRepository.GetCountAsync(input.FilterText, input.Code, input.Definition);
            var items = await _documentTypeRepository.GetListAsync(
             input.FilterText 
            ,input.Sorting
            ,input.Code
            ,input.Definition
            ,input.MaxResultCount
            ,input.SkipCount      
            );

            return new PagedResultDto<DocumentTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List< DocumentType>, List<DocumentTypeDto>>(items)
            };
        }


   

    public virtual async Task< DocumentTypeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<DocumentType, DocumentTypeDto>(await _documentTypeRepository.GetAsync(id));
        }


   
        [Authorize(FiratManagementSystemApiPermissions.DocumentTypes.Delete)]
    public virtual async Task DeleteAsync(Guid id)
        {
            await _documentTypeRepository.DeleteAsync(id);
        }

        [Authorize(FiratManagementSystemApiPermissions.DocumentTypes.Edit)]
     public virtual async Task<DocumentTypeDto> UpdateAsync(Guid id, DocumentTypeUpdateDto input)
         {
    
            var documentType = await _documentTypeManager.UpdateAsync(
                id,
                input.Code,
                input.Definition,
                input.ConcurrencyStamp
            );
           
            
            return ObjectMapper.Map<DocumentType, DocumentTypeDto>(documentType);
         }
    



         

        
         

}
}
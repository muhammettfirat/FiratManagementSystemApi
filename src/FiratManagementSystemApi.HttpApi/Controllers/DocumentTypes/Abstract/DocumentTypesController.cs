



using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FiratManagementSystemApi.DocumentTypes;


/// <summary>
    ///  Code Generator ile üretilen abstract sınıflarda özellestirme yapılabilmesi için abstract 
    ///  sinifi kalitim alınarak özelleştirme yapilmasi gerekmektedir.
    ///  Code Generator tekrar calistirildiğinda yapılan özellestirmeler kaybolacaktir!!! 

    ///  In order to be able to customize the abstract classes produced with Code Generator,
    ///  it is necessary to inherit the abstract class and customize it.
    ///  Restarting Code Generator, any customizations will be lost!!!
    /// </summary>


namespace  FiratManagementSystemApi.Controllers.DocumentTypes
{
    
    [Route("api/document-types")]
    
    public abstract class DocumentTypesController : AbpController,IDocumentTypesAppService
    {
        private readonly IDocumentTypesAppService _documentTypesAppService;

        

        public DocumentTypesController(IDocumentTypesAppService documentTypesAppService)
       {
        _documentTypesAppService = documentTypesAppService;
       }

        [HttpPost]
        
        public virtual Task<DocumentTypeDto> CreateAsync( DocumentTypeCreateDto  input)
        {
            
                return _documentTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DocumentTypeDto> UpdateAsync(Guid id,  DocumentTypeUpdateDto  input)
        {
            return _documentTypesAppService.UpdateAsync(id,input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<DocumentTypeDto>> GetListAsync(GetDocumentTypesInput input)
        {
            return _documentTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DocumentTypeDto> GetAsync( Guid id)
        {
            return _documentTypesAppService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync( Guid id)
        {
            return _documentTypesAppService.DeleteAsync(id);
        }
    }
}

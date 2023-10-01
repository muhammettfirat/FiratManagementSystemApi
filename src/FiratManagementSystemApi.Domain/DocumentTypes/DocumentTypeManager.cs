using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.DocumentTypes
{
    public class DocumentTypeManager : DomainService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeManager(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<DocumentType> CreateAsync(
              string code, 
              string definition, 
        )
        {

            var documentType = new DocumentType(
             GuidGenerator.Create(),
               code, 
               definition, 
             );

            return await _documentTypeRepository.InsertAsync(documentType);
        }

        public async Task<DocumentType> UpdateAsync(
           Guid id,
          string code, 
          string definition, 
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _documentTypeRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var documentType = await AsyncExecuter.FirstOrDefaultAsync(query);

                documentType.Code=code;
                documentType.Definition=definition;

         documentType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _documentTypeRepository.UpdateAsync(documentType);
        }

    }
}
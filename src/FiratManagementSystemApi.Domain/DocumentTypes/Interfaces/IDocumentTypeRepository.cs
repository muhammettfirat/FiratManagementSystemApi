using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FiratManagementSystemApi.DocumentTypes
{
    


    public interface IDocumentTypeRepository : IRepository<DocumentType, Guid>
{

  

  
      Task<List< DocumentType>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string code= null 
         ,string definition= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string code= null , 
          string definition= null , 
        CancellationToken cancellationToken = default);

        

    }
}

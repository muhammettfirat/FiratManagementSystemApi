using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FiratManagementSystemApi.TierAuthorizations
{
    


    public interface ITierAuthorizationRepository : IRepository<TierAuthorization, Guid>
{

  

  
      Task<List< TierAuthorization>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string personnelName= null 
         ,string emailInfo= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string personnelName= null , 
          string emailInfo= null , 
        CancellationToken cancellationToken = default);

        

    }
}

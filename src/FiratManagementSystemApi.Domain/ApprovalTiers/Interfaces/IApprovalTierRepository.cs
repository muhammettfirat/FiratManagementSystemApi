using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FiratManagementSystemApi.ApprovalTiers
{
    


    public interface IApprovalTierRepository : IRepository<ApprovalTier, Guid>
{

  

  
      Task<List< ApprovalTier>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string definition= null 
         ,int? codeMin= null 
         ,int? codeMax= null 
         ,bool? finalTiers= null 
       
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string definition= null , 
          int? codeMin= null , 
          int? codeMax= null ,
          bool? finalTiers= null , 
          
        CancellationToken cancellationToken = default);

        

    }
}

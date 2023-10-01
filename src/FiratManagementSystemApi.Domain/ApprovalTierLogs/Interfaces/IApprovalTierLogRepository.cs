using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FiratManagementSystemApi.ApprovalTierLogs
{
    


    public interface IApprovalTierLogRepository : IRepository<ApprovalTierLog, Guid>
{

  

  
      Task<List< ApprovalTierLog>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string relatedFileType= null 
         ,string approvalStatus= null 
         ,string approvalTierName= null 
         ,DateTime? auditDateMin= null  
         ,DateTime? auditDateMax= null 
         ,DateTime? operationDateMin= null  
         ,DateTime? operationDateMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string relatedFileType= null , 
          string approvalStatus= null , 
          string approvalTierName= null , 
          DateTime? auditDateMin= null , 
          DateTime? auditDateMax= null ,
          DateTime? operationDateMin= null , 
          DateTime? operationDateMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}

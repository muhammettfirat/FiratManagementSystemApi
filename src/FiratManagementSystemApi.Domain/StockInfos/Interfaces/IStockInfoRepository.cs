using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FiratManagementSystemApi.StockInfos
{
    


    public interface IStockInfoRepository : IRepository<StockInfo, Guid>
{

  

  
      Task<List< StockInfo>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string relatedFile= null 
         ,string manufacturingLocationAddress= null 
         ,string manufacturersAddress= null 
         ,string evaluationDescription= null 
         ,string auditResultMissing= null 
         ,string expectedDocument= null 
         ,string decisionTaken= null 
         ,string approvalStatus= null 
         ,DateTime? evaluationDateMin= null  
         ,DateTime? evaluationDateMax= null 
         ,int? auditEvaluationResultMin= null 
         ,int? auditEvaluationResultMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string relatedFile= null , 
          string manufacturingLocationAddress= null , 
          string manufacturersAddress= null , 
          string evaluationDescription= null , 
          string auditResultMissing= null , 
          string expectedDocument= null , 
          string decisionTaken= null , 
          string approvalStatus= null , 
          DateTime? evaluationDateMin= null , 
          DateTime? evaluationDateMax= null ,
          int? auditEvaluationResultMin= null , 
          int? auditEvaluationResultMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}

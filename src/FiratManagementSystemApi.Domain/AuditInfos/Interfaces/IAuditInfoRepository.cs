using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FiratManagementSystemApi.AuditInfos
{
    


    public interface IAuditInfoRepository : IRepository<AuditInfo, Guid>
{

  

  
      Task<List< AuditInfo>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string companyPersonnel01= null 
         ,string companyPersonnel02= null 
         ,string companyPersonnel03= null 
         ,string companyPersonnel04= null 
         ,string description= null 
         ,string decisionTaken= null 
         ,string auditResultMissing= null 
         ,string expectedDocument= null 
         ,DateTime? auditDateMin= null  
         ,DateTime? auditDateMax= null 
         ,int? auditEvaluationResultMin= null 
         ,int? auditEvaluationResultMax= null 
         ,int? scoreMin= null 
         ,int? scoreMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string companyPersonnel01= null , 
          string companyPersonnel02= null , 
          string companyPersonnel03= null , 
          string companyPersonnel04= null , 
          string description= null , 
          string decisionTaken= null , 
          string auditResultMissing= null , 
          string expectedDocument= null , 
          DateTime? auditDateMin= null , 
          DateTime? auditDateMax= null ,
          int? auditEvaluationResultMin= null , 
          int? auditEvaluationResultMax= null ,
          int? scoreMin= null , 
          int? scoreMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}

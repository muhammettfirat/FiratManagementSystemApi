using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FiratManagementSystemApi.CompanyInfos
{
    


    public interface ICompanyInfoRepository : IRepository<CompanyInfo, Guid>
{

  

  
      Task<List< CompanyInfo>> GetListAsync(
         string filterText = null
         ,string sorting = null
         ,string approvalStatus= null 
         ,DateTime? startedWorkingDateMin= null  
         ,DateTime? startedWorkingDateMax= null 
         ,DateTime? auditPeriodMonthMin= null  
         ,DateTime? auditPeriodMonthMax= null 
         ,int maxResultCount = int.MaxValue
         ,int skipCount = 0
         ,CancellationToken cancellationToken = default      
       );

       Task<long> GetCountAsync(
        string filterText = null,
          string approvalStatus= null , 
          DateTime? startedWorkingDateMin= null , 
          DateTime? startedWorkingDateMax= null ,
          DateTime? auditPeriodMonthMin= null , 
          DateTime? auditPeriodMonthMax= null ,
        CancellationToken cancellationToken = default);

        

    }
}

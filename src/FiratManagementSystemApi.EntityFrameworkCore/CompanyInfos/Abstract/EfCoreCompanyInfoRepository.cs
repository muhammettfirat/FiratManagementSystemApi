using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using FiratManagementSystemApi.EntityFrameworkCore;

/// <summary>
   ///  Code Generator ile üretilen abstract siniflarda özellestirme yapilabilmesi için abstract 
   ///  sinifi kalitim alinarak özelleştirme yapilmasi gerekmektedir.
   ///  Code Generator tekrar calistirildiğinda yapilan özellestirmeler kaybolacaktir!!! 

   ///  In order to be able to customize the abstract classes produced with Code Generator,
   ///  it is necessary to inherit the abstract class and customize it.
   ///  Restarting Code Generator, any customizations will be lost!!!
   /// </summary>


namespace FiratManagementSystemApi.CompanyInfos
{
    public abstract class EfCoreCompanyInfoRepository : EfCoreRepository<FiratManagementSystemApiDbContext, CompanyInfo , Guid>, ICompanyInfoRepository
    {
        public EfCoreCompanyInfoRepository(IDbContextProvider<FiratManagementSystemApiDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<CompanyInfo>> GetListAsync(
             string filterText = null
            ,string sorting = null
            ,string approvalStatus= null 
            ,DateTime? startedWorkingDateMin= null  
            ,DateTime? startedWorkingDateMax= null 
            ,DateTime? auditPeriodMonthMin= null  
            ,DateTime? auditPeriodMonthMax= null 
            
            ,int maxResultCount = int.MaxValue
            ,int skipCount = 0
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               approvalStatus
             ,startedWorkingDateMin 
             ,startedWorkingDateMax 
             ,auditPeriodMonthMin 
             ,auditPeriodMonthMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyInfoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string approvalStatus= null 
          ,DateTime? startedWorkingDateMin= null  
          ,DateTime? startedWorkingDateMax= null 
          ,DateTime? auditPeriodMonthMin= null  
          ,DateTime? auditPeriodMonthMax= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,approvalStatus
           ,startedWorkingDateMax 
           ,startedWorkingDateMin        
           ,auditPeriodMonthMax 
           ,auditPeriodMonthMin        
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<CompanyInfo> ApplyFilter(
            IQueryable<CompanyInfo> query,
            string filterText = null
          ,string approvalStatus= null  
          ,DateTime? startedWorkingDateMin= null 
          ,DateTime? startedWorkingDateMax= null 
          ,DateTime? auditPeriodMonthMin= null 
          ,DateTime? auditPeriodMonthMax= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ApprovalStatus.Contains(filterText)) 
            .WhereIf(startedWorkingDateMin.HasValue, e => e.StartedWorkingDate >= startedWorkingDateMin.Value)
            .WhereIf(startedWorkingDateMax.HasValue, e => e.StartedWorkingDate >= startedWorkingDateMax.Value)
            .WhereIf(auditPeriodMonthMin.HasValue, e => e.AuditPeriodMonth >= auditPeriodMonthMin.Value)
            .WhereIf(auditPeriodMonthMax.HasValue, e => e.AuditPeriodMonth >= auditPeriodMonthMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(approvalStatus),e => e.ApprovalStatus.Contains(approvalStatus)) 
         ;
        }
        














        


    }
}

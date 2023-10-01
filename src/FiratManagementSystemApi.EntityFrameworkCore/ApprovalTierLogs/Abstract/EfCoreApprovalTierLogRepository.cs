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


namespace FiratManagementSystemApi.ApprovalTierLogs
{
    public abstract class EfCoreApprovalTierLogRepository : EfCoreRepository<FiratManagementSystemApiDbContext, ApprovalTierLog , Guid>, IApprovalTierLogRepository
    {
        public EfCoreApprovalTierLogRepository(IDbContextProvider<FiratManagementSystemApiDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<ApprovalTierLog>> GetListAsync(
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
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               relatedFileType
,
               approvalStatus
,
               approvalTierName
             ,auditDateMin 
             ,auditDateMax 
             ,operationDateMin 
             ,operationDateMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ApprovalTierLogConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string relatedFileType= null 
          ,string approvalStatus= null 
          ,string approvalTierName= null 
          ,DateTime? auditDateMin= null  
          ,DateTime? auditDateMax= null 
          ,DateTime? operationDateMin= null  
          ,DateTime? operationDateMax= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,relatedFileType
,approvalStatus
,approvalTierName
           ,auditDateMax 
           ,auditDateMin        
           ,operationDateMax 
           ,operationDateMin        
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<ApprovalTierLog> ApplyFilter(
            IQueryable<ApprovalTierLog> query,
            string filterText = null
          ,string relatedFileType= null  
          ,string approvalStatus= null  
          ,string approvalTierName= null  
          ,DateTime? auditDateMin= null 
          ,DateTime? auditDateMax= null 
          ,DateTime? operationDateMin= null 
          ,DateTime? operationDateMax= null 
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.RelatedFileType.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ApprovalStatus.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ApprovalTierName.Contains(filterText)) 
            .WhereIf(auditDateMin.HasValue, e => e.AuditDate >= auditDateMin.Value)
            .WhereIf(auditDateMax.HasValue, e => e.AuditDate >= auditDateMax.Value)
            .WhereIf(operationDateMin.HasValue, e => e.OperationDate >= operationDateMin.Value)
            .WhereIf(operationDateMax.HasValue, e => e.OperationDate >= operationDateMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(relatedFileType),e => e.RelatedFileType.Contains(relatedFileType)) 
            .WhereIf(!string.IsNullOrWhiteSpace(approvalStatus),e => e.ApprovalStatus.Contains(approvalStatus)) 
            .WhereIf(!string.IsNullOrWhiteSpace(approvalTierName),e => e.ApprovalTierName.Contains(approvalTierName)) 
         ;
        }
        














        


    }
}

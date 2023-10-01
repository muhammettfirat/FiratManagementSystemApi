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


namespace FiratManagementSystemApi.StockInfos
{
    public abstract class EfCoreStockInfoRepository : EfCoreRepository<FiratManagementSystemApiDbContext, StockInfo , Guid>, IStockInfoRepository
    {
        public EfCoreStockInfoRepository(IDbContextProvider<FiratManagementSystemApiDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<StockInfo>> GetListAsync(
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
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               relatedFile
,
               manufacturingLocationAddress
,
               manufacturersAddress
,
               evaluationDescription
,
               auditResultMissing
,
               expectedDocument
,
               decisionTaken
,
               approvalStatus
             ,evaluationDateMin 
             ,evaluationDateMax 
            ,auditEvaluationResultMin 
            ,auditEvaluationResultMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? StockInfoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
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
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,relatedFile
,manufacturingLocationAddress
,manufacturersAddress
,evaluationDescription
,auditResultMissing
,expectedDocument
,decisionTaken
,approvalStatus
           ,evaluationDateMax 
           ,evaluationDateMin        
           ,auditEvaluationResultMin 
           ,auditEvaluationResultMax 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<StockInfo> ApplyFilter(
            IQueryable<StockInfo> query,
            string filterText = null
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
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.RelatedFile.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ManufacturingLocationAddress.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ManufacturersAddress.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.EvaluationDescription.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.AuditResultMissing.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ExpectedDocument.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.DecisionTaken.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ApprovalStatus.Contains(filterText)) 
            .WhereIf(evaluationDateMin.HasValue, e => e.EvaluationDate >= evaluationDateMin.Value)
            .WhereIf(evaluationDateMax.HasValue, e => e.EvaluationDate >= evaluationDateMax.Value)
            .WhereIf(auditEvaluationResultMin.HasValue, e => e.AuditEvaluationResult >= auditEvaluationResultMin.Value)
            .WhereIf(auditEvaluationResultMax.HasValue, e => e.AuditEvaluationResult >= auditEvaluationResultMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(relatedFile),e => e.RelatedFile.Contains(relatedFile)) 
            .WhereIf(!string.IsNullOrWhiteSpace(manufacturingLocationAddress),e => e.ManufacturingLocationAddress.Contains(manufacturingLocationAddress)) 
            .WhereIf(!string.IsNullOrWhiteSpace(manufacturersAddress),e => e.ManufacturersAddress.Contains(manufacturersAddress)) 
            .WhereIf(!string.IsNullOrWhiteSpace(evaluationDescription),e => e.EvaluationDescription.Contains(evaluationDescription)) 
            .WhereIf(!string.IsNullOrWhiteSpace(auditResultMissing),e => e.AuditResultMissing.Contains(auditResultMissing)) 
            .WhereIf(!string.IsNullOrWhiteSpace(expectedDocument),e => e.ExpectedDocument.Contains(expectedDocument)) 
            .WhereIf(!string.IsNullOrWhiteSpace(decisionTaken),e => e.DecisionTaken.Contains(decisionTaken)) 
            .WhereIf(!string.IsNullOrWhiteSpace(approvalStatus),e => e.ApprovalStatus.Contains(approvalStatus)) 
         ;
        }
        














        


    }
}

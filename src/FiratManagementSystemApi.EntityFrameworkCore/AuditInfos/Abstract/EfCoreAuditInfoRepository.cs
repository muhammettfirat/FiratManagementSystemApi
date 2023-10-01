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


namespace FiratManagementSystemApi.AuditInfos
{
    public abstract class EfCoreAuditInfoRepository : EfCoreRepository<FiratManagementSystemApiDbContext, AuditInfo , Guid>, IAuditInfoRepository
    {
        public EfCoreAuditInfoRepository(IDbContextProvider<FiratManagementSystemApiDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<AuditInfo>> GetListAsync(
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
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               companyPersonnel01
,
               companyPersonnel02
,
               companyPersonnel03
,
               companyPersonnel04
,
               description
,
               decisionTaken
,
               auditResultMissing
,
               expectedDocument
             ,auditDateMin 
             ,auditDateMax 
            ,auditEvaluationResultMin 
            ,auditEvaluationResultMax 
            ,scoreMin 
            ,scoreMax 
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AuditInfoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
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
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,companyPersonnel01
,companyPersonnel02
,companyPersonnel03
,companyPersonnel04
,description
,decisionTaken
,auditResultMissing
,expectedDocument
           ,auditDateMax 
           ,auditDateMin        
           ,auditEvaluationResultMin 
           ,auditEvaluationResultMax 
           ,scoreMin 
           ,scoreMax 
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<AuditInfo> ApplyFilter(
            IQueryable<AuditInfo> query,
            string filterText = null
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
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.CompanyPersonnel01.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.CompanyPersonnel02.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.CompanyPersonnel03.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.CompanyPersonnel04.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Description.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.DecisionTaken.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.AuditResultMissing.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.ExpectedDocument.Contains(filterText)) 
            .WhereIf(auditDateMin.HasValue, e => e.AuditDate >= auditDateMin.Value)
            .WhereIf(auditDateMax.HasValue, e => e.AuditDate >= auditDateMax.Value)
            .WhereIf(auditEvaluationResultMin.HasValue, e => e.AuditEvaluationResult >= auditEvaluationResultMin.Value)
            .WhereIf(auditEvaluationResultMax.HasValue, e => e.AuditEvaluationResult >= auditEvaluationResultMax.Value)
            .WhereIf(scoreMin.HasValue, e => e.Score >= scoreMin.Value)
            .WhereIf(scoreMax.HasValue, e => e.Score >= scoreMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(companyPersonnel01),e => e.CompanyPersonnel01.Contains(companyPersonnel01)) 
            .WhereIf(!string.IsNullOrWhiteSpace(companyPersonnel02),e => e.CompanyPersonnel02.Contains(companyPersonnel02)) 
            .WhereIf(!string.IsNullOrWhiteSpace(companyPersonnel03),e => e.CompanyPersonnel03.Contains(companyPersonnel03)) 
            .WhereIf(!string.IsNullOrWhiteSpace(companyPersonnel04),e => e.CompanyPersonnel04.Contains(companyPersonnel04)) 
            .WhereIf(!string.IsNullOrWhiteSpace(description),e => e.Description.Contains(description)) 
            .WhereIf(!string.IsNullOrWhiteSpace(decisionTaken),e => e.DecisionTaken.Contains(decisionTaken)) 
            .WhereIf(!string.IsNullOrWhiteSpace(auditResultMissing),e => e.AuditResultMissing.Contains(auditResultMissing)) 
            .WhereIf(!string.IsNullOrWhiteSpace(expectedDocument),e => e.ExpectedDocument.Contains(expectedDocument)) 
         ;
        }
        














        


    }
}

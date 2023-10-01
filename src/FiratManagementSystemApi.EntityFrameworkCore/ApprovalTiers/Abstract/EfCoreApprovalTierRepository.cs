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


namespace FiratManagementSystemApi.ApprovalTiers
{
    public abstract class EfCoreApprovalTierRepository : EfCoreRepository<FiratManagementSystemApiDbContext, ApprovalTier , Guid>, IApprovalTierRepository
    {
        public EfCoreApprovalTierRepository(IDbContextProvider<FiratManagementSystemApiDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<ApprovalTier>> GetListAsync(
             string filterText = null
            ,string sorting = null
            ,string definition= null 
            ,int? codeMin= null 
            ,int? codeMax= null 
            ,bool? finalTiers= null 
          
            
            ,int maxResultCount = int.MaxValue
            ,int skipCount = 0
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               definition
            ,codeMin 
            ,codeMax 
            ,finalTiers 
          
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ApprovalTierConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string definition= null 
          ,int? codeMin= null 
          ,int? codeMax= null 
           ,bool? finalTiers= null 
          
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,definition
           ,codeMin 
           ,codeMax 
           ,finalTiers   
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<ApprovalTier> ApplyFilter(
            IQueryable<ApprovalTier> query,
            string filterText = null
          ,string definition= null  
          ,int? codeMin= null 
          ,int? codeMax= null 
          ,bool? finalTiers= null 
          
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.Definition.Contains(filterText)) 
            .WhereIf(codeMin.HasValue, e => e.Code >= codeMin.Value)
            .WhereIf(codeMax.HasValue, e => e.Code >= codeMax.Value)

            .WhereIf(!string.IsNullOrWhiteSpace(definition),e => e.Definition.Contains(definition)) 
         ;
        }
        














        


    }
}

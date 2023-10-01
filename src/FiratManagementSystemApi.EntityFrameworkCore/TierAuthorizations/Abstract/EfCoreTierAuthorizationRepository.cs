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


namespace FiratManagementSystemApi.TierAuthorizations
{
    public abstract class EfCoreTierAuthorizationRepository : EfCoreRepository<FiratManagementSystemApiDbContext, TierAuthorization , Guid>, ITierAuthorizationRepository
    {
        public EfCoreTierAuthorizationRepository(IDbContextProvider<FiratManagementSystemApiDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        


        public async Task<List<TierAuthorization>> GetListAsync(
             string filterText = null
            ,string sorting = null
            ,string personnelName= null 
            ,string emailInfo= null 
            
            ,int maxResultCount = int.MaxValue
            ,int skipCount = 0
            ,CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()),filterText,
               personnelName
,
               emailInfo
            );
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TierAuthorizationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }



        public async Task<long> GetCountAsync(
         string filterText = null
          ,string personnelName= null 
          ,string emailInfo= null 
           ,CancellationToken cancellationToken = default
            )
        {
         var query = ApplyFilter((await GetDbSetAsync()), filterText,personnelName
,emailInfo
         );
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<TierAuthorization> ApplyFilter(
            IQueryable<TierAuthorization> query,
            string filterText = null
          ,string personnelName= null  
          ,string emailInfo= null  
)
        {
            return query
            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.PersonnelName.Contains(filterText)) 
            .WhereIf(!string.IsNullOrWhiteSpace(filterText),e => e.EmailInfo.Contains(filterText)) 

            .WhereIf(!string.IsNullOrWhiteSpace(personnelName),e => e.PersonnelName.Contains(personnelName)) 
            .WhereIf(!string.IsNullOrWhiteSpace(emailInfo),e => e.EmailInfo.Contains(emailInfo)) 
         ;
        }
        














        


    }
}

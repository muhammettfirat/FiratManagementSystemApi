using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.CompanyInfos
{
    public class CompanyInfoManager : DomainService
    {
        private readonly ICompanyInfoRepository _companyInfoRepository;

        public CompanyInfoManager(ICompanyInfoRepository companyInfoRepository)
        {
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<CompanyInfo> CreateAsync(
              string approvalStatus, 
              DateTime startedWorkingDate , 
              DateTime auditPeriodMonth , 
              Guid? groupId,
              Guid? approvalTierId,
        )
        {

            var companyInfo = new CompanyInfo(
             GuidGenerator.Create(),
               approvalStatus, 
               startedWorkingDate , 
               auditPeriodMonth , 
               groupId,
               approvalTierId,
             );

            return await _companyInfoRepository.InsertAsync(companyInfo);
        }

        public async Task<CompanyInfo> UpdateAsync(
           Guid id,
          string approvalStatus, 
          DateTime startedWorkingDate , 
          DateTime auditPeriodMonth , 
          Guid? groupId,
          Guid? approvalTierId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _companyInfoRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var companyInfo = await AsyncExecuter.FirstOrDefaultAsync(query);

                companyInfo.ApprovalStatus=approvalStatus;
                companyInfo.StartedWorkingDate=startedWorkingDate;         
                companyInfo.AuditPeriodMonth=auditPeriodMonth;         
                companyInfo.GroupId=groupId;
                companyInfo.ApprovalTierId=approvalTierId;

         companyInfo.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyInfoRepository.UpdateAsync(companyInfo);
        }

    }
}
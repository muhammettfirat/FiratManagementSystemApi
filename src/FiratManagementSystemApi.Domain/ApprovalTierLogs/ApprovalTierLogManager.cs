using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.ApprovalTierLogs
{
    public class ApprovalTierLogManager : DomainService
    {
        private readonly IApprovalTierLogRepository _approvalTierLogRepository;

        public ApprovalTierLogManager(IApprovalTierLogRepository approvalTierLogRepository)
        {
            _approvalTierLogRepository = approvalTierLogRepository;
        }

        public async Task<ApprovalTierLog> CreateAsync(
              string relatedFileType, 
              string approvalStatus, 
              string approvalTierName, 
              DateTime auditDate , 
              DateTime operationDate , 
              Guid? auditInfoId,
              Guid? tierAuthorizationId,
              Guid? approvalTierId,
        )
        {

            var approvalTierLog = new ApprovalTierLog(
             GuidGenerator.Create(),
               relatedFileType, 
               approvalStatus, 
               approvalTierName, 
               auditDate , 
               operationDate , 
               auditInfoId,
               tierAuthorizationId,
               approvalTierId,
             );

            return await _approvalTierLogRepository.InsertAsync(approvalTierLog);
        }

        public async Task<ApprovalTierLog> UpdateAsync(
           Guid id,
          string relatedFileType, 
          string approvalStatus, 
          string approvalTierName, 
          DateTime auditDate , 
          DateTime operationDate , 
          Guid? auditInfoId,
          Guid? tierAuthorizationId,
          Guid? approvalTierId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _approvalTierLogRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var approvalTierLog = await AsyncExecuter.FirstOrDefaultAsync(query);

                approvalTierLog.RelatedFileType=relatedFileType;
                approvalTierLog.ApprovalStatus=approvalStatus;
                approvalTierLog.ApprovalTierName=approvalTierName;
                approvalTierLog.AuditDate=auditDate;         
                approvalTierLog.OperationDate=operationDate;         
                approvalTierLog.AuditInfoId=auditInfoId;
                approvalTierLog.TierAuthorizationId=tierAuthorizationId;
                approvalTierLog.ApprovalTierId=approvalTierId;

         approvalTierLog.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _approvalTierLogRepository.UpdateAsync(approvalTierLog);
        }

    }
}
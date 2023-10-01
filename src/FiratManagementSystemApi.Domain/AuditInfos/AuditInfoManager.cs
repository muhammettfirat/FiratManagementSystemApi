using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.AuditInfos
{
    public class AuditInfoManager : DomainService
    {
        private readonly IAuditInfoRepository _auditInfoRepository;

        public AuditInfoManager(IAuditInfoRepository auditInfoRepository)
        {
            _auditInfoRepository = auditInfoRepository;
        }

        public async Task<AuditInfo> CreateAsync(
              string companyPersonnel01, 
              string companyPersonnel02, 
              string companyPersonnel03, 
              string companyPersonnel04, 
              string description, 
              string decisionTaken, 
              string auditResultMissing, 
              string expectedDocument, 
              DateTime auditDate , 
              int? auditEvaluationResult, 
    
              int? score, 
    
              Guid? companyInfoId,
        )
        {

            var auditInfo = new AuditInfo(
             GuidGenerator.Create(),
               companyPersonnel01, 
               companyPersonnel02, 
               companyPersonnel03, 
               companyPersonnel04, 
               description, 
               decisionTaken, 
               auditResultMissing, 
               expectedDocument, 
               auditDate , 
               auditEvaluationResult, 
    
               score, 
    
               companyInfoId,
             );

            return await _auditInfoRepository.InsertAsync(auditInfo);
        }

        public async Task<AuditInfo> UpdateAsync(
           Guid id,
          string companyPersonnel01, 
          string companyPersonnel02, 
          string companyPersonnel03, 
          string companyPersonnel04, 
          string description, 
          string decisionTaken, 
          string auditResultMissing, 
          string expectedDocument, 
          DateTime auditDate , 
          int? auditEvaluationResult, 

          int? score, 

          Guid? companyInfoId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _auditInfoRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var auditInfo = await AsyncExecuter.FirstOrDefaultAsync(query);

                auditInfo.CompanyPersonnel01=companyPersonnel01;
                auditInfo.CompanyPersonnel02=companyPersonnel02;
                auditInfo.CompanyPersonnel03=companyPersonnel03;
                auditInfo.CompanyPersonnel04=companyPersonnel04;
                auditInfo.Description=description;
                auditInfo.DecisionTaken=decisionTaken;
                auditInfo.AuditResultMissing=auditResultMissing;
                auditInfo.ExpectedDocument=expectedDocument;
                auditInfo.AuditDate=auditDate;         
                 auditInfo.AuditEvaluationResult=auditEvaluationResult;
                 auditInfo.Score=score;
                auditInfo.CompanyInfoId=companyInfoId;

         auditInfo.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _auditInfoRepository.UpdateAsync(auditInfo);
        }

    }
}
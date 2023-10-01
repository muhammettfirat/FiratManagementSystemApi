using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FiratManagementSystemApi.StockInfos
{
    public class StockInfoManager : DomainService
    {
        private readonly IStockInfoRepository _stockInfoRepository;

        public StockInfoManager(IStockInfoRepository stockInfoRepository)
        {
            _stockInfoRepository = stockInfoRepository;
        }

        public async Task<StockInfo> CreateAsync(
              string relatedFile, 
              string manufacturingLocationAddress, 
              string manufacturersAddress, 
              string evaluationDescription, 
              string auditResultMissing, 
              string expectedDocument, 
              string decisionTaken, 
              string approvalStatus, 
              DateTime evaluationDate , 
              int? auditEvaluationResult, 
    
              Guid? groupId,
              Guid? approvalTierId,
        )
        {

            var stockInfo = new StockInfo(
             GuidGenerator.Create(),
               relatedFile, 
               manufacturingLocationAddress, 
               manufacturersAddress, 
               evaluationDescription, 
               auditResultMissing, 
               expectedDocument, 
               decisionTaken, 
               approvalStatus, 
               evaluationDate , 
               auditEvaluationResult, 
    
               groupId,
               approvalTierId,
             );

            return await _stockInfoRepository.InsertAsync(stockInfo);
        }

        public async Task<StockInfo> UpdateAsync(
           Guid id,
          string relatedFile, 
          string manufacturingLocationAddress, 
          string manufacturersAddress, 
          string evaluationDescription, 
          string auditResultMissing, 
          string expectedDocument, 
          string decisionTaken, 
          string approvalStatus, 
          DateTime evaluationDate , 
          int? auditEvaluationResult, 

          Guid? groupId,
          Guid? approvalTierId,
            [CanBeNull] string concurrencyStamp = null
        )
        {

            var queryable = await _stockInfoRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var stockInfo = await AsyncExecuter.FirstOrDefaultAsync(query);

                stockInfo.RelatedFile=relatedFile;
                stockInfo.ManufacturingLocationAddress=manufacturingLocationAddress;
                stockInfo.ManufacturersAddress=manufacturersAddress;
                stockInfo.EvaluationDescription=evaluationDescription;
                stockInfo.AuditResultMissing=auditResultMissing;
                stockInfo.ExpectedDocument=expectedDocument;
                stockInfo.DecisionTaken=decisionTaken;
                stockInfo.ApprovalStatus=approvalStatus;
                stockInfo.EvaluationDate=evaluationDate;         
                 stockInfo.AuditEvaluationResult=auditEvaluationResult;
                stockInfo.GroupId=groupId;
                stockInfo.ApprovalTierId=approvalTierId;

         stockInfo.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _stockInfoRepository.UpdateAsync(stockInfo);
        }

    }
}
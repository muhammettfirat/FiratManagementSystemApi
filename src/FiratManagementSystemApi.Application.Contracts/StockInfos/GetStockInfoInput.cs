using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.StockInfos
{
    public class GetStockInfosInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  RelatedFile { get; set; } 
        public string  ManufacturingLocationAddress { get; set; } 
        public string  ManufacturersAddress { get; set; } 
        public string  EvaluationDescription { get; set; } 
        public string  AuditResultMissing { get; set; } 
        public string  ExpectedDocument { get; set; } 
        public string  DecisionTaken { get; set; } 
        public string  ApprovalStatus { get; set; } 
             
        public DateTime? EvaluationDateMin { get; set; } 
        public DateTime? EvaluationDateMax { get; set; }  
        public int? AuditEvaluationResultMin { get; set; } 
        public int? AuditEvaluationResultMax { get; set; } 
        public GetStockInfosInput()
        {

        }
    }
}

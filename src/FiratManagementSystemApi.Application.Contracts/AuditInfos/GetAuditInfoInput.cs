using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.AuditInfos
{
    public class GetAuditInfosInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  CompanyPersonnel01 { get; set; } 
        public string  CompanyPersonnel02 { get; set; } 
        public string  CompanyPersonnel03 { get; set; } 
        public string  CompanyPersonnel04 { get; set; } 
        public string  Description { get; set; } 
        public string  DecisionTaken { get; set; } 
        public string  AuditResultMissing { get; set; } 
        public string  ExpectedDocument { get; set; } 
             
        public DateTime? AuditDateMin { get; set; } 
        public DateTime? AuditDateMax { get; set; }  
        public int? AuditEvaluationResultMin { get; set; } 
        public int? AuditEvaluationResultMax { get; set; } 
        public int? ScoreMin { get; set; } 
        public int? ScoreMax { get; set; } 
        public GetAuditInfosInput()
        {

        }
    }
}

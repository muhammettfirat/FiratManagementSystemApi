using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.ApprovalTierLogs
{
    public class GetApprovalTierLogsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  RelatedFileType { get; set; } 
        public string  ApprovalStatus { get; set; } 
        public string  ApprovalTierName { get; set; } 
             
        public DateTime? AuditDateMin { get; set; } 
        public DateTime? AuditDateMax { get; set; }  
        public DateTime? OperationDateMin { get; set; } 
        public DateTime? OperationDateMax { get; set; }  
        public GetApprovalTierLogsInput()
        {

        }
    }
}

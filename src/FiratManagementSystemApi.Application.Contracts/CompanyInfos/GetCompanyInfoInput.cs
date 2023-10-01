using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.CompanyInfos
{
    public class GetCompanyInfosInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  ApprovalStatus { get; set; } 
             
        public DateTime? StartedWorkingDateMin { get; set; } 
        public DateTime? StartedWorkingDateMax { get; set; }  
        public DateTime? AuditPeriodMonthMin { get; set; } 
        public DateTime? AuditPeriodMonthMax { get; set; }  
        public GetCompanyInfosInput()
        {

        }
    }
}

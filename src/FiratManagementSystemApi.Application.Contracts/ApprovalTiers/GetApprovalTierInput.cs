using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.ApprovalTiers
{
    public class GetApprovalTiersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Definition { get; set; } 
             
        public int? CodeMin { get; set; } 
        public int? CodeMax { get; set; } 
        public bool? FinalTiers { get; set; }  
        public GetApprovalTiersInput()
        {

        }
    }
}

using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.TierAuthorizations
{
    public class GetTierAuthorizationsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  PersonnelName { get; set; } 
        public string  EmailInfo { get; set; } 
             
        public GetTierAuthorizationsInput()
        {

        }
    }
}

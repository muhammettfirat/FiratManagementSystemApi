using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.Groups
{
    public class GetGroupsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Definition { get; set; } 
             
        public GetGroupsInput()
        {

        }
    }
}

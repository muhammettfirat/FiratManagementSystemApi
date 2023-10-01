using Volo.Abp.Application.Dtos;
using System;

namespace FiratManagementSystemApi.DocumentTypes
{
    public class GetDocumentTypesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  Code { get; set; } 
        public string  Definition { get; set; } 
             
        public GetDocumentTypesInput()
        {

        }
    }
}

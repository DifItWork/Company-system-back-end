using CRM.Models;

namespace CRM.DTO
{
    public class GetCrmDto
    {
        public BackgroundInformation BackgroundInformation { get; set; }
        public ICollection<BusinessExecutionStatuDto> BusinessExecutionStatuDto { get; set; }
    }
}

using CRM.Models;
using System.Collections;

namespace CRM.DTO
{
    public class CrmDto
    {
        public BackgroundInformation BackgroundInformation { get; set; }
        public ICollection<BusinessExecutionStatu> BusinessExecutionStatu { get; set; }
    }
}

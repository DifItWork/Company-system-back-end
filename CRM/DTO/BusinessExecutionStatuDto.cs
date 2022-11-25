namespace CRM.DTO
{
    public class BusinessExecutionStatuDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;

        public string Date { get; set; }

        public string State { get; set; } = null!;
    }
}

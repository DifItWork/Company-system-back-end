using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class BusinessExecutionStatu
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime Date { get; set; }

    public string State { get; set; } = null!;
}

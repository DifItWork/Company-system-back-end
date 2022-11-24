using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class BackgroundInformation
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string NegotiateYear { get; set; } = null!;

    public string? Fax { get; set; }

    public string AreaAddress { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string CellPhone { get; set; }

    public string CompantPhone { get; set; }

    public string Area { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CompanyUrl { get; set; } = null!;

    public string IndustryType { get; set; } = null!;

    public string Remark { get; set; } = null!;
}

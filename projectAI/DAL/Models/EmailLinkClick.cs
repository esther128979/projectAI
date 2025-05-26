using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class EmailLinkClick
{
    public int ClickId { get; set; }

    public int LinkId { get; set; }

    public DateTime ClickDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? UserAgent { get; set; }

    public bool? Converted { get; set; }

    public virtual EmailLink Link { get; set; } = null!;
}

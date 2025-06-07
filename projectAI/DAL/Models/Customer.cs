using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Customer
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public int? AgeGroup { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public virtual AgeGroup? AgeGroupNavigation { get; set; }

    public virtual ICollection<EmailLink> EmailLinks { get; set; } = new List<EmailLink>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}

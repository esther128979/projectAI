using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerNumber { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Gender { get; set; }

    public int? AgeGroup { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public virtual AgeGroup? AgeGroupNavigation { get; set; }

    public virtual Order? Order { get; set; }
}

using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BLCustomer
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

    public virtual BLAgeGroup? AgeGroupNavigation { get; set; }

    public virtual BLOrder? Order { get; set; }
}

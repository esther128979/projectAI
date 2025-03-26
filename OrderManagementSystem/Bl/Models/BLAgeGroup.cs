using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BLAgeGroup
{
    public int AgeCode { get; set; }

    public string? AgeDescrepition { get; set; }

    public virtual ICollection<BLCustomer> Customers { get; set; } = new List<BLCustomer>();

    public virtual ICollection<BLMovie> Movies { get; set; } = new List<BLMovie>();
}

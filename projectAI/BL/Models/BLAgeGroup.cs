using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLAgeGroup
{
    public int AgeCode { get; set; }

    public string? AgeDescrepition { get; set; }

    public virtual ICollection<BLUser> Users { get; set; } = new List<BLUser>();

    public virtual ICollection<BLMovie> Movies { get; set; } = new List<BLMovie>();
}

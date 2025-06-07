using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLCategory
{
    public int CategoryCode { get; set; }

    public string? CategoryDescreption { get; set; }

    public virtual ICollection<BLMovie> Movies { get; set; } = new List<BLMovie>();
}

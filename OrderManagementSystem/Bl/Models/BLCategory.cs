using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BLCategory
{
    public int CategoryCode { get; set; }

    public string? CategoryDescreption { get; set; }

    public virtual ICollection<BLMovie> Movies { get; set; } = new List<BLMovie>();
}

using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class OrderDetail
{
    public int OrderCode { get; set; }

    public int? CategoryCode { get; set; }

    public int? UsageDays { get; set; }
}

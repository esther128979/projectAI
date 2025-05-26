using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MovieId { get; set; }

    public int ViewerCount { get; set; }

    public int ViewCount { get; set; }

    public decimal SubTotal { get; set; }

    public string? LinkForMovie { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}

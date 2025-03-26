using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public DateTime DateOrder { get; set; }

    public bool Status { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Customer IdOrderNavigation { get; set; } = null!;
}

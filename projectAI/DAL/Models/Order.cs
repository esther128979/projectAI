using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public DateTime DateOrder { get; set; }

    public bool Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

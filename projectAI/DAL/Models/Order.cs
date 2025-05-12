using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class Order
{
    [Key]
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateOrder { get; set; }

    public bool Status { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    [ForeignKey("IdOrder")]
    [InverseProperty("Order")]
    public virtual Customer IdOrderNavigation { get; set; } = null!;
}

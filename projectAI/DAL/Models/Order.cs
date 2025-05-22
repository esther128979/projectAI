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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // מונע עדכון – רק קריאה
    public decimal? TotalAmount { get; set; }

    [ForeignKey("IdCustomer")]
    [InverseProperty("Orders")]
    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    [NotMapped]
    public string Token { get; set; }
}

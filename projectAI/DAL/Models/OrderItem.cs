using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class OrderItem
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MovieId { get; set; }

    public int ViewerCount { get; set; }

    public int ViewCount { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal SubTotal { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("OrderItems")]
    public virtual Movie Movie { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;
}

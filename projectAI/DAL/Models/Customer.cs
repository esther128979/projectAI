using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Index("CustomerNumber", Name = "UQ__tmp_ms_x__48D47E1E8014A696", IsUnique = true)]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(9)]
    public string CustomerNumber { get; set; } = null!;

    [StringLength(255)]
    public string CustomerName { get; set; } = null!;

    [StringLength(15)]
    public string? Phone { get; set; }

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string? Gender { get; set; }

    public int? AgeGroup { get; set; }

    public byte[]? ProfilePicture { get; set; }

    [ForeignKey("AgeGroup")]
    [InverseProperty("Customers")]
    public virtual AgeGroup? AgeGroupNavigation { get; set; }

    [InverseProperty("IdOrderNavigation")]
    public virtual Order? Order { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class Customer
{
    [Key]
    public int UserId { get; set; }

    [StringLength(255)]
    public string? FullName { get; set; }

    [StringLength(15)]
    public string? Phone { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Gender { get; set; }

    public int? AgeGroup { get; set; }

    public byte[]? ProfilePicture { get; set; }

    [ForeignKey("AgeGroup")]
    [InverseProperty("Customers")]
    public virtual AgeGroup? AgeGroupNavigation { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<EmailLink> EmailLinks { get; set; } = new List<EmailLink>();

    [InverseProperty("IdCustomerNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("UserId")]
    [InverseProperty("Customer")]
    public virtual User User { get; set; } = null!;
}

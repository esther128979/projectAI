using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("AgeGroup")]
public partial class AgeGroup
{
    [Key]
    public int AgeCode { get; set; }

    [StringLength(50)]
    public string? AgeDescrepition { get; set; }

    [InverseProperty("AgeGroupNavigation")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("AgeCodeNavigation")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

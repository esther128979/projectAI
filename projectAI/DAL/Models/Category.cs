using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("Category")]
public partial class Category
{
    [Key]
    public int CategoryCode { get; set; }

    [StringLength(50)]
    public string? CategoryDescription { get; set; }

    [InverseProperty("CategoryCodeNavigation")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

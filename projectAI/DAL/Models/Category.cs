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
    public string? CategoryDescreption { get; set; }

    [InverseProperty("CodeCategoryNavigation")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

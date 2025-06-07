using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Category
{
    public int CategoryCode { get; set; }

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Category
{
    public int CategoryCode { get; set; }

    public string? CategoryDescreption { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

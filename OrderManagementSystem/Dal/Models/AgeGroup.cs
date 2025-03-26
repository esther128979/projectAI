using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class AgeGroup
{
    public int AgeCode { get; set; }

    public string? AgeDescrepition { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

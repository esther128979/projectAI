using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AgeGroup
{
    public int AgeCode { get; set; }

    public string? AgeDescription { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

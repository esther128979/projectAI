using System;
using System.Collections.Generic;

namespace jwt.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

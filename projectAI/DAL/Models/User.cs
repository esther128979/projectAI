using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? IsActive { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Role Role { get; set; } = null!;
}

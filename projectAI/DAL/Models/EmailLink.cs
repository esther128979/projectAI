using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class EmailLink
{
    public int LinkId { get; set; }

    public int UserId { get; set; }

    public int MovieId { get; set; }

    public string UniqueToken { get; set; } = null!;

    public string EmailType { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int? ViewCount { get; set; }

    public int? ViewLimit { get; set; }

    public virtual ICollection<EmailLinkClick> EmailLinkClicks { get; set; } = new List<EmailLinkClick>();

    public virtual Movie Movie { get; set; } = null!;

    public virtual Customer User { get; set; } = null!;
}

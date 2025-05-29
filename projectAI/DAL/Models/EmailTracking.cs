using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class EmailTracking
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public Guid? Token { get; set; }

    public DateTime? DateSent { get; set; }

    public DateTime? DateClicked { get; set; }
}

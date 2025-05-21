using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("EmailTracking")]
public partial class EmailTracking
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    public Guid? Token { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateSent { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateClicked { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Index("LinkId", Name = "IX_EmailLinkClicks_LinkID")]
public partial class EmailLinkClick
{
    [Key]
    [Column("ClickID")]
    public int ClickId { get; set; }

    [Column("LinkID")]
    public int LinkId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ClickDate { get; set; }

    [Column("IPAddress")]
    [StringLength(50)]
    public string? Ipaddress { get; set; }

    [StringLength(500)]
    public string? UserAgent { get; set; }

    public bool? Converted { get; set; }

    [ForeignKey("LinkId")]
    [InverseProperty("EmailLinkClicks")]
    public virtual EmailLink Link { get; set; } = null!;
}

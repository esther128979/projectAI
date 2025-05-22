using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Index("UniqueToken", Name = "IX_EmailLinks_UniqueToken")]
[Index("UserId", Name = "IX_EmailLinks_UserID")]
[Index("UniqueToken", Name = "UQ__EmailLin__64D6B76BBD003BDE", IsUnique = true)]
public partial class EmailLink
{
    [Key]
    [Column("LinkID")]
    public int LinkId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("MovieID")]
    public int MovieId { get; set; }

    [StringLength(100)]
    public string UniqueToken { get; set; } = null!;

    [StringLength(50)]
    public string EmailType { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpirationDate { get; set; }

    [Column("ViewLimit")]
    public int? ViewLimit { get; set; }

    [Column("ViewCount")]
    public int? ViewCount { get; set; }


    [InverseProperty("Link")]
    public virtual ICollection<EmailLinkClick> EmailLinkClicks { get; set; } = new List<EmailLinkClick>();

    [ForeignKey("MovieId")]
    [InverseProperty("EmailLinks")]
    public virtual Movie Movie { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("EmailLinks")]
    public virtual Customer User { get; set; } = null!;
}

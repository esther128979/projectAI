using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class Movie
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    public int? CategoryCode { get; set; }

    public int? AgeCode { get; set; }

    public bool? ThereIsWoman { get; set; }

    public int? Length { get; set; }

    public int? AmountOfViews { get; set; }

    public DateOnly? FilmProductionDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? BasePrice { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? ExtraViewerPrice { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? ExtraViewPrice { get; set; }

    public string? Link { get; set; }

    [ForeignKey("AgeCode")]
    [InverseProperty("Movies")]
    public virtual AgeGroup? AgeCodeNavigation { get; set; }

    [ForeignKey("CategoryCode")]
    [InverseProperty("Movies")]
    public virtual Category? CategoryCodeNavigation { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<EmailLink> EmailLinks { get; set; } = new List<EmailLink>();

    [InverseProperty("Movie")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

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

    public int? CodeCategory { get; set; }

    public int? AgeCode { get; set; }

    public bool? ThereIsWoman { get; set; }

    public int? Length { get; set; }

    public int? AmountOfUses { get; set; }

    public DateOnly? FilmProductionDate { get; set; }

    public int? Price { get; set; }

    [Column(TypeName = "text")]
    public string? Link { get; set; }

    [ForeignKey("AgeCode")]
    [InverseProperty("Movies")]
    public virtual AgeGroup? AgeCodeNavigation { get; set; }

    [ForeignKey("CodeCategory")]
    [InverseProperty("Movies")]
    public virtual Category? CodeCategoryNavigation { get; set; }
}

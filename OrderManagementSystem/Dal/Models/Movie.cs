using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Movie
{
    public int Id { get; set; }

    public int? CodeCategory { get; set; }

    public int? AgeCode { get; set; }

    public bool? ThereIsWoman { get; set; }

    public int? Length { get; set; }

    public int? AmountOfUses { get; set; }

    public DateOnly? FilmProductionDate { get; set; }

    public virtual AgeGroup? AgeCodeNavigation { get; set; }

    public virtual Category? CodeCategoryNavigation { get; set; }
}

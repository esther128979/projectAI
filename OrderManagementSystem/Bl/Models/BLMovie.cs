using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BLMovie
{
    public int Id { get; set; }

    public int? CodeCategory { get; set; }

    public int? AgeCode { get; set; }

    public bool? ThereIsWoman { get; set; }

    public int? Length { get; set; }

    public int? AmountOfUses { get; set; }

    public DateOnly? FilmProductionDate { get; set; }

    public virtual BLAgeGroup? AgeCodeNavigation { get; set; }

    public virtual BLCategory? CodeCategoryNavigation { get; set; }
}

using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

public partial class BLMovie
{
    public int Id { get; set; }

    public eCategoryGroup CodeCategory { get; set; }

    public eAgeGroup ageGroup { get; set; } //?

    public bool? ThereIsWoman { get; set; }

    public int? Length { get; set; }

    public int? AmountOfUses { get; set; }

    public DateOnly? FilmProductionDate { get; set; }

    public virtual BLAgeGroup? AgeCodeNavigation { get; set; }

    public int? Price { get; set; }

    public string? Link { get; set; }

    public virtual BLCategory? CodeCategoryNavigation { get; set; }
    //public string MovieName { get; set; }
    //public string MovieDescription { get; set; }
    //public string MovieUrl { get; set; }
    //public int MoviePrice { get; set; }

}

using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? CategoryCode { get; set; }

    public int? AgeCode { get; set; }

    public bool? ThereIsWoman { get; set; }

    public int? Length { get; set; }

    public int? AmountOfViews { get; set; }

    public DateOnly? FilmProductionDate { get; set; }

    public decimal? BasePrice { get; set; }

    public decimal? ExtraViewerPrice { get; set; }

    public decimal? ExtraViewPrice { get; set; }

    public string? Link { get; set; }

    public string? Image { get; set; }

    public virtual AgeGroup? AgeCodeNavigation { get; set; }

    public virtual Category? CategoryCodeNavigation { get; set; }

    public virtual ICollection<EmailLink> EmailLinks { get; set; } = new List<EmailLink>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

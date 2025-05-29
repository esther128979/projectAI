using BL.Models;
using DAL.Models;
namespace BL.Models;
public class BLMovie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public int CodeCategory { get; set; }
    public int AgeGroup { get; set; }

    public bool HasWoman { get; set; }
    public int? LengthMinutes { get; set; }

    public int TotalViews { get; set; }
    public int TotalViewers { get; set; }

    public DateOnly? ProductionDate { get; set; }

    public decimal? PriceBase { get; set; }
    public decimal? PricePerExtraViewer { get; set; }
    public decimal? PricePerExtraView { get; set; }

    public string? MovieLink { get; set; }
    public string? Image { get; set; }

    public Category? CodeCategoryNavigation { get; set; }
    public AgeGroup? AgeGroupNavigation { get; set; }

    // ✅ תכונה מחושבת
    public decimal FinalPrice
    {
        get
        {
            var basePrice = PriceBase ?? 0;
            var viewerPrice = PricePerExtraViewer ?? 0;
            var viewPrice = PricePerExtraView ?? 0;

            return basePrice + (TotalViewers * viewerPrice) + (TotalViews * viewPrice);
        }
    }
}

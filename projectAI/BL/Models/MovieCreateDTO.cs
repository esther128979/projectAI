using BL.Models;

namespace BL.Models
{
    public class MovieCreateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CodeCategory { get; set; }
        public int? AgeGroup { get; set; }
        public bool? HasWoman { get; set; }
        public int? LengthMinutes { get; set; }
        public DateOnly? ProductionDate { get; set; } 
        public decimal? PriceBase { get; set; }
        public decimal? PricePerExtraViewer { get; set; } = 0;
        public decimal? PricePerExtraView { get; set; } = 0;
        public string? MovieLink { get; set; }
        public string? Image { get; set; }
    }

}

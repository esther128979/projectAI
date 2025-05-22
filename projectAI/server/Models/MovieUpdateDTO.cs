using BL.Models;

namespace server.Models
{
    public class MovieUpdateDTO
    {
        public int Id { get; set; } // מזהה הסרט לעדכון

        public string? Name { get; set; }
        public string? Description { get; set; }
        public eCategoryGroup? CodeCategory { get; set; }
        public eAgeGroup? AgeGroup { get; set; }
        public bool? HasWoman { get; set; }
        public int? LengthMinutes { get; set; }
        public DateOnly? ProductionDate { get; set; }
        public decimal? PriceBase { get; set; }
        public decimal? PricePerExtraViewer { get; set; } = 0;
        public decimal? PricePerExtraView { get; set; } = 0;
        public string? MovieLink { get; set; }
    }
}

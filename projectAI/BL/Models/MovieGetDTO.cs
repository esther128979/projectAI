namespace BL.Models
{
    public class MovieGetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? AgeGroupName { get; set; }
        public bool? HasWoman { get; set; }
        public int LengthMinutes { get; set; }
        public int TotalViews { get; set; }
        public int TotalViewers { get; set; }
        public DateOnly ProductionDate { get; set; }
        public decimal PriceBase { get; set; }
        public decimal PricePerExtraViewer { get; set; }
        public decimal PricePerExtraView { get; set; }
        public decimal FinalPrice { get; set; }
        public string MovieLink { get; set; }
        public string? Image { get; set; }

    }

}

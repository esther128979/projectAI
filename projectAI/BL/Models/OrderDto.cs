namespace BL.Models
{
    public class OrderCreateDTO
    {
        public int CustomerId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new();
    }

    public class OrderItemDTO
    {
        public int MovieId { get; set; }
        public int ViewerCount { get; set; }
        public int ViewCount { get; set; }

    }
    public class OrderItemEmailDto
    {
        public string MovieName { get; set; }
        public int ViewerCount { get; set; }
        public int ViewCount { get; set; }
        public string OrderLink { get; set; }
    }

}

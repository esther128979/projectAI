
namespace BL.Models;

public partial class BLOrderItem
{

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }
        public int ViewerCount { get; set; }
        public int ViewCount { get; set; }
        public decimal SubTotal { get; set; }

        public BLMovie? Movie { get; set; }
        public string? LinkForMovie { get; set; }


}

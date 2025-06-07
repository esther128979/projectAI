
namespace BL.Models;

public partial class BLOrder
{


        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Status { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<BLOrderItem> OrderItems { get; set; } = new();
        public decimal? TotalAmount { get; set; }//הצגה בלבד- זה מחושב ע"י טריגר בדטהבייס
        public string Token { get; set; }


}

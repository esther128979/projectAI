
namespace BL.Models;

public partial class BLOrder
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }
    public List<BLMovie> MoviesList { get; set; } = new List<BLMovie>();
  
    public DateTime DateOrder { get; set; }

    public eStatus Status { get; set; }

    public decimal TotalAmount { get; set; }


    //public OrderDetail OrderDetail { get; set; }

    //public virtual BLCustomer IdOrderNavigation { get; set; } = null!;

}

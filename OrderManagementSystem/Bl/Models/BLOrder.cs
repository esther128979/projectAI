namespace Bl.Models;

public partial class BLOrder
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public DateTime DateOrder { get; set; }

    public bool Status { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual BLCustomer IdOrderNavigation { get; set; } = null!;
}

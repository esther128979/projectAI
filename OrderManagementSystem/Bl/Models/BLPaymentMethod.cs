namespace Bl.Models;

public partial class BLPaymentMethod
{
    public int OrderCode { get; set; }

    public string CreditCardNumber { get; set; } = null!;

    public DateOnly ExpirationDate { get; set; }

    public string CreditCardCompany { get; set; } = null!;
}

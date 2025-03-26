using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class PaymentMethod
{
    public int OrderCode { get; set; }

    public string CreditCardNumber { get; set; } = null!;

    public DateOnly ExpirationDate { get; set; }

    public string CreditCardCompany { get; set; } = null!;
}

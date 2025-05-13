using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class PaymentMethod
{
    [Key]
    public int OrderCode { get; set; }

    [StringLength(19)]
    public string? CreditCardNumber { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    [StringLength(50)]
    public string? CreditCardCompany { get; set; }
}

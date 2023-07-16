using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Bank
{
    public decimal Id { get; set; }

    public string? Cardnumber { get; set; }

    public string? Cardholder { get; set; }

    public DateTime? Expirationdate { get; set; }

    public string? Cvv { get; set; }

    public decimal? Balance { get; set; }
}

using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class ContactUsEntry
{
    public decimal Id { get; set; }

    public string? Subject { get; set; }

    public string? Content { get; set; }

    public string? Email { get; set; }

    public decimal? Phonenumber { get; set; }

    public decimal? Adminid { get; set; }

    public virtual User? Admin { get; set; }
}

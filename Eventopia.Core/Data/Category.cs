using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Category
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public string? Imagepath { get; set; }

    public string? Description { get; set; }

    public DateTime? Creationdate { get; set; }

    public decimal? Adminid { get; set; }

    public virtual User? Admin { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}

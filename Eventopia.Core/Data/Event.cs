using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Event
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public decimal? Attendingcost { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public string? Status { get; set; }

    public string? Eventdescription { get; set; }

    public string? Imagepath { get; set; }

    public decimal? Eventcapacity { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public decimal? Eventcreatorid { get; set; }

    public decimal? Categoryid { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? Eventcreator { get; set; }
}

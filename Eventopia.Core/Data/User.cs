using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class User
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Username is required")]
	[StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
	public string? Username { get; set; }

	[StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters and less than 50")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
        ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character")]
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email address")]
	[StringLength(50, ErrorMessage = "Email must be less than 50 characters long")]
	public string? Email { get; set; }

	[MaxLength(50, ErrorMessage = "VerificationCode cannot exceed 50 characters.")]
	public string? Verfiicationcode { get; set; }
	

	[Required(ErrorMessage = "UserStatus is required.")]
	[MaxLength(20, ErrorMessage = "UserStatus cannot exceed 20 characters.")]
	public string? UserStatus { get; set; }

	[Required(ErrorMessage = "Roleid is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "RoleId must be a positive number.")]
	public decimal? RoleId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<ContactUsEntry> ContactUsEntries { get; set; } = new List<ContactUsEntry>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Page> Pages { get; set; } = new List<Page>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

	public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}

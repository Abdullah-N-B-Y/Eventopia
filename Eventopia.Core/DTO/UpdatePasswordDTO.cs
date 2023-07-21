
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.DTO;

public class UpdatePasswordDTO
{
    [Required(ErrorMessage = "Password is required")]
    public string? OldPassword { set; get; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 50 characters")]
    public string? NewPassword { set; get; }

    [Required(ErrorMessage = "Password is required")]
    public string? ConfirmPassword { set; get; }
}

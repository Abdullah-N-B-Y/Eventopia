using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;


namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileSettingController : ControllerBase
{
    private readonly IProfileSettingService _profileSettingService;

    public ProfileSettingController(IProfileSettingService profileSettingService)
    {
        _profileSettingService = profileSettingService;
    }

    [HttpPut]
    public void SetTheme(int userId, string theme)
    {
        _profileSettingService.SetTheme(userId, theme);
    }

    [HttpGet]
    public string GetTheme(int userId) 
    {
        return _profileSettingService.GetTheme(userId);
    }
}

using Eventopia.Core.Repository;
using Eventopia.Core.Service;


namespace Eventopia.Infra.Service;

public class ProfileSettingService : IProfileSettingService
{
    private readonly IProfileSettingRepository _profileSettingRepository;

    public ProfileSettingService(IProfileSettingRepository profileSettingRepository)
    {
        _profileSettingRepository = profileSettingRepository;
    }

    public void SetTheme(int userId, string theme)
    {
        _profileSettingRepository.SetTheme(userId, theme);
    }

    public string GetTheme(int userId)
    {
        return _profileSettingRepository.GetTheme(userId);
    }
}

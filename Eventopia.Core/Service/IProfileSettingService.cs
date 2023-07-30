

namespace Eventopia.Core.Service;

public interface IProfileSettingService
{
    void SetTheme(int userId, string theme);
    string GetTheme(int userId);
}

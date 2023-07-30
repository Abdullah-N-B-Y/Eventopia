

namespace Eventopia.Core.Service;

public interface IProfileSettingService
{
    void SetTheme(int userId, string theme);
    void GetTheme(int userId);
}



namespace Eventopia.Core.Repository;

public interface IProfileSettingRepository
{
    void SetTheme(int userId, string theme);
    void GetTheme(int userId);
}

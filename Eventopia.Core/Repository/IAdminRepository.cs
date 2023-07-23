
namespace Eventopia.Core.Repository;

public interface IAdminRepository
{
    void EventAcceptation(int id, string status);

    void BannedUser(int userId);
    void UnbannedUser(int userId);
}


namespace Eventopia.Core.Repository;

public interface IAdminRepository
{
    void EventAcceptation(int id, string status);

    bool BannedUser(int userId);
    bool UnbannedUser(int userId);
}

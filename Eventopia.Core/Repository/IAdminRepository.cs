
namespace Eventopia.Core.Repository;

public interface IAdminRepository
{
    void EventAcceptation(int id, string status);
}


using System.Security.Cryptography;

namespace Eventopia.Core.Service;

public interface IAdminService
{
    void EventAcceptation(int id, string status);
    void BannedUser(int userId);
    void UnbannedUser(int userId);
}

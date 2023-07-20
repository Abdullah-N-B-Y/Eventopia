
using System.Security.Cryptography;

namespace Eventopia.Core.Service;

public interface IAdminService
{
    void EventAcceptation(int id, string status);
}

using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface IUserRepository
{
    List<User>GetAllUsers();
}

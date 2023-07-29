using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Service;

public interface IUserService : IService<User>
{
	User GetUserByUserName(string username);
    bool UpdateUserProfile(Profile profile, string password);
    bool UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO);
    List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails();
}


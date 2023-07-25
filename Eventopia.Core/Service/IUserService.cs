using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Service;

public interface IUserService : IService<User>
{
	User GetUserByUserName(string username);
	void UpdateUserProfile(Profile profile, string password);
	void UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO);
    List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails();
}


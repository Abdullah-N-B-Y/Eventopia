using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Repository;

public interface IUserRepository : IRepository<User>
{
	User GetUserByUserName(string username);
	bool UpdateUserProfile(Profile profile, string password);
    bool UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO);
	List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails();
}

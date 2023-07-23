using Eventopia.Core.Data;
using Eventopia.Core.DTO;


namespace Eventopia.Core.Repository;

public interface IUserRepository : IRepository<User>
{
	User GetUserByUserName(string username);
	void UpdateUserProfile(Profile profile, string password);
	void UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO);

}

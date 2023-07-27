using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Repository;

public interface IAuthRepository
{
	User Login(LoginDTO loginDTO);
	bool CheckEmailExists(string email);
	bool CheckUsernameExists(string username);
}

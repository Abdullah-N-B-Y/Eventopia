using Eventopia.Core.DTO;

namespace Eventopia.Core.Service;

public interface IAuthService
{
	string? Login(LoginDTO loginDTO);
	bool CheckEmailExists(string email);
	bool CheckUsernameExists(string username);
}

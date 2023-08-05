using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Service;

public interface IUserService : IService<User>
{
	User GetUserByUserName(string username);
	User GetUserByEmail(string email);
	bool UpdateUserProfile(Profile profile, string password);
    bool UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO);
    List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails();
	bool ForgotPassword(string email);
	bool CheckPasswordResetToken(string email, string token);
	bool ResetForgottenPassword(string email, string newPassword);
}


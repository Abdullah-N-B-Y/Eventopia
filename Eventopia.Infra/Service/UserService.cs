using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Utility;

namespace Eventopia.Infra.Service;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public bool CreateNew(User user)
	{
		return _userRepository.CreateNew(user);
	}

	public bool Delete(int id)
	{
		return _userRepository.Delete(id);
	}

	public List<User> GetAll()
	{
		return _userRepository.GetAll();
	}

	public User GetById(int id)
	{
		return _userRepository.GetById(id);
	}

	public User GetUserByUserName(string username)
	{
		return _userRepository.GetUserByUserName(username);
	}

	public bool Update(User user)
	{
		return _userRepository.Update(user);
	}

    public bool UpdateUserProfile(Profile profile, string password)
    {
		return _userRepository.UpdateUserProfile(profile, password);
    }

    public bool UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO)
    {
		return _userRepository.UpdatePassword(id, updatePasswordDTO);
    }

    public List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails()
    {
		return _userRepository.GetAllRegisteredUsersDetails();
    }

	public User GetUserByEmail(string email)
	{
		return _userRepository.GetUserByEmail(email);
	}

	public bool ForgotPassword(string email)
	{
		User user = _userRepository.GetUserByEmail(email);
		if (user == null)
			return false; // Maybe replace with EmailNotFoundException

		string verificationToken = Guid.NewGuid().ToString();
		user.VerificationCode = verificationToken;

		_userRepository.Update(user);

		string emailSubject = "Password Reset Request";
		string emailBody = $"The following code is your account password reset verification code.\n\n" +
			$"{verificationToken}\n\n" +
			$"This is a one time use verification code.";

		EmailUtility.SendEmailAsync(emailSubject, emailBody, email);

		return true;
	}

	public bool CheckPasswordResetToken(string email, string token)
	{
		User user = _userRepository.GetUserByEmail(email);
		if (user == null)
			return false; // Maybe replace with EmailNotFoundException
		if (user.VerificationCode != token)
			return false; //maybe replace with InvalidVerificationCodeException

		return true;
	}

	public bool ResetForgottenPassword(string email, string newPassword)
	{
		User user = _userRepository.GetUserByEmail(email);
		if (user == null)
			return false; // Maybe replace with EmailNotFoundException

		user.Password = newPassword;
		user.VerificationCode = "";

		_userRepository.Update(user);

		return true;
	}
}

using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

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
}

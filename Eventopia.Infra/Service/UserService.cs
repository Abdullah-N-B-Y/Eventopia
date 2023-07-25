﻿using Eventopia.Core.Data;
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

	public void CreateNew(User user)
	{
		_userRepository.CreateNew(user);
	}

	public void Delete(int id)
	{
		_userRepository.Delete(id);
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

	public void Update(User user)
	{
		_userRepository.Update(user);
	}

    public void UpdateUserProfile(Profile profile, string password)
    {
		_userRepository.UpdateUserProfile(profile, password);
    }

    public void UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO)
    {
		_userRepository.UpdatePassword(id, updatePasswordDTO);
    }

    public List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails()
    {
		return _userRepository.GetAllRegisteredUsersDetails();
    }
}

using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Service
{
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

        public void UpdatePassword(int id, string oldPassword, string newPassword, string confirmPassword)
        {
            _userRepository.UpdatePassword(id, oldPassword, newPassword, confirmPassword);
        }
    }
}

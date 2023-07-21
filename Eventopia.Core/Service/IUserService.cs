using Eventopia.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Service
{
	public interface IUserService : IService<User>
	{
		User GetUserByUserName(string username);
        void UpdateUserProfile(Profile profile, string password);
        void UpdatePassword(int id, string oldPassword, string newPassword, string confirmPassword);
    }
}

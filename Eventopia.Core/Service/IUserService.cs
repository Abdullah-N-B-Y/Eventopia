﻿using Eventopia.Core.Data;
using Eventopia.Core.DTO;
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
        void UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO);
    }
}

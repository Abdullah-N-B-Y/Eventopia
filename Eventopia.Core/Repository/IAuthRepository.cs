﻿using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Repository
{
	public interface IAuthRepository
	{
		User Login(LoginDTO loginDTO);
		bool CheckEmailExists(string email);
		bool CheckUsernameExists(string username);
	}
}
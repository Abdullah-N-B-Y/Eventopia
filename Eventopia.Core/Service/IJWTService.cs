﻿using Eventopia.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Service
{
	public interface IJWTService
	{
		string? Login(string username, string password);
	}
}

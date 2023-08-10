using Eventopia.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Repository
{
	public interface IProfileRepository: IRepository<Profile>
	{
		Profile GetProfileByUserId(int id);
		Profile GetProfileByPhoneNumber(string phoneNumber);
	}
}

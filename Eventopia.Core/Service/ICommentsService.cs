using Eventopia.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Service
{
	public interface ICommentsService: IService<Comment>
	{
		List<Comment> GetEventComments(int eventId);
		List<Comment> GetUserComments(int userId);
		List<Comment> GetUserCommentsOnEvent(int eventId, int userId);
	}
}

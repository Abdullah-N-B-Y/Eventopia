using Eventopia.Core.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Repository
{
	public interface ICommentsRepository : IRepository<Comment>
	{
		List<Comment> GetEventComments(int eventId);
		List<Comment> GetUserComments(int userId);
		List<Comment> GetUserCommentsOnEvent(int eventId, int userId);
	}
}

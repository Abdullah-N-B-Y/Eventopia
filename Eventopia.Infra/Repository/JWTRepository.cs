using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Repository
{
	public class JWTRepository : IJWTRepository
	{
		private readonly IDbContext _dBContext;

		public JWTRepository(IDbContext dbContext)
		{
			_dBContext = dbContext;
		}

		public User Login(string username, string password)
		{
			var parameters = new DynamicParameters();
			parameters.Add("User_NAME", username, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("PASS", password, dbType: DbType.String, direction: ParameterDirection.Input);
			IEnumerable<User> result = _dBContext.Connection.Query<User>("Auth_Package.GetUser", parameters, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}
	}
}

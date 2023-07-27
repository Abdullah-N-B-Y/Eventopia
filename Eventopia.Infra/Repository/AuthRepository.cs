using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using System.Data;


namespace Eventopia.Infra.Repository;

public class AuthRepository : IAuthRepository
{
	private readonly IDbContext _dBContext;

	public AuthRepository(IDbContext dbContext)
	{
		_dBContext = dbContext;
	}

	public User Login(LoginDTO loginDTO)
	{
		var parameters = new DynamicParameters();
		parameters.Add("User_NAME", loginDTO.Username, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("PASS", loginDTO.Password, dbType: DbType.String, direction: ParameterDirection.Input);
		IEnumerable<User> result = _dBContext.Connection.Query<User>("Auth_Package.GetUser", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

	public bool CheckEmailExists(string email)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_email", email, DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_email_exists", DbType.Int32, direction: ParameterDirection.Output);
		_dBContext.Connection.Execute("Auth_Package.CheckEmailExists", parameters, commandType: CommandType.StoredProcedure);

		return parameters.Get<int>("p_email_exists") == 1;
	}

	public bool CheckUsernameExists(string username)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_username", username, DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_username_exists", DbType.Int32, direction: ParameterDirection.Output);
		_dBContext.Connection.Execute("Auth_Package.CheckUsernameExists", parameters, commandType: CommandType.StoredProcedure);

		return parameters.Get<int>("p_username_exists") == 1;
	}
}

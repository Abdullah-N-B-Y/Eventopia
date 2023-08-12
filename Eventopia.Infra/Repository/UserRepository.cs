using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using System.Data;


namespace Eventopia.Infra.Repository;

public class UserRepository : IUserRepository
{
	private readonly IDbContext _dBContext;

	public UserRepository(IDbContext dbContext)
	{
		_dBContext = dbContext;
	}

	public bool CreateNew(User user)
	{
		DynamicParameters parameters = new DynamicParameters();

		parameters.Add("p_Username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_VerificationCode", user.Verfiicationcode, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_UserStatus", user.UserStatus, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_RoleID", user.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("User_Package.CreateUser", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

	public bool Delete(int id)
	{
		var parameters = new DynamicParameters();

		parameters.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("User_Package.DeleteUserById", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

	public List<User> GetAll()
	{
		IEnumerable<User> result = _dBContext.Connection.Query<User>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
		return result.ToList();
	}

	public User GetById(int id)
	{
		var parameters = new DynamicParameters();
		parameters.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		IEnumerable<User> result = _dBContext.Connection.Query<User>("User_Package.GetUserById", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

	public User GetUserByUserName(string name)
	{
        var parameters = new DynamicParameters();

		parameters.Add("p_Name", name, dbType: DbType.String, direction: ParameterDirection.Input);

		IEnumerable<User> result = _dBContext.Connection.Query<User>("User_Package.GetUserByUserName", parameters, commandType: CommandType.StoredProcedure);
		
		return result.FirstOrDefault();
	}

	public bool Update(User user)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_UserID", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_Username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_VerificationCode", user.Verfiicationcode, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_UserStatus", user.UserStatus, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_RoleID", user.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("User_Package.UpdateUserByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool UpdateUserProfile(Profile profile, string password)
    {
		DynamicParameters parameters = new DynamicParameters();

		parameters.Add("p_UserId", profile.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_Password", password, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_FirstName", profile.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_LastName", profile.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_PhoneNumber", profile.PhoneNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);

		parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

		_dBContext.Connection.Execute("USER_PACKAGE.UpdateUserProfile", parameters, commandType: CommandType.StoredProcedure);

		return parameters.Get<int>("p_IsSuccessed") == 1;
    }

	public bool UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO)
	{
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_OldPassword", updatePasswordDTO.OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_NewPassword", updatePasswordDTO.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_ConfirmPassword", updatePasswordDTO.ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("User_Package.UpdatePassword", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails()
    {
		return _dBContext.Connection.Query<RegisteredUsersDetailsDTO>("User_Package.GetAllRegisteredUsersDetails", commandType: CommandType.StoredProcedure).ToList();
    }

	public User GetUserByEmail(string email)
	{
		var parameters = new DynamicParameters();

		parameters.Add("p_Email", email, dbType: DbType.String, direction: ParameterDirection.Input);

		IEnumerable<User> result = _dBContext.Connection.Query<User>("User_Package.GetUserByEmail", parameters, commandType: CommandType.StoredProcedure);

		return result.FirstOrDefault();
	}
}

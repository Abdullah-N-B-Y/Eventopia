using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class ProfileRepository : IProfileRepository
{
    private readonly IDbContext _dBContext;

    public ProfileRepository(IDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public bool CreateNew(Profile profile)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_FirstName", profile.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_LastName", profile.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_ImagePath", profile.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_PhoneNumber", profile.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_Gender", profile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_DateOfBirth", profile.DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("p_Bio", profile.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_Rate", profile.Rate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_UserID", profile.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("PROFILE_PACKAGE.CreateProfile", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool Delete(int id)
    {
        var parameters = new DynamicParameters();

        parameters.Add("p_ProfileId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("PROFILE_PACKAGE.DeleteProfileByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public List<Profile> GetAll()
    {
        IEnumerable<Profile> result = _dBContext.Connection.Query<Profile>("PROFILE_PACKAGE.GetAllProfiles", commandType: CommandType.StoredProcedure);
        return result.ToList();
    }

    public Profile GetById(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_ProfileId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        IEnumerable<Profile> result = _dBContext.Connection.Query<Profile>("PROFILE_PACKAGE.GetProfileByID", parameters, commandType: CommandType.StoredProcedure);
        return result.FirstOrDefault();
    }

    public Profile GetProfileByUserId(int id) 
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
        return _dBContext.Connection.Query<Profile>("Profile_Package.GetProfileByUserId", parameters,commandType:CommandType.StoredProcedure).FirstOrDefault();
    }

	public Profile GetProfileByPhoneNumber(string phoneNumber)
	{
		var parameters = new DynamicParameters();
		parameters.Add("p_PhoneNumber", phoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
		IEnumerable<Profile> result = _dBContext.Connection.Query<Profile>("PROFILE_PACKAGE.GetProfileByPhoneNumber", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

	public bool Update(Profile profile)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_ProfileId", profile.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_FirstName", profile.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_LastName", profile.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_ImagePath", profile.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_PhoneNumber", profile.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_Gender", profile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_DateOfBirth", profile.DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("p_Bio", profile.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_Rate", profile.Rate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_UserID", profile.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("PROFILE_PACKAGE.UpdateProfileByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public void UpdateUserProfileImage(int userId, string imagePath)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_ProfileId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_ImagePath", imagePath, dbType: DbType.String, direction: ParameterDirection.Input);

        _dBContext.Connection.Execute("Profile_Package.UpdateUserProfileImage", parameters, commandType: CommandType.StoredProcedure);
    }
}

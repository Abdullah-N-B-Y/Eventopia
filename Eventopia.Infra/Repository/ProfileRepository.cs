using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class ProfileRepository : IRepository<Profile>
{
    private readonly IDbContext _dBContext;

    public ProfileRepository(IDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public bool CreateNew(Profile profile)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_FirstName", profile.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_LastName", profile.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_ImagePath", profile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_PhoneNumber", profile.Phonenumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_Gender", profile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_DateOfBirth", profile.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("p_Bio", profile.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_Rate", profile.Rate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_UserID", profile.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("PROFILE_PACKAGE.CreateProfile", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool Delete(int id)
    {
        var parameters = new DynamicParameters();

        parameters.Add("p_ProfileId", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

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
        parameters.Add("p_ProfileId", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        IEnumerable<Profile> result = _dBContext.Connection.Query<Profile>("PROFILE_PACKAGE.GetProfileByID", parameters, commandType: CommandType.StoredProcedure);
        return result.FirstOrDefault();
    }

    public bool Update(Profile profile)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_ProfileId", profile.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_FirstName", profile.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_LastName", profile.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_ImagePath", profile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_PhoneNumber", profile.Phonenumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_Gender", profile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_DateOfBirth", profile.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("p_Bio", profile.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_Rate", profile.Rate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_UserID", profile.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("PROFILE_PACKAGE.UpdateProfileByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}

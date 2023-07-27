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

    public void CreateNew(Profile profile)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("FIRSTNAME", profile.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("LASTNAME", profile.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("IMAGEPATH", profile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("PHONENUMBER", profile.Phonenumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("GENDER", profile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("DATEOFBIRTH", profile.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("BIO", profile.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("RATE", profile.Rate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("USERID", profile.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        var result = _dBContext.Connection.Execute("PROFILE_PACKAGE.CreateProfile", parameters, commandType: CommandType.StoredProcedure);
    }

    public void Delete(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("PROFILE_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        var result = _dBContext.Connection.Execute("PROFILE_PACKAGE.DeleteProfileByID", parameters, commandType: CommandType.StoredProcedure);
    }

    public void Delete(decimal id)
    {
        throw new NotImplementedException();
    }

    public List<Profile> GetAll()
    {
        IEnumerable<Profile> result = _dBContext.Connection.Query<Profile>("PROFILE_PACKAGE.GetAllProfiles", commandType: CommandType.StoredProcedure);
        return result.ToList();
    }

    public Profile GetById(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("PROFILE_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        IEnumerable<Profile> result = _dBContext.Connection.Query<Profile>("PROFILE_PACKAGE.GetProfileByID", parameters, commandType: CommandType.StoredProcedure);
        return result.FirstOrDefault();
    }

    public Profile GetById(decimal id)
    {
        throw new NotImplementedException();
    }

    public void Update(Profile profile)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("PROFILE_ID", profile.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("FIRSTNAME", profile.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("LASTNAME", profile.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("IMAGEPATH", profile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("PHONENUMBER", profile.Phonenumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("GENDER", profile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("DATEOFBIRTH", profile.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("BIO", profile.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("RATE", profile.Rate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("USERID", profile.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        var result = _dBContext.Connection.Execute("PROFILE_PACKAGE.UpdateProfileByID", parameters, commandType: CommandType.StoredProcedure);
    }
}

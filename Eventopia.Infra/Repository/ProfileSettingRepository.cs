using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class ProfileSettingRepository : IProfileSettingRepository
{
    private readonly IDbContext _dbContext;

    public ProfileSettingRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SetTheme(int userId, string theme)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId", userId, dbType:DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_Theme", theme, dbType:DbType.String, direction: ParameterDirection.Input);

        _dbContext.Connection.Execute("ProfileSetting_Package.SetTheme",parameters, commandType:CommandType.StoredProcedure);
    }

    public string GetTheme(int userId)
    {
        throw new NotImplementedException();
    }
}

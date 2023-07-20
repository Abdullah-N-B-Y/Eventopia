
using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class AdminRepository : IAdminRepository
{
    private readonly IDbContext _dbContext;

    public AdminRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void EventAcceptation(int id, string status)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_event_id", id,dbType:DbType.Int32,direction:ParameterDirection.Input);
        parameters.Add("p_event_status", status, dbType:DbType.String,direction:ParameterDirection.Input);

        _dbContext.Connection.Execute("Admin_Package.EventAcceptation", parameters, commandType: CommandType.StoredProcedure);
    }
}

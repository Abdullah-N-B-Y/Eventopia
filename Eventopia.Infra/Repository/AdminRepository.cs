using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.DTO;
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

    public bool BannedUser(int userId)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        _dbContext.Connection.Execute("Admin_Package.BannedUser", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool UnbannedUser(int userId)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        _dbContext.Connection.Execute("Admin_Package.UnbannedUser", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public StatisticsDTO GetStatistics()
    {
        var parameters = new DynamicParameters();

        var statistics = new StatisticsDTO();

        var numUsersParameters = new DynamicParameters();
        numUsersParameters.Add("p_num_users", DbType.Int32, direction: ParameterDirection.Output);
        _dbContext.Connection.Execute("Admin_Package.GetNumberOfUsers", numUsersParameters, commandType: CommandType.StoredProcedure);
        statistics.NumberOfUsers = numUsersParameters.Get<int>("p_num_users");

        var numEventsParameters = new DynamicParameters();
        numEventsParameters.Add("p_num_events", DbType.Int32, direction: ParameterDirection.Output);
        _dbContext.Connection.Execute("Admin_Package.GetNumberOfEvents", numEventsParameters, commandType: CommandType.StoredProcedure);
        statistics.NumberOfEvents = numEventsParameters.Get<int>("p_num_events");

        var maxAttendeesParameters = new DynamicParameters();
        maxAttendeesParameters.Add("p_event_id", DbType.Int32, direction: ParameterDirection.Output);
        maxAttendeesParameters.Add("p_max_attendees", DbType.Int32, direction: ParameterDirection.Output);
        _dbContext.Connection.Execute("Admin_Package.GetMaxEventAttendees", maxAttendeesParameters, commandType: CommandType.StoredProcedure);
        statistics.MaxEventID = maxAttendeesParameters.Get<int>("p_event_id");
        statistics.MaxEventAttendees = maxAttendeesParameters.Get<int>("p_max_attendees");

        return statistics;
    }
}

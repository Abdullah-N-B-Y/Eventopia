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

    public bool EventAcceptation(int id, string status)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_event_id", id,dbType:DbType.Int32,direction:ParameterDirection.Input);
        parameters.Add("p_event_status", status, dbType:DbType.String,direction:ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType:DbType.Int32,direction:ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.EventAcceptation", parameters, commandType: CommandType.StoredProcedure);

        int a = parameters.Get<int>("p_IsSuccessed");
        return a == 1;
    }

    public bool BannedUser(int userId)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.BannedUser", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool UnbannedUser(int userId)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.UnbannedUser", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public StatisticsDTO GetStatistics()
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_num_users", DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("p_num_events", DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("p_event_id", DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("p_max_attendees", DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.GetStats", parameters, commandType: CommandType.StoredProcedure);

        var statistics = new StatisticsDTO
        {
            NumberOfUsers = parameters.Get<int>("p_num_users"),
            NumberOfEvents = parameters.Get<int>("p_num_events"),
            MaxEventID = parameters.Get<int>("p_event_id"),
            MaxEventAttendees = parameters.Get<int>("p_max_attendees")
        };

        return statistics;
    }

    public GetBenefitsReportDTO GetBenefitsReport(DateTime startDate, DateTime endDate)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_start_date", startDate, DbType.Date, ParameterDirection.Input);
        parameters.Add("p_end_date", endDate, DbType.Date, ParameterDirection.Input);
        parameters.Add("p_monthly_benefits", DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("p_annual_benefits", DbType.Decimal, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.GetBenefitsReport", parameters, commandType: CommandType.StoredProcedure);

        var benefits = new GetBenefitsReportDTO
        {
            MonthlyBenefits = parameters.Get<decimal>("p_monthly_benefits"),
            AnnualBenefits = parameters.Get<decimal>("p_annual_benefits")
        };

        return benefits;
    }

}

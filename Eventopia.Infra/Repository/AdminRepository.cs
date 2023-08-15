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

    public bool BannedUser(string username)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_Username", username, dbType: DbType.String, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.BannedUser", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool UnbannedUser(string username)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_Username", username, dbType: DbType.String, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.UnbannedUser", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public StatisticsDTO GetStatistics()
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_UsersNumber", DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("p_EventsNumber", DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("p_EventId", DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("p_MaxAttendance", DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Admin_Package.GetStats", parameters, commandType: CommandType.StoredProcedure);

        var statistics = new StatisticsDTO
        {
            NumberOfUsers = parameters.Get<int>("p_UsersNumber"),
            NumberOfEvents = parameters.Get<int>("p_EventsNumber"),
            MaxEventID = parameters.Get<int>("p_EventId"),
            MaxEventAttendees = parameters.Get<int>("p_MaxAttendance")
        };
        return statistics;
    }

    public GetBenefitsReportDTO GetBenefitsReport(SearchBetweenDatesDTO searchDTO)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_StartDate", searchDTO.StartDate, DbType.Date, ParameterDirection.Input);
        parameters.Add("p_EndDate", searchDTO.EndDate, DbType.Date, ParameterDirection.Input);
        //parameters.Add("p_MonthlyBenefits", DbType.Decimal, direction: ParameterDirection.Output);
        //parameters.Add("p_AnnualBenefits", DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("p_MonthlyBenefits", dbType: DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("p_AnnualBenefits", dbType: DbType.Decimal, direction: ParameterDirection.Output);




        _dbContext.Connection.Execute("Admin_Package.GetBenefitsReport", parameters, commandType: CommandType.StoredProcedure);

        var benefits = new GetBenefitsReportDTO
        {
            //MonthlyBenefits = parameters.Get<decimal?>("p_MonthlyBenefits"),
            //AnnualBenefits = parameters.Get<decimal?>("p_AnnualBenefits")

            MonthlyBenefits = parameters.Get<decimal?>("p_MonthlyBenefits") ?? 0,
            AnnualBenefits = parameters.Get<decimal?>("p_AnnualBenefits") ?? 0

        };

        return benefits;
    }

}

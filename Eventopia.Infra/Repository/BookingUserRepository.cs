

using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Eventopia.Infra.Repository;

public class BookingUserRepository : IBookingUserRepository
{
    private readonly IDbContext _dbContext;

    public BookingUserRepository(IDbContext dbContext)
    {
         _dbContext = dbContext;
    }

    public void AddUserToBooking(Booking booking)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId",booking.Userid, dbType:DbType.Int32, direction:ParameterDirection.Input);
        parameters.Add("p_BookingDate", booking.Bookingdate, dbType:DbType.Date, direction:ParameterDirection.Input);
        parameters.Add("p_EventId", booking.Eventid, dbType:DbType.Int32, direction:ParameterDirection.Input);

        parameters.Add("p_Is_successed", dbType:DbType.Int32, direction:ParameterDirection.Output);
        int p_Is_successed = parameters.Get<int>("p_Is_successed");

        int numberOfAffectedColumns = _dbContext.Connection.Execute("BookingUsers_Package.AddUserToBooking", parameters, commandType: CommandType.StoredProcedure);
    }

    public void DeleteUserFromBooking(int userId, int eventId)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_EventId", eventId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_Is_successed", dbType: DbType.Int32, direction: ParameterDirection.Output);
        int p_Is_successed = parameters.Get<int>("p_Is_successed");

        int numberOfAffectedColumns = _dbContext.Connection.Execute("BookingUsers_Package.DeleteUserFromBooking", parameters, commandType: CommandType.StoredProcedure);

    }
}

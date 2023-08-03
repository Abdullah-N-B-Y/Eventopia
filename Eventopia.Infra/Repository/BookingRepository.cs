using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly IDbContext _dbContext;

    public BookingRepository(IDbContext dBContext)
    {
        _dbContext = dBContext;
    }

    public bool CreateNew(Booking booking)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("p_BookingDate", booking.Bookingdate, dbType:DbType.Date, direction:ParameterDirection.Input);
        parameters.Add("p_UserId", booking.Userid, dbType:DbType.Int32, direction:ParameterDirection.Input);
        parameters.Add("p_EventId", booking.Eventid, dbType:DbType.Int32, direction:ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Booking_Package.CreateBooking", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public Booking GetById(int id)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_BookingId", id, dbType:DbType.Int32,direction:ParameterDirection.Input);

        var result = _dbContext.Connection.Query<Booking>("Booking_Package.GetBookingById", parameters, commandType: CommandType.StoredProcedure);

        return result.FirstOrDefault();
    }

    public List<Booking> GetAll()
    {
        return _dbContext.Connection.Query<Booking>("Booking_Package.GetAllBooking", commandType: CommandType.StoredProcedure).ToList();
    }

    public bool Update(Booking t)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_BookingId",t.Id,dbType:DbType.Int32,direction:ParameterDirection.Input);
        parameters.Add("p_BookingDate", t.Bookingdate,dbType:DbType.Date,direction:ParameterDirection.Input);
        parameters.Add("p_UserId", t.Userid,dbType:DbType.Int32,direction:ParameterDirection.Input);
        parameters.Add("p_EventId", t.Eventid,dbType:DbType.Int32,direction:ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Booking_Package.UpdateBooking", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool Delete(int id)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_BookingId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Booking_Package.DeleteBooking",parameters,commandType:CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool DeleteUserFromBooking(int userId, int eventId)
    {
        DynamicParameters parameters= new DynamicParameters();

        parameters.Add("p_UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_EventId", eventId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Booking_Package.DeleteUserFromBooking",parameters,commandType:CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}

using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class BookingRepository : IRepository<Booking>
{
    private readonly IDbContext _dBContext;

    public BookingRepository(IDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public void CreateNew(Booking booking)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("p_BookingDate", booking.Bookingdate, dbType:DbType.Date, direction:ParameterDirection.Input);
        parameters.Add("p_UserId", booking.Userid, dbType:DbType.Int32, direction:ParameterDirection.Input);
        parameters.Add("p_EventId", booking.Eventid, dbType:DbType.Int32, direction:ParameterDirection.Input);
        parameters.Add("p_Is_successed", dbType:DbType.Int32, direction:ParameterDirection.Output);
        int isSuccessed = parameters.Get<int>("p_Is_successed");

        int numberOfAffectedColumns = _dBContext.Connection.Execute("Booking_Package.CreateBooking", parameters, commandType: CommandType.StoredProcedure);
    }

    public Booking GetById(int id)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_BookingId", dbType:DbType.Int32,direction:ParameterDirection.Input);

        return _dBContext.Connection.Query<Booking>("Booking_Package.GetBookingById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
    }

    public List<Booking> GetAll()
    {
        return _dBContext.Connection.Query<Booking>("Booking_Package.GetAllBooking", commandType: CommandType.StoredProcedure).ToList();
    }

    public void Update(Booking t)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_BookingId",t.Id,dbType:DbType.Int32,direction:ParameterDirection.Input);
        parameters.Add("p_BookingDate", t.Bookingdate,dbType:DbType.Date,direction:ParameterDirection.Input);
        parameters.Add("p_UserId", t.Userid,dbType:DbType.Int32,direction:ParameterDirection.Input);
        parameters.Add("p_EventId", t.Eventid,dbType:DbType.Int32,direction:ParameterDirection.Input);

        int numberOfAffectedColumns = _dBContext.Connection.Execute("Booking_Package.UpdateBooking", parameters, commandType: CommandType.StoredProcedure);
    }

    public void Delete(int id)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_BookingId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);

        int numberOfAffectedColumns = _dBContext.Connection.Execute("Booking_Package.DeleteBooking",parameters,commandType:CommandType.StoredProcedure);
    }
    
}

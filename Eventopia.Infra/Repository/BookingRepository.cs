﻿using Dapper;
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

    public void CreateBooking(Booking booking)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("p_BookingDate", booking.Bookingdate, dbType:DbType.Date, direction:ParameterDirection.Input);
        parameters.Add("p_UserId", booking.Userid, dbType:DbType.Int32, direction:ParameterDirection.Input);
        parameters.Add("p_EventId", booking.Eventid, dbType:DbType.Int32, direction:ParameterDirection.Input);
        parameters.Add("p_Is_successed", dbType:DbType.Int32, direction:ParameterDirection.Output);
        int isSuccessed = parameters.Get<int>("p_Is_successed");
    }
}
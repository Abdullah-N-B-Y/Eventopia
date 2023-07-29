using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class EventRepository : IEventRepository
{
    private readonly IDbContext _dBContext;

    public EventRepository(IDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public List<Event> SearchEventsByName(string eventName)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_Name", eventName, dbType: DbType.String, direction: ParameterDirection.Input);

        IEnumerable<Event> result = _dBContext.Connection.Query<Event>("EVENT_PACKAGE.SearchEventsByName", parameters, commandType: CommandType.StoredProcedure);
        return result.ToList();
    }
    
    public List<Event> SearchBetweenDates(DateTime startDate, DateTime endDate)
    {
        var parameters = new DynamicParameters();
        parameters.Add("START_DATE", startDate, dbType: DbType.Date, direction: ParameterDirection.Input);
        parameters.Add("END_DATE", endDate, dbType: DbType.Date, direction: ParameterDirection.Input);

        IEnumerable<Event> result = _dBContext.Connection.Query<Event>("EVENT_PACKAGE.SearchEventsBetweenDates", parameters, commandType: CommandType.StoredProcedure);
        return result.ToList();
    }

    public bool CreateNew(Event eventObj)
	{
		DynamicParameters parameters = new DynamicParameters();

		parameters.Add("p_Name", eventObj.Name, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_AttendingCost", eventObj.Attendingcost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_StartDate", eventObj.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_EndDate", eventObj.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_EventDescription", eventObj.Eventdescription, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", eventObj.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_EventCapacity", eventObj.Eventcapacity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Latitude", eventObj.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_Longitude", eventObj.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_EventCreatorID", eventObj.Eventcreatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_CategoryID", eventObj.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Decimal, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("EVENT_PACKAGE.CreateEvent", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool Delete(int id)
    {
		var parameters = new DynamicParameters();

		parameters.Add("p_EventID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Decimal, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("EVENT_PACKAGE.DeleteEventByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public List<Event> GetAll()
    {
        IEnumerable<Event> result = _dBContext.Connection.Query<Event>("EVENT_PACKAGE.GetAllEvents", commandType: CommandType.StoredProcedure);
        return result.ToList();
    }

    public Event GetById(int id)
    {
		var parameters = new DynamicParameters();
		parameters.Add("p_EventID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		IEnumerable<Event> result = _dBContext.Connection.Query<Event>("EVENT_PACKAGE.GetEventByID", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

    public bool Update(Event eventObj)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_EventID", eventObj.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Name", eventObj.Name, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_AttendingCost", eventObj.Attendingcost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_StartDate", eventObj.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_EndDate", eventObj.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_Status", eventObj.Status, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_EventDescription", eventObj.Eventdescription, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", eventObj.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_EventCapacity", eventObj.Eventcapacity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Latitude", eventObj.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Longitude", eventObj.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_EventCreatorID", eventObj.Eventcreatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_CategoryID", eventObj.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Decimal, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("EVENT_PACKAGE.UpdateEventByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}

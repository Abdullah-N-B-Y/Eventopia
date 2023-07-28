using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using SixLabors.ImageSharp;
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

    public void CreateNew(Event @event)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_Name", @event.Name, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_AttendingCost", @event.Attendingcost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_StartDate", @event.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_EndDate", @event.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_Status", @event.Status, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_EventDescription", @event.Eventdescription, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", @event.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_EventCapacity", @event.Eventcapacity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Latitude", @event.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_Longitude", @event.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_EventCreatorID", @event.Eventcreatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_CategoryID", @event.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        var result = _dBContext.Connection.Execute("EVENT_PACKAGE.CreateEvent", parameters, commandType: CommandType.StoredProcedure);
    }

    public void Delete(int id)
    {
		var parameters = new DynamicParameters();
		parameters.Add("p_EventID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		var result = _dBContext.Connection.Execute("EVENT_PACKAGE.DeleteEventByID", parameters, commandType: CommandType.StoredProcedure);
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

    public void Update(Event @event)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("p_EventID", @event.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Name", @event.Name, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_AttendingCost", @event.Attendingcost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_StartDate", @event.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_EndDate", @event.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_Status", @event.Status, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_EventDescription", @event.Eventdescription, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", @event.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_EventCapacity", @event.Eventcapacity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Latitude", @event.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_Longitude", @event.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_EventCreatorID", @event.Eventcreatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_CategoryID", @event.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

		var result = _dBContext.Connection.Execute("EVENT_PACKAGE.UpdateEventByID", parameters, commandType: CommandType.StoredProcedure);
    }
}

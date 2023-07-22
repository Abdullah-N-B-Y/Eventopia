using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Eventopia.Infra.Repository
{
    public class EventRepository : IRepository<Event>
    {
        private readonly IDbContext _dBContext;

        public EventRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void CreateNew(Event @event)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("NAME", @event.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("ATTENDINGCOST", @event.Attendingcost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("STARTDATE", @event.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("ENDDATE", @event.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("STATUS", @event.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("EVENTDESCRIPTION", @event.Eventdescription, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("IMAGEPATH", @event.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("EVENTCAPACITY", @event.Eventcapacity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("LATITUDE", @event.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("LONGITUDE", @event.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("EVENTCREATORID", @event.Eventcreatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("CATEGORYID", @event.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = _dBContext.Connection.Execute("EVENT_PACKAGE.CreateEvent", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(decimal id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EVENT_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = _dBContext.Connection.Execute("EVENT_PACKAGE.DeleteEventByID", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAll()
        {
            IEnumerable<Event> result = _dBContext.Connection.Query<Event>("EVENT_PACKAGE.GetAllEvents", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Event GetById(decimal id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EVENT_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            IEnumerable<Event> result = _dBContext.Connection.Query<Event>("EVENT_PACKAGE.GetEventByID", parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Event @event)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EVENT_ID", @event.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("NAME", @event.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("ATTENDINGCOST", @event.Attendingcost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("STARTDATE", @event.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("ENDDATE", @event.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("STATUS", @event.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("EVENTDESCRIPTION", @event.Eventdescription, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("IMAGEPATH", @event.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("EVENTCAPACITY", @event.Eventcapacity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("LATITUDE", @event.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("LONGITUDE", @event.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("EVENTCREATORID", @event.Eventcreatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("CATEGORYID", @event.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = _dBContext.Connection.Execute("EVENT_PACKAGE.UpdateEventByID", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

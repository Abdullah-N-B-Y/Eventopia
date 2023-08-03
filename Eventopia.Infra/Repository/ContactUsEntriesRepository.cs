using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository
{
	public class ContactUsEntriesRepository : IRepository<ContactUsEntry>
	{
		private readonly IDbContext _dBContext;

		public ContactUsEntriesRepository(IDbContext dBContext)
		{
			_dBContext = dBContext;
		}

		public bool CreateNew(ContactUsEntry entry)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("p_Subject", entry.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Content", entry.Content, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Email", entry.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_PhoneNumber", entry.Phonenumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
			parameters.Add("p_AdminId", entry.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

			_dBContext.Connection.Execute("CONTACT_US_ENTRIES_Package.CreateEntry", parameters, commandType: CommandType.StoredProcedure);

			return parameters.Get<int>("p_IsSuccessed") == 1;
		}

		public bool Delete(int id)
		{
			var parameters = new DynamicParameters();

			parameters.Add("p_EntryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

			_dBContext.Connection.Execute("CONTACT_US_ENTRIES_Package.DeleteEntryByID", parameters, commandType: CommandType.StoredProcedure);

			return parameters.Get<int>("p_IsSuccessed") == 1;
		}

		public List<ContactUsEntry> GetAll()
		{
			IEnumerable<ContactUsEntry> result = _dBContext.Connection.Query<ContactUsEntry>("CONTACT_US_ENTRIES_Package.GetAllEntries", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public ContactUsEntry GetById(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("p_EntryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			IEnumerable<ContactUsEntry> result = _dBContext.Connection.Query<ContactUsEntry>("CONTACT_US_ENTRIES_Package.GetEntryByID", parameters, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public bool Update(ContactUsEntry entry)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("p_EntryId", entry.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			parameters.Add("p_Subject", entry.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Content", entry.Content, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Email", entry.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_PhoneNumber", entry.Phonenumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
			parameters.Add("p_AdminId", entry.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

			_dBContext.Connection.Execute("CONTACT_US_ENTRIES_Package.UpdateEntryByID", parameters, commandType: CommandType.StoredProcedure);

			return parameters.Get<int>("p_IsSuccessed") == 1;
		}
	}
}

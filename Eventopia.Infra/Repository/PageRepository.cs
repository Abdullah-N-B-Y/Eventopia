using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Repository
{
	public class PageRepository : IRepository<Page>
	{

		private readonly IDbContext _dBContext;

		public PageRepository(IDbContext dBContext)
		{
			_dBContext = dBContext;
		}

		public void CreateNew(Page page)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("CONTENT_1", page.Content1, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("CONTENT_2", page.Content2, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("IMAGEPATH", page.Backgroundimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("ADMIN_ID", page.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = _dBContext.Connection.Execute("PAGE_PACKAGE.CreatePage", parameters, commandType: CommandType.StoredProcedure);
		}

		public void Delete(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("PAGE_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = _dBContext.Connection.Execute("Page_Package.DeletePage", parameters, commandType: CommandType.StoredProcedure);
		}

		public List<Page> GetAll()
		{
			IEnumerable<Page> result = _dBContext.Connection.Query<Page>("Page_Package.GetAllPages", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public Page GetById(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("PAGE_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			IEnumerable<Page> result = _dBContext.Connection.Query<Page>("Page_Package.GetPageById", parameters, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public void Update(Page page)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("PAGE_ID", page.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			parameters.Add("CONTENT_1", page.Content1, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("CONTENT_2", page.Content2, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("IMAGEPATH", page.Backgroundimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("ADMIN_ID", page.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = _dBContext.Connection.Execute("PAGE_PACKAGE.UpdatePage", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}

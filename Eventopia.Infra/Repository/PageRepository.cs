using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;


namespace Eventopia.Infra.Repository;

public class PageRepository : IRepository<Page>
{
	private readonly IDbContext _dBContext;

	public PageRepository(IDbContext dBContext)
	{
		_dBContext = dBContext;
	}

	public bool CreateNew(Page page)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_Content1", page.Content1, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Content2", page.Content2, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", page.Backgroundimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_AdminId", page.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

		parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

		_dBContext.Connection.Execute("PAGE_PACKAGE.CreatePage", parameters, commandType: CommandType.StoredProcedure);

		return parameters.Get<int>("p_IsSuccessed") == 1;
	}

	public bool Delete(int id)
	{
		var parameters = new DynamicParameters();

		parameters.Add("p_PageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("Page_Package.DeletePage", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

	public List<Page> GetAll()
	{
		IEnumerable<Page> result = _dBContext.Connection.Query<Page>("Page_Package.GetAllPages", commandType: CommandType.StoredProcedure);
		return result.ToList();
	}

	public Page GetById(int id)
	{
		var parameters = new DynamicParameters();
		parameters.Add("p_PageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		IEnumerable<Page> result = _dBContext.Connection.Query<Page>("Page_Package.GetPageById", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

	public bool Update(Page page)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_PageId", page.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_Content1", page.Content1, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Content2", page.Content2, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", page.Backgroundimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_AdminId", page.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("PAGE_PACKAGE.UpdatePage", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}

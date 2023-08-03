using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;


namespace Eventopia.Infra.Repository;

public class CategoryRepository : ICategoryRepository
{
	private readonly IDbContext _dBContext;

	public CategoryRepository(IDbContext dBContext)
	{
		_dBContext = dBContext;
	}

	public bool CreateNew(Category category)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_Name", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", category.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_CreateionDate", category.Creationdate, dbType: DbType.Date, direction: ParameterDirection.Input);
		parameters.Add("p_AdminId", category.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

		parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

		_dBContext.Connection.Execute("Category_Package.CreateCategory", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

	public bool Delete(int id)
	{
		var parameters = new DynamicParameters();

		parameters.Add("p_CategoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("Category_Package.DeleteCategory", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

	public List<Category> GetAll()
	{
		IEnumerable<Category> result = _dBContext.Connection.Query<Category>("Category_Package.GetAllCategories", commandType: CommandType.StoredProcedure);
		return result.ToList();
	}

	public Category GetById(int id)
	{
		var parameters = new DynamicParameters();
		parameters.Add("p_CategoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		IEnumerable<Category> result = _dBContext.Connection.Query<Category>("CATEGORY_PACKAGE.GetCategoryById", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

	public Category GetCategoryByName(string name)
	{
		var parameters = new DynamicParameters();
		parameters.Add("p_CategoryName", name, dbType: DbType.String, direction: ParameterDirection.Input);
		IEnumerable<Category> result = _dBContext.Connection.Query<Category>("CATEGORY_PACKAGE.GetCategoryByName", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

	public bool Update(Category category)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_CategoryId", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_Name", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ImagePath", category.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_CreateionDate", category.Creationdate, dbType: DbType.Date, direction: ParameterDirection.Input);
		parameters.Add("p_AdminId", category.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

		parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("Category_Package.UpdateCategory", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}

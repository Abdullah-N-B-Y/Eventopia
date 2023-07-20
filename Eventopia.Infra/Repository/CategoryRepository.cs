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
	public class CategoryRepository : IRepository<Category>
	{
		private readonly IDbContext _dBContext;

		public CategoryRepository(IDbContext dBContext)
		{
			_dBContext = dBContext;
		}

		public void CreateNew(Category category)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("NAME_", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("IMAGE_PATH", category.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("DESCRIPTION_", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("CREATION_DATE", category.Creationdate, dbType: DbType.Date, direction: ParameterDirection.Input);
			parameters.Add("ADMIN_ID", category.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = _dBContext.Connection.Execute("CATEGORY_PACKAGE.CreateCategory", parameters, commandType: CommandType.StoredProcedure);
		}

		public void Delete(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("CATEGORY_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = _dBContext.Connection.Execute("Course_Package.DeleteCourse", parameters, commandType: CommandType.StoredProcedure);
		}

		public List<Category> GetAll()
		{
			IEnumerable<Category> result = _dBContext.Connection.Query<Category>("CATEGORY_PACKAGE.GetAllCategories", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public Category GetById(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("CATEGORY_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			IEnumerable<Category> result = _dBContext.Connection.Query<Category>("CATEGORY_PACKAGE.GetCategoryById", parameters, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public void Update(Category category)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("CATEGORY_ID", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			parameters.Add("NAME_", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("IMAGE_PATH", category.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("DESCRIPTION_", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("CREATION_DATE", category.Creationdate, dbType: DbType.Date, direction: ParameterDirection.Input);
			parameters.Add("ADMIN_ID", category.Adminid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = _dBContext.Connection.Execute("CATEGORY_PACKAGE.UpdateCategory", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}

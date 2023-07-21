using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IService<Category> _categoryService;

		public CategoryController(IService<Category> categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		[Route("GetAllCategories")]
		public List<Category> GetAllCategories()
		{
			return _categoryService.GetAll();
		}

		[HttpGet]
		[Route("GetCategoryById/{id}")]
		public Category GetCategoryById(int id)
		{
			return _categoryService.GetById(id);
		}

		[HttpPost]
		[Route("CreateCategory")]
		public void CreateCategory(Category category)
		{
			_categoryService.CreateNew(category);
		}

		[HttpPut]
		[Route("UpdateCategory")]
		public void UpdateCategory(Category category)
		{
			_categoryService.Update(category);
		}

		[HttpDelete]
		[Route("DeleteCategory/{id}")]
		public void DeleteCategory(int id)
		{
			_categoryService.Delete(id);
		}

	}
}

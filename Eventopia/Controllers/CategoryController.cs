using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
		public IActionResult GetCategoryById(
			[Required(ErrorMessage = "CategoryId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "CategoryId must be a positive number.")]
			int id)
		{
			return Ok(_categoryService.GetById(id));
		}

		[HttpPost]
		[Route("CreateCategory")]
		public IActionResult CreateCategory([FromBody] Category category)
		{
			_categoryService.CreateNew(category);
			return Ok();
		}

		[HttpPut]
		[Route("UpdateCategory")]
		public IActionResult UpdateCategory([FromBody] Category category)
		{
			_categoryService.Update(category);
			return Ok();
		}

		[HttpDelete]
		[Route("DeleteCategory/{id}")]
		public IActionResult DeleteCategory(
			[Required(ErrorMessage = "CategoryId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "CategoryId must be a positive number.")]
			int id)
		{
			_categoryService.Delete(id);
			return Ok();
		}

	}
}

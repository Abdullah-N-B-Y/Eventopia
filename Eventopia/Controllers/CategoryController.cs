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
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
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
			Category category = _categoryService.GetById(id);
			if(category == null)
				return NotFound();
			return Ok(category);
		}

		[HttpGet]
		[Route("GetCategoryByName/{name}")]
		public IActionResult GetCategoryByName(
			[Required(ErrorMessage = "Name is required.")]
			[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
			string name)
		{
			Category category = _categoryService.GetCategoryByName(name);
			if (category == null)
				return NotFound();
			return Ok(category);
		}

		[HttpPost]
		[Route("CreateCategory")]
		public IActionResult CreateCategory([FromBody] Category category)
		{
			Category cat = _categoryService.GetCategoryByName(category.Name);
			if(cat == null)
				return Conflict("CategoryName Already Exists");

			_categoryService.CreateNew(category);
			return Ok();
		}

		[HttpPut]
		[Route("UpdateCategory")]
		public IActionResult UpdateCategory([FromBody] Category category)
		{
			Category cat = _categoryService.GetCategoryByName(category.Name);
			if (cat == null)
				return Conflict("CategoryName Already Exists");

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
			if(!_categoryService.Delete(id))
				return NotFound();

			return Ok();
		}

	}
}

using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PageController : ControllerBase
{
	private readonly IService<Page> _pageService;

	public PageController(IService<Page> pageService)
	{
		_pageService = pageService;
	}

	[HttpGet]
	[Route("GetAllPages")]
	public List<Page> GetAllPages()
	{
		return _pageService.GetAll();
	}

	[HttpGet]
	[Route("GetPageById/{id}")]
	public IActionResult GetPageById(
		[Required(ErrorMessage = "PageId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "PageId must be a positive number.")]
		int id)
	{
		return Ok(_pageService.GetById(id));
	}

	[HttpPost]
	[Route("CreatePage")]
	public IActionResult CreatePage([FromBody] Page page)
	{
		_pageService.CreateNew(page);
		return Ok();
	}

	[HttpPut]
	[Route("UpdatePage")]
	public IActionResult UpdatePage([FromBody] Page page)
	{
		_pageService.Update(page);
		return Ok();
	}

	[HttpDelete]
	[Route("DeletePage/{id}")]
	public IActionResult DeletePage(
		[Required(ErrorMessage = "PageId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "PageId must be a positive number.")]
		int id)
	{
		_pageService.Delete(id);
		return Ok();
	}

}

using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using System.ComponentModel.DataAnnotations;
using Eventopia.Infra.Utility;
using Microsoft.Extensions.Logging;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Authorization;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
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
		Page page = _pageService.GetById(id);
		if(page == null)
			return NotFound();
		
		return Ok(page);
	}

	[HttpPost]
	[Route("CreatePage")]
	public IActionResult CreatePage([FromForm] Page page)
	{
		if (page.ReceivedImageFile != null)
		{
			if (!ImageUtility.IsImageContentType(page.ReceivedImageFile.ContentType))
				return BadRequest("Invalid file type. Only images are allowed.");

			page.BackgroundImagePath = ImageUtility.StoreImage(page.ReceivedImageFile, "Page");
		}
		
		return Ok(_pageService.CreateNew(page));
	}

	[HttpPut]
	[Route("UpdatePage")]
	public IActionResult UpdatePage([FromForm] Page page)
	{
		if (page.ReceivedImageFile != null)
		{
			if (!ImageUtility.IsImageContentType(page.ReceivedImageFile.ContentType))
				return BadRequest("Invalid file type. Only images are allowed.");

			page.BackgroundImagePath = ImageUtility.ReplaceImage(page.BackgroundImagePath, page.ReceivedImageFile, "Page");
		}
		if (!_pageService.Update(page))
			return NotFound();
		return Ok();
	}

	[HttpDelete]
	[Route("DeletePage/{id}")]
	public IActionResult DeletePage(
		[Required(ErrorMessage = "PageId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "PageId must be a positive number.")]
		int id)
	{
		if(!_pageService.Delete(id))
			return NotFound();
		return Ok();
	}

}

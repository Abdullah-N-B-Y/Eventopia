﻿using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;


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
	public Page GetPageById(int id)
	{
		return _pageService.GetById(id);
	}

	[HttpPost]
	[Route("CreatePage")]
	public IActionResult CreatePage([FromBody] Page page)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_pageService.CreateNew(page);
		return Ok();
	}

	[HttpPut]
	[Route("UpdatePage")]
	public IActionResult UpdatePage([FromBody] Page page)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_pageService.Update(page);
		return Ok();
	}

	[HttpDelete]
	[Route("DeletePage/{id}")]
	public void DeletePage(int id)
	{
		_pageService.Delete(id);
	}

}

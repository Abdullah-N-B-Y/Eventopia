using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;

namespace Eventopia.API.Controllers
{
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
		public void CreatePage(Page page)
		{
			_pageService.CreateNew(page);
		}

		[HttpPut]
		[Route("UpdatePage")]
		public void UpdatePage(Page page)
		{
			_pageService.Update(page);
		}

		[HttpDelete]
		[Route("DeletePage")]
		public void DeletePage(int id)
		{
			_pageService.Delete(id);
		}

	}
}

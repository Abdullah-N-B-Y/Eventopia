using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class ContactUsEntriesController : ControllerBase
	{
		private readonly IService<ContactUsEntry> _contactUsEntriesService;

		public ContactUsEntriesController(IService<ContactUsEntry> contactUsEntriesService)
		{
			_contactUsEntriesService = contactUsEntriesService;
		}

		[HttpGet]
		[Route("GetAllEntries")]
		public List<ContactUsEntry> GetAllEntries()
		{
			return _contactUsEntriesService.GetAll();
		}

		[HttpGet]
		[Route("GetEntryById/{id}")]
		public IActionResult GetEntryById(
			[Required(ErrorMessage = "ContactUsEntryId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "ContactUsEntryId must be a positive number.")]
		int id)
		{
			ContactUsEntry entry = _contactUsEntriesService.GetById(id);
			if(entry == null)
				return NotFound();
			return Ok(entry);
		}

		[HttpPost]
		[Route("CreateEntry")]
		public IActionResult CreateEntry([FromBody] ContactUsEntry entry)
		{
			_contactUsEntriesService.CreateNew(entry);
			return Ok();
		}

		[HttpPut]
		[Route("UpdateEntryById")]
		public IActionResult UpdateEntryById([FromBody] ContactUsEntry entry)
		{
			_contactUsEntriesService.Update(entry);
			return Ok();
		}

		[HttpDelete]
		[Route("DeletePageById/{id}")]
		public IActionResult DeletePageById(
			[Required(ErrorMessage = "ContactUsEntryId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "ContactUsEntryId must be a positive number.")]
		int id)
		{
			if(!_contactUsEntriesService.Delete(id))
				return NotFound();
			return Ok();
		}
	}
}

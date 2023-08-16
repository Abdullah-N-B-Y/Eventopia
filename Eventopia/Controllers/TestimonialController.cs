using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class TestimonialController : ControllerBase
{
    private readonly IService<Testimonial> _testimonialService;

    public TestimonialController(IService<Testimonial> testimonialService)
    {
        _testimonialService = testimonialService;
    }

    [HttpGet]
    [Route("GetAllTestimonials")]
    public List<Testimonial> GetAlTestimonials()
    {
        return _testimonialService.GetAll();
    }

    [HttpGet]
    [Route("GetTestimonialByID/{id}")]
    public IActionResult GetTestimonialByID(
		[Required(ErrorMessage = "TestimonialId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "TestimonialId must be a positive number.")]
		int id)
    {
        Testimonial testimonial = _testimonialService.GetById(id);
		if (testimonial == null)
			return NotFound();
		return Ok(testimonial);
    }

    [HttpPost]
    [Route("CreateNewTestimonial")]
    public IActionResult CreateNewTestimonial([FromBody] Testimonial testimonial)
    {
		_testimonialService.CreateNew(testimonial);
        return Ok();
    }

    [HttpPut]
    [Route("UpdateTestimonial")]
    public IActionResult UpdateTestimonial([FromBody] Testimonial testimonial)
    {
		bool success = _testimonialService.Update(testimonial);
		if (!success)
			return NotFound();
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteTestimonial/{id}")]
    public IActionResult DeleteTestimonial(
		[Required(ErrorMessage = "TestimonialId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "TestimonialId must be a positive number.")]
		int id)
    {
        bool success = _testimonialService.Delete(id);
        if(!success)
            return NotFound();
        return Ok();    
    }
}

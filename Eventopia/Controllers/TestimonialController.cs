using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
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
		return Ok(_testimonialService.GetById(id));
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
		_testimonialService.Update(testimonial);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteTestimonial/{id}")]
    public IActionResult DeleteTestimonial(
		[Required(ErrorMessage = "TestimonialId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "TestimonialId must be a positive number.")]
		int id)
    {
		_testimonialService.Delete(id);
        return Ok();    
    }
}

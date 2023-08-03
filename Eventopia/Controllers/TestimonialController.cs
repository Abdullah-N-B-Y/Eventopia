using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;

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
    public Testimonial GetTestimonialByID(int id)
    {
        return _testimonialService.GetById(id);
    }

    [HttpPost]
    [Route("CreateNewTestimonial")]
    public IActionResult CreateNewTestimonial([FromBody] Testimonial testimonial)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_testimonialService.CreateNew(testimonial);
        return Ok();
    }

    [HttpPut]
    [Route("UpdateTestimonial")]
    public IActionResult UpdateTestimonial([FromBody] Testimonial testimonial)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_testimonialService.Update(testimonial);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteTestimonial/{id}")]
    public void DeleteTestimonial(int id)
    {
        _testimonialService.Delete(id);
    }
}

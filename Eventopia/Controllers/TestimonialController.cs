using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;

namespace Eventopia.API.Controllers
{
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
        public void CreateNewTestimonial(Testimonial testimonial)
        {
            _testimonialService.CreateNew(testimonial);
        }

        [HttpPut]
        [Route("UpdateTestimonial")]
        public void UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.Update(testimonial);
        }

        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public void DeleteTestimonial(int id)
        {
            _testimonialService.Delete(id);
        }
    }
}

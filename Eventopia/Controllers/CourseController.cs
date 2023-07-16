using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
    public class CourseController : Controller
    {

        [HttpGet]
        [Route("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            return View();
        }
    }
}

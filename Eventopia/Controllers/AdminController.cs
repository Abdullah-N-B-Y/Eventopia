using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPut]
        [Route("EventAcceptation/{id}/{status}")]
        public void EventAcceptation(int id, string status)
        {
            _adminService.EventAcceptation(id, status);
        }
    }
}

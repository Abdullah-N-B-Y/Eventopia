using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IRepository<Profile> _profileRepository;

        public ProfilesController(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        [Route("GetAllProfiles")]
        public ActionResult<List<Profile>> GetAllProfiles()
        {
            var profiles = _profileRepository.GetAll();
            return Ok(profiles);
        }

        [HttpGet]
        [Route("GetProfileById/{id}")]
        public ActionResult<Profile> GetProfileById(int id)
        {
            var profile = _profileRepository.GetById(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        [Route("CreateProfile")]
        public IActionResult CreateProfile(Profile profile)
        {
            _profileRepository.CreateNew(profile);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateProfile")]
        public IActionResult UpdateProfile(Profile profile)
        {
            _profileRepository.Update(profile);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteProfile/{id}")]
        public IActionResult DeleteProfile(int id)
        {
            _profileRepository.Delete(id);
            return Ok();
        }

    }
}

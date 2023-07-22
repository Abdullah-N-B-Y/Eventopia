using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;

namespace Eventopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IService<Profile> _profileService;

        public ProfileController(IService<Profile> profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        [Route("GetAllProfiles")]
        public List<Profile> GetAllProfiles()
        {
            return _profileService.GetAll();
        }

        [HttpGet]
        [Route("GetProfileByID/{id}")]
        public Profile GetProfileByID(int id)
        {
            return _profileService.GetById(id);
        }



        [HttpPost]
        [Route("CreateNewProfile")]
        public void CreateNewProfile(Profile profile)
        {
            _profileService.CreateNew(profile);
        }

        [HttpPut]
        [Route("UpdateProfile")]
        public void UpdateProfile(Profile profile)
        {
            _profileService.Update(profile);
        }

        [HttpDelete]
        [Route("DeleteProfile/{id}")]
        public void DeleteProfile(int id)
        {
            _profileService.Delete(id);
        }
    }
}



using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Core.Data;
using System.Collections.Generic;

namespace Eventopia.Infra.Service
{
    public class ProfileService : IService<Profile>
    {
        private readonly IRepository<Profile> _profileRepository;

        public ProfileService(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Profile GetById(int id)
        {
            return _profileRepository.GetById(id);
        }

        public List<Profile> GetAll()
        {
            return _profileRepository.GetAll();
        }

        public void CreateNew(Profile profile)
        {
            _profileRepository.CreateNew(profile);
        }

        public void Update(Profile profile)
        {
            _profileRepository.Update(profile);
        }

        public void Delete(int id)
        {
            _profileRepository.Delete(id);
        }
    }
}

using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Core.Data;


namespace Eventopia.Infra.Service;

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

    public bool CreateNew(Profile profile)
    {
        return _profileRepository.CreateNew(profile);
    }

    public bool Update(Profile profile)
    {
        return _profileRepository.Update(profile);
    }

    public bool Delete(int id)
    {
        return _profileRepository.Delete(id);
    }
}

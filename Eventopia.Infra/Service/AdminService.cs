using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public void EventAcceptation(int id, string status)
    { 
        _adminRepository.EventAcceptation(id, status);
    }

    public bool BannedUser(int userId)
    {
        return _adminRepository.BannedUser(userId);
    }

    public bool UnbannedUser(int userId)
    {
        return _adminRepository.UnbannedUser(userId);
    }
}

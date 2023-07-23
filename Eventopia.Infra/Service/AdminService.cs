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

    public void BannedUser(int userId)
    {
        _adminRepository.BannedUser(userId);
    }

    public void UnbannedUser(int userId)
    {
        _adminRepository.UnbannedUser(userId);
    }
}

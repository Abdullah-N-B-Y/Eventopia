using Eventopia.Core.DTO;
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

    public bool EventAcceptation(int id, string status)
    { 
        return _adminRepository.EventAcceptation(id, status);
    }

    public bool BannedUser(int userId)
    {
        return _adminRepository.BannedUser(userId);
    }

    public bool UnbannedUser(int userId)
    {
        return _adminRepository.UnbannedUser(userId);
    }

    bool IAdminService.BannedUser(int userId)
    {
        throw new NotImplementedException();
    }

    public StatisticsDTO GetStatistics()
    {
        return _adminRepository.GetStatistics();
    }

    public GetBenefitsReportDTO GetBenefitsReport(DateTime startDate, DateTime endDate)
    {
        return _adminRepository.GetBenefitsReport(startDate, endDate);
    }
}

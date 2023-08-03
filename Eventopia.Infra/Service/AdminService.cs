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

    public StatisticsDTO GetStatistics()
    {
        return _adminRepository.GetStatistics();
    }

    public GetBenefitsReportDTO GetBenefitsReport(SearchBetweenDatesDTO searchDTO)
    {
        return _adminRepository.GetBenefitsReport(searchDTO);
    }
}

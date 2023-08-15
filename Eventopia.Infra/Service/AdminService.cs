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

    public bool BannedUser(string username)
    {
        return _adminRepository.BannedUser(username);
    }

    public bool UnbannedUser(string username)
    {
        return _adminRepository.UnbannedUser(username);
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

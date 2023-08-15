using Eventopia.Core.DTO;

namespace Eventopia.Core.Repository;

public interface IAdminRepository
{
    bool EventAcceptation(int id, string status);
    bool BannedUser(string username);
    bool UnbannedUser(string username);

    StatisticsDTO GetStatistics();

    GetBenefitsReportDTO GetBenefitsReport(SearchBetweenDatesDTO searchDTO);

}

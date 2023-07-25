
using Eventopia.Core.DTO;

namespace Eventopia.Core.Repository;

public interface IAdminRepository
{
    void EventAcceptation(int id, string status);

    bool BannedUser(int userId);
    bool UnbannedUser(int userId);

    StatisticsDTO GetStatistics();

    GetBenefitsReportDTO GetBenefitsReport(DateTime startDate, DateTime endDate);

}

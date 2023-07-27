using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface IBookingRepository : IRepository<Booking>
{
    bool DeleteUserFromBooking(int userId, int eventId);
}

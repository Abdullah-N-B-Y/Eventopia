using Eventopia.Core.Data;

namespace Eventopia.Core.Service;

public interface IBookingService : IService<Booking>
{
    bool DeleteUserFromBooking(int userId, int eventId);
}

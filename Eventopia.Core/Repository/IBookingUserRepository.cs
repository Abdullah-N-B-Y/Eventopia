
using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface IBookingUserRepository
{
    void AddUserToBooking(Booking booking);
    void DeleteUserFromBooking(int userId, int eventId);
}

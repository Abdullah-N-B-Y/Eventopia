

using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface IRepository<T>
{
    void CreateBooking(Booking booking);

}

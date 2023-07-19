
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service;

public class BookingService : IService<Booking>
{
    private readonly IRepository<Booking> _bookingRepository;

    public BookingService(IRepository<Booking> bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    public void CreateNew(Booking t)
    {
        _bookingRepository.CreateNew(t);
    }
}

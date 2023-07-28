using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public bool CreateNew(Booking t)
    {
        return _bookingRepository.CreateNew(t);
    }

    public Booking GetById(int id)
    {
        return _bookingRepository.GetById(id);
    }

    public List<Booking> GetAll()
    {
        return _bookingRepository.GetAll();
    }

    public bool Update(Booking t)
    {
        return _bookingRepository.Update(t);
    }

    public bool Delete(int id)
    {
        return _bookingRepository.Delete(id);
    }

    public bool DeleteUserFromBooking(int userId, int eventId)
    {
        return _bookingRepository.DeleteUserFromBooking(userId, eventId);
    }
}

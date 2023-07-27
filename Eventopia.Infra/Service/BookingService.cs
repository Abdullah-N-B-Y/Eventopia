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

    public void CreateNew(Booking t)
    {
        _bookingRepository.CreateNew(t);
    }

    public Booking GetById(int id)
    {
        return _bookingRepository.GetById(id);
    }

    public List<Booking> GetAll()
    {
        return _bookingRepository.GetAll();
    }

    public void Update(Booking t)
    {
        _bookingRepository.Update(t);
    }

    public void Delete(int id)
    {
        _bookingRepository.Delete(id);
    }

    public bool DeleteUserFromBooking(int userId, int eventId)
    {
        return _bookingRepository.DeleteUserFromBooking(userId, eventId);
    }
}

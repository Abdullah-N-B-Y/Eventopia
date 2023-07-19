
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

}

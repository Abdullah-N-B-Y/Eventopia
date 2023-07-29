using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Core.Data;


namespace Eventopia.Infra.Service;

public class TestimonialService : IService<Testimonial>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public TestimonialService(IRepository<Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public List<Testimonial> GetAll()
    {
        return _testimonialRepository.GetAll();
    }

    public bool CreateNew(Testimonial testimonial)
    {
        return _testimonialRepository.CreateNew(testimonial);
    }

    public bool Update(Testimonial testimonial)
    {
        return _testimonialRepository.Update(testimonial);
    }

    public bool Delete(int id)
    {
        return _testimonialRepository.Delete(id);
    }

    public Testimonial GetById(int id)
    {
        throw new NotImplementedException();
    }
}

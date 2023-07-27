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

    public void CreateNew(Testimonial testimonial)
    {
        _testimonialRepository.CreateNew(testimonial);
    }

    public void Update(Testimonial testimonial)
    {
        _testimonialRepository.Update(testimonial);
    }

    public void Delete(int id)
    {
        _testimonialRepository.Delete(id);
    }

    public Testimonial GetById(int id)
    {
        throw new NotImplementedException();
    }
}

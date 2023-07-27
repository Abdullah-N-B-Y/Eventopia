using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Core.Data;


namespace Eventopia.Infra.Service;

public class PageService : IService<Page>
{
	private readonly IRepository<Page> _pageRepository;

	public PageService(IRepository<Page> pageRepository)
	{
		_pageRepository = pageRepository;
	}

	public void CreateNew(Page page)
	{
		_pageRepository.CreateNew(page);
	}

	public void Delete(int id)
	{
		_pageRepository.Delete(id);
	}

	public List<Page> GetAll()
	{
		return _pageRepository.GetAll();
	}

	public Page GetById(int id)
	{
		return _pageRepository.GetById(id);
	}

	public void Update(Page page)
	{
		_pageRepository.Update(page);
	}
}

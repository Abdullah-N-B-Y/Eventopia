using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Core.Data;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Utility;

namespace Eventopia.Infra.Service;

public class PageService : IService<Page>
{
	private readonly IRepository<Page> _pageRepository;

	public PageService(IRepository<Page> pageRepository)
	{
		_pageRepository = pageRepository;
	}

	public bool CreateNew(Page page)
	{
		return _pageRepository.CreateNew(page);
	}

	public bool Delete(int id)
	{
		Page page = _pageRepository.GetById(id);
		if (page == null)
			return false;
		ImageUtility.DeleteImage(page.BackgroundImagePath, "Page");
		return _pageRepository.Delete(id);
	}

	public List<Page> GetAll()
	{
		List<Page> pages = _pageRepository.GetAll();
		foreach (Page page in pages)
		{
			string? byteFile = ImageUtility.RetrieveImage(page.BackgroundImagePath, "Page");
			page.RetrievedImageFile = byteFile;
		}
		return pages;
	}

	public Page GetById(int id)
	{
		Page page = _pageRepository.GetById(id);
		if (page == null)
			return null;
		string? byteFile = ImageUtility.RetrieveImage(page.BackgroundImagePath, "Page");
		page.RetrievedImageFile = byteFile;
		return page;
	}

	public bool Update(Page page)
	{
		return _pageRepository.Update(page);
	}
}

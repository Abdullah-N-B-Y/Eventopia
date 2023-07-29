using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service;

public class CategoryService : IService<Category>
{
	private readonly IRepository<Category> _categoryRepository;

	public CategoryService(IRepository<Category> categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public bool CreateNew(Category category)
	{
		return _categoryRepository.CreateNew(category);
	}

	public bool Delete(int id)
	{
		return _categoryRepository.Delete(id);
	}

	public List<Category> GetAll()
	{
		return _categoryRepository.GetAll();
	}

	public Category GetById(int id)
	{
		return _categoryRepository.GetById(id);
	}

	public bool Update(Category category)
	{
		return _categoryRepository.Update(category);
	}
}

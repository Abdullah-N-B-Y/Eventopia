using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Utility;
using Microsoft.AspNetCore.Http;

namespace Eventopia.Infra.Service;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryService(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public bool CreateNew(Category category)
	{
		return _categoryRepository.CreateNew(category);
	}

	public bool Delete(int id)
	{
		Category category = _categoryRepository.GetById(id);
		if(category == null)
			return false;
		ImageUtility.DeleteImage(category.ImagePath, "Category");
		return _categoryRepository.Delete(id);
	}

	public List<Category> GetAll()
	{
		List<Category> categories = _categoryRepository.GetAll();
		foreach(var category in categories)
		{
			string? byteFile = ImageUtility.RetrieveImage(category.ImagePath, "Category");
			category.RetrievedImageFile = byteFile;
        }
		return categories;
	}

	public Category GetById(int id)
	{
		Category category = _categoryRepository.GetById(id);
		if (category == null)
			return null;
		string? byteFile = ImageUtility.RetrieveImage(category.ImagePath, "Category");
		category.RetrievedImageFile = byteFile;
		return category;
	}

	public Category GetCategoryByName(string name)
	{
		Category category = _categoryRepository.GetCategoryByName(name);
		if (category == null)
			return null;
		string? byteFile = ImageUtility.RetrieveImage(category.ImagePath, "Category");
		category.RetrievedImageFile = byteFile;
		return category;
	}

	public bool Update(Category category)
	{
		return _categoryRepository.Update(category);
	}
}

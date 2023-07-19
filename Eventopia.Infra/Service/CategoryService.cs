using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Service
{
	public class CategoryService : IService<Category>
	{
		private readonly IRepository<Category> _categoryRepository;

		public CategoryService(IRepository<Category> categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public void CreateNew(Category category)
		{
			_categoryRepository.CreateNew(category);
		}

		public void Delete(int id)
		{
			_categoryRepository.Delete(id);
		}

		public List<Category> GetAll()
		{
			return _categoryRepository.GetAll();
		}

		public Category GetById(int id)
		{
			return _categoryRepository.GetById(id);
		}

		public void Update(Category category)
		{
			_categoryRepository.Update(category);
		}
	}
}

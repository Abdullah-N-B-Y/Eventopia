using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service
{
	public class ContactUsEntriesService : IService<ContactUsEntry>
	{
		private readonly IRepository<ContactUsEntry> _contactUsEntriesRepository;

		public ContactUsEntriesService(IRepository<ContactUsEntry> contactUsEntriesRepository)
		{
			_contactUsEntriesRepository = contactUsEntriesRepository;
		}

		public bool CreateNew(ContactUsEntry entry)
		{
			entry.Adminid = 1;
			return _contactUsEntriesRepository.CreateNew(entry);
		}

		public bool Delete(int id)
		{
			return _contactUsEntriesRepository.Delete(id);
		}

		public List<ContactUsEntry> GetAll()
		{
			return _contactUsEntriesRepository.GetAll();
		}

		public ContactUsEntry GetById(int id)
		{
			return _contactUsEntriesRepository.GetById(id);
		}

		public bool Update(ContactUsEntry entry)
		{
			return _contactUsEntriesRepository.Update(entry);
		}
	}
}

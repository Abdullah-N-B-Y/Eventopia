using Eventopia.Core.Data;


namespace Eventopia.Core.Repository
{
	public interface IProfileRepository: IRepository<Profile>
	{
		Profile GetProfileByUserId(int id);
		Profile GetProfileByPhoneNumber(string phoneNumber);
		void UpdateUserProfileImage(int userId, string imagePath);
    }
}

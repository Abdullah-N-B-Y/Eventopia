﻿using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Core.Data;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Utility;

namespace Eventopia.Infra.Service;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public Profile GetById(int id)
    {
		Profile profile = _profileRepository.GetById(id);
		if (profile == null)
			return null;
		string? byteFile = ImageUtility.RetrieveImage(profile.ImagePath, "Profile");
		profile.RetrievedImageFile = byteFile;
		return profile;
    }

    public List<Profile> GetAll()
    {
		List<Profile> profiles = _profileRepository.GetAll();
		foreach (Profile profile in profiles)
		{
			string? byteFile = ImageUtility.RetrieveImage(profile.ImagePath, "Profile");
			profile.RetrievedImageFile = byteFile;
		}
		return profiles;
    }

    public bool CreateNew(Profile profile)
    {
        return _profileRepository.CreateNew(profile);
    }

    public bool Update(Profile profile)
    {
        return _profileRepository.Update(profile);
    }

    public bool Delete(int id)
    {
		Profile profile = _profileRepository.GetById(id);
		if (profile == null)
			return false;
		ImageUtility.DeleteImage(profile.ImagePath, "Profile");
		return _profileRepository.Delete(id);
    }

	public Profile GetProfileByPhoneNumber(string phoneNumber)
	{
		Profile profile = _profileRepository.GetProfileByPhoneNumber(phoneNumber);
		if (profile == null)
			return null;
		string? byteFile = ImageUtility.RetrieveImage(profile.ImagePath, "Profile");
		profile.RetrievedImageFile = byteFile;
		return profile;
	}

    public Profile GetProfileByUserId(int id)
    {
		Profile profile = _profileRepository.GetProfileByUserId(id);
		if (profile == null)
			return null;
		string? byteFile = ImageUtility.RetrieveImage(profile.ImagePath, "Profile");
		profile.RetrievedImageFile = byteFile;
		return profile;

    }

    public void UpdateUserProfileImage(int userId, string imagePath)
    { 
        _profileRepository.UpdateUserProfileImage(userId, imagePath);
    }
}

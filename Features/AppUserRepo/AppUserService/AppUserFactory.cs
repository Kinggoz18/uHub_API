using System.ComponentModel.DataAnnotations;
using uHubAPI.Features.AppUserRepo.Models;
namespace uHubAPI.Features.AppUserRepo.AppUserService
{
	public static class AppUserFactory
	{
        public static AppUser CreateDefaultAppUser()
        {
            return new AppUser
            {

                UserId = 0,
                AccountId = new Guid(),
                FirstName = "",
                LastName = "",
                Email = "",
                StudentEmail = "",
                PhoneNumber = "",
                Password = "",
                VerificationStatus = "",
                ImageKey = "",
                IsLocked = true,
                IsBanned = true,
                ReportCount = 100
            };
        }
	}
}


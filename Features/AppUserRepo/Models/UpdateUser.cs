using System;
namespace uHubAPI.Features.AppUserRepo.Models
{
	public class UpdateUser
	{
		public required string AccountId { get; set; }
		public required string UpdateInfo { get; set; }
	}
}


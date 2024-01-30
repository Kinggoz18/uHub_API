using System;
namespace uHubAPI.Features.AppUserRepo.Models
{
    /// <summary>
    /// Enum containing all type of App User updates.
    /// </summary>
	public enum UpdateType
	{
		LastName,
        FirstName,
        Email,
        IsLocked,
        IsBanned,
        ReportCount,
        PhoneNumber
    }
}


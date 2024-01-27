using System;
using uHubAPI.Extensions.Models;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Extensions.Services.EntityFinder
{
	/// <summary>
	/// Interface where all FindEnity classes derive from
	/// </summary>
	public interface IFindEntity
	{
		public Task<OperationResult<AppUser>> FindByIdAsync(string accountId);
	}

	/// <summary>
	/// Interface where FindUser inherits from
	/// </summary>
	public interface IFindUser : IFindEntity
	{
		public Task<OperationResult<AppUser>> FindByEmailAsync(string email);
	}
}


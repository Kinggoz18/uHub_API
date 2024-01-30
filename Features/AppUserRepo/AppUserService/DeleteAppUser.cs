using uHubAPI.Extensions.Models;
using uHubAPI.Database.DbContext;
using uHubAPI.Extensions.Services;
using uHubAPI.Extensions.Services.EntityFinder;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Features.AppUserRepo.AppUserService
{
    /// <summary>
    /// App user delete user service class
    /// </summary>
    public class DeleteAppUser : IAppUserService
    {
		private readonly AppDbContext _context;
		private readonly IFindUser _finder;

        public DeleteAppUser(AppDbContext context, IFindUser finder)
		{
			_finder = finder;
			_context = context;
		}

		/// <summary>
		/// Deletes an app user if they exist.
		/// </summary>
		/// <param name="accountId">The account id to be deleted.</param>
		/// <returns></returns>
		public async Task<OperationResult<AppUser>> DeleteUser(string accountId)
		{
			var result = await _finder.FindByIdAsync(accountId);
			if (!result.Success)
			{
				return OperationGenerator<AppUser>.FailedOperationGenerator(result.Entity);
			}
			_context.AppUsers.Remove(result.Entity);
			await _context.SaveChangesAsync();

			return OperationGenerator<AppUser>.SuccessOperationGenerator(result.Entity);

        }
	}
}


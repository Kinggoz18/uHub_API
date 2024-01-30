using uHubAPI.Database.DbContext;
using uHubAPI.Extensions.Models;
using uHubAPI.Extensions.Services;
using Microsoft.EntityFrameworkCore;
using uHubAPI.Features.AppUserRepo.Models;
using uHubAPI.Extensions.Services.EntityFinder;

namespace uHubAPI.Features.AppUserRepo.AppUserService
{
	public class GetAppUser : IAppUserService
    {
		private readonly AppDbContext _context;
        private readonly IFindUser _finder;
        public GetAppUser(AppDbContext context, IFindUser finder)
		{
            _finder = finder;
			_context = context;
		}

        /// <summary>
        /// Method to get an app user by their Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
		public async Task<OperationResult<AppUser>> GetAppUserById(string accountId)
		{
			try
			{
				var result = await _finder.FindByIdAsync(accountId);
				//If the user does not exists
                if (!result.Success)
				{
					return OperationGenerator<AppUser>.FailedOperationGenerator(AppUserFactory.CreateDefaultAppUser());
				}
                return OperationGenerator<AppUser>.SuccessOperationGenerator(result.Entity);
            }
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        /// <summary>
        /// Method to get all app users in the db
        /// </summary>
        /// <param name="pageStart"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// TODO: Implement with iSpecification pattern where we use isBanned and isLocked to filter 
        public async Task<OperationResultList<AppUser>> GetAllAppUser(int pageStart)
        {
			int pageSize = 2;   //TODO: Change to 50 after testing
            try
            {
                var result = await _context.AppUsers
                .Skip((pageStart - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
				return new OperationResultList<AppUser>
				{
					Success = true,
					EntityList = result
				};
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //TODO: Implement Get All users by postal code?
    }
}


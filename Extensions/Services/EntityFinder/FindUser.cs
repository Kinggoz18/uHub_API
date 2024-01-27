using uHubAPI.Extensions.Models;
using uHubAPI.Database.DbContext;
using Microsoft.EntityFrameworkCore;
using uHubAPI.Features.AppUserRepo.AppUserService;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Extensions.Services.EntityFinder
{
    /// <summary>
    /// Class that provides methods to check if an entity exists
    /// </summary>
	public class FindUser : IFindUser
	{
        private readonly AppDbContext _context;

		public FindUser(AppDbContext context){

			_context = context;
		}

        /// <summary>
        /// Method that checks if a user exists through their email
        /// </summary>
        /// <param name="email">The App user email</param>
        /// <returns>
        /// An OperationResult object. If success is false the user does not exists. If success true the user exists.
        /// </returns>
        public async Task<OperationResult<AppUser>> FindByEmailAsync(string email)
        {
            var userExists = await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email);

            if (userExists == null)
            {
                return new OperationResult<AppUser>
                {
                    Success = false,
                    Entity = AppUserFactory.CreateDefaultAppUser()
                };
            }
            return new OperationResult<AppUser>
            {
                Success = true,
                Entity = userExists
            };
        }

        /// <summary>
        /// Method that checks if a user exists through their AccountId
        /// </summary>
        /// <param name="accountId">The App user guid in string format</param>
        /// <returns>
        /// An OperationResult object. If success is false the user does not exists. If success true the user exists.
        /// </returns>
        public async Task<OperationResult<AppUser>> FindByIdAsync(string accountId)
		{
            Guid userId = new(accountId);
            var userExists = await _context.AppUsers.FirstOrDefaultAsync(u => u.AccountId == userId);

            if (userExists == null)
            {
                return new OperationResult<AppUser>
                {
                    Success = false,
                    Entity = AppUserFactory.CreateDefaultAppUser()
                };
            }
            return new OperationResult<AppUser>
            {
                Success = true,
                Entity = userExists
            };
        }
	}
}


using uHubAPI.Extensions.Models;
using uHubAPI.Database.DbContext;
using uHubAPI.Extensions.Services;
using uHubAPI.Features.AppUserRepo.Models;
using uHubAPI.Extensions.Services.EntityFinder;

namespace uHubAPI.Features.AppUserRepo.AppUserService
{
	/// <summary>
	/// App user login service class
	/// </summary>
	public class LoginAppUser : IAppUserService
	{
		private readonly AppDbContext _context;
		private readonly IFindUser _finder;

        public LoginAppUser(AppDbContext context, IFindUser finder)
		{
			_context = context;
			_finder = finder;
		}

        /// <summary>
        /// Asynchronous method to login in an app user
		/// TODO: Revamp after implementing OAuth
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns>
		/// OperationResult an object.
		/// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<OperationResult<AppUser>> LoginUserAsync(LoginUser loginInfo)
		{
			try
			{
				var result = await _finder.FindByEmailAsync(loginInfo.Email);
				//If the user does not exists
				if (!result.Success)
				{
					return result;

                }
                //Check user passwords match
                result.Entity.Password = HashPassword.HashUserPassword(loginInfo.Password);
				//If the passwords do not match return a failed operation
				if (result.Entity.Password != loginInfo.Password)
				{
                    return OperationGenerator<AppUser>.FailedOperationGenerator(AppUserFactory.CreateDefaultAppUser());
                }
				return result;
            }
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}


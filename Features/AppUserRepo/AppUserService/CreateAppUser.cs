using uHubAPI.Features.Enums;
using uHubAPI.Database.DbContext;
using uHubAPI.Extensions.Models;
using uHubAPI.Extensions.Services;
using Microsoft.EntityFrameworkCore;
using uHubAPI.Features.AppUserRepo.Models;
using uHubAPI.Extensions.Services.EntityFinder;

namespace uHubAPI.Features.AppUserRepo.AppUserService
{
    /// <summary>
    /// App user create user service class
    /// </summary>
    public class CreateAppUser : IAppUserService
    {
        private readonly AppDbContext _context;
        private readonly IFindUser _finder;
        public CreateAppUser(AppDbContext context, IFindUser finder)
        {
            _finder = finder;
            _context = context;
        }

        /// <summary>
        /// Asynchronous method to create a new app use
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>
        /// OperationResult an object.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<OperationResult<AppUser>> CreateUserAsync(AppUser newUser)
        {
            try
            {
                var result = await _finder.FindByEmailAsync(newUser.Email);
                //if the email exists in db
                if (result.Success)
                {
                    return OperationGenerator<AppUser>.FailedOperationGenerator(AppUserFactory.CreateDefaultAppUser());
                }
                //Set default fields
                //TODO: set user's role to regular
                newUser.AccountId = Guid.NewGuid();
                newUser.Password = HashPassword.HashUserPassword(newUser.Password);
                newUser.IsBanned = false;
                newUser.IsLocked = false;
                newUser.ReportCount = 0;
                newUser.VerificationStatus = VerificationStatus.Pending.ToString();

                //Add the user to the db
                _context.AppUsers.Add(newUser);
                await _context.SaveChangesAsync();

                return OperationGenerator<AppUser>.SuccessOperationGenerator(newUser);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
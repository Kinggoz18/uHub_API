using uHubAPI.Extensions;
using uHubAPI.Features.Enums;
using uHubAPI.Database.DBContext;
using Microsoft.EntityFrameworkCore;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Features.AppUserRepo.Services
{
    /// <summary>
    /// Service class to create an app user
    /// </summary>
    public class CreateAppUser : IAppUserService
    {
        private readonly AppDbContext _context;

        public CreateAppUser(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new app use
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<OperationResult<AppUser>> CreateUser(AppUser newUser)
        {
            try
            {
                //Check if user exists in db
                var userExists = await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == newUser.Email);
                if (userExists != null)
                {
                    return new OperationResult<AppUser>()
                    {
                        Success = false,
                        Entity = userExists
                    };
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

                return new OperationResult<AppUser>()
                {
                    Success = true,
                    Entity = newUser
                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using MySqlX.XDevAPI.Common;
using uHubAPI.Database.DbContext;
using uHubAPI.Extensions.Models;
using uHubAPI.Extensions.Services.EntityFinder;
using uHubAPI.Features.AppUserRepo.AppUserService;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Features.AppUserRepo.AppUserService
{
    /// <summary>
    /// App user update user service class
    /// </summary>
    public class UpdateAppUser : IAppUserService
    {
        private readonly AppDbContext _context;
        private readonly IFindUser _finder;

        public UpdateAppUser(AppDbContext context, IFindUser finder)
        {
            _context = context;
            _finder = finder;
        }

        /// <summary>
        /// Delegates to handle the following updates: UpdateFirstName, UpdateLastName, UpdateEmail.
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <param name="updateInfo">The new information being applied</param>
        /// <returns></returns>
        private delegate Task UpdateWithInfo(AppUser appUser, string updateInfo);

        /// <summary>
        /// Delegates to handle the following updates: IsLocked, IsBanned
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <returns></returns>
        private delegate Task UpdateWithoutInfo(AppUser appUser);

        /// <summary>
        /// Method to Update First Name
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <param name="updateInfo">The new first name</param>
        /// <returns></returns>
        private async Task UpdateFirstName(AppUser appUser, string updateInfo)
        {
            appUser.FirstName = updateInfo;
            _context.AppUsers.Update(appUser);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to Update Last Name
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <param name="updateInfo">The new first name</param>
        /// <returns></returns>
        private async Task UpdateLastName(AppUser appUser, string updateInfo)
        {
            appUser.LastName = updateInfo;
            _context.AppUsers.Update(appUser);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to Update First Name
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <param name="updateInfo">The new first name</param>
        /// <returns></returns>
        private async Task UpdateEmail(AppUser appUser, string updateInfo)
        {
            appUser.Email = updateInfo;
            _context.AppUsers.Update(appUser);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to Update Phone number 
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <param name="updateInfo">The new phone number</param>
        /// <returns></returns>
        private async Task UpdatePhoneNumber(AppUser appUser, string updateInfo)
        {
            appUser.PhoneNumber = updateInfo;
            _context.AppUsers.Update(appUser);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to change IsBanned field
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <returns></returns>
        private async Task IsBanned(AppUser appUser)
        {
            appUser.IsBanned = !appUser.IsBanned;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to change IsLocked field
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <returns></returns>
        private async Task IsLocked(AppUser appUser)
        {
            appUser.IsLocked = !appUser.IsBanned;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update report count
        /// </summary>
        /// <param name="appUser">The entity to be updated</param>
        /// <returns></returns>
        private async Task ReportCount(AppUser appUser)
        {
            if(appUser.ReportCount < 5)
            {
                appUser.ReportCount += 1;
            }
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// TODO: Implement or remove after adding OAuth
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<OperationResult<AppUser>> UpdatePassword(UpdateUser update)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: implement after finding storage
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<OperationResult<AppUser>> UpdateProfileImage(UpdateUser update)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to update to a user with new information in body request
        /// </summary>
        /// <param name="updateInfo">The new update information</param>
        /// <param name="type">The type of update being applied</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<OperationResult<AppUser>> UpdateByInfo(UpdateUser updateInfo, UpdateType type)
        {
            var result = await _finder.FindByIdAsync(updateInfo.AccountId);
            //if the user does not exist
            if (!result.Success)
            {
                return result;
            }

            UpdateWithInfo updater = null!;
            //Apply delegate
            updater = type switch
            {
                UpdateType.FirstName => UpdateFirstName,
                UpdateType.LastName => UpdateLastName,
                UpdateType.Email => UpdateEmail,
                UpdateType.PhoneNumber => UpdatePhoneNumber,
                _ => throw new Exception($"{type} is not a valid UpdateType."),
            };
            //Update the data
            _ = updater(result.Entity, updateInfo.UpdateInfo);
            return result;
        }

        /// <summary>
        /// Method to update to a user without new information in body request
        /// </summary>
        /// <param name="accountId">The Account Id of the entity to be updated</param>
        /// <param name="type">The type of update being applied</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<OperationResult<AppUser>> UpdateById(string accountId, UpdateType type)
        {
            var result = await _finder.FindByIdAsync(accountId);
            //if the user does not exist
            if (!result.Success)
            {
                return result;
            }
            //Apply delegate
            UpdateWithoutInfo updater = null!;

            updater = type switch
            {
                UpdateType.IsBanned => IsBanned,
                UpdateType.IsLocked => IsLocked,
                UpdateType.ReportCount => ReportCount,
                _ => throw new Exception($"{type} is not a valid UpdateType.")
            };
            //Update the data
            _ = updater(result.Entity);
            return result;
        }
    }
}


using uHubAPI.Features.AppUserRepo.AppUserService;
using Microsoft.AspNetCore.Mvc;
using uHubAPI.Features.AppUserRepo.Models;
using System.Threading.Tasks;

namespace uHubAPI.Features.AppUserRepo.Controllers
{
    /// <summary>
    /// App user controller class
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AppUserController : ControllerBase
    {
        private readonly CreateAppUser _createAppUserService;
        private readonly LoginAppUser _loginAppUserService;
        private readonly DeleteAppUser _deleteAppUserService;
        private readonly UpdateAppUser _updateAppUserService;
        private readonly GetAppUser _getAppUserService;

        public AppUserController(IAppUserServiceFactory userServiceFactory)
        {
            _createAppUserService = (CreateAppUser)userServiceFactory.Create("CreateAppUser")
                ?? throw new ArgumentNullException("CreateAppUser Service was not configured.");

            _loginAppUserService = (LoginAppUser)userServiceFactory.Create("LoginAppUser")
                ?? throw new ArgumentNullException("LoginAppUser Service was not configured.");

            _deleteAppUserService = (DeleteAppUser)userServiceFactory.Create("CreateAppUser")
               ?? throw new ArgumentNullException("CreateAppUser Service was not configured.");

            _updateAppUserService = (UpdateAppUser)userServiceFactory.Create("LoginAppUser")
                ?? throw new ArgumentNullException("LoginAppUser Service was not configured.");

            _getAppUserService = (GetAppUser)userServiceFactory.Create("LoginAppUser")
                ?? throw new ArgumentNullException("LoginAppUser Service was not configured.");
        }


        /// <summary>
        /// Controller that handdles creating an app user
        /// </summary>
        /// <param name="appUser">Body request</param>
        /// <returns></returns>
        [HttpPost("CreateAppUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAppUserAsync(AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _createAppUserService.CreateUserAsync(appUser);

            if(!result.Success )
            {
                return BadRequest("Invalid request. User exists");
            }
            return CreatedAtAction("CreateAppUser", new { result.Entity.UserId }, result.Entity);
        }

        /// <summary>
        /// Login app user controller
        /// </summary>
        /// <param name="userInfo">user login info</param>
        /// <returns></returns>
        [HttpPost("LoginAppUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAppUserAsync(LoginUser userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _loginAppUserService.LoginUserAsync(userInfo);

            if (!result.Success)
            {
                return BadRequest("Invalid request. Wrong login credentials");
            }
            return CreatedAtAction("LoginAppUser", new { result.Entity.UserId }, result.Entity);
        }

        /// <summary>
        /// Update an app user first name controller 
        /// </summary>
        /// <param name="updateInfo">Object containing the new first name and the account id to be updated.</param>
        /// <returns></returns>
        [HttpPut("UpdateAppUser/FirstName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFirstName(UpdateUser updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUserService.UpdateByInfo(updateInfo, UpdateType.FirstName);
            if (!result.Success)
            {
                return BadRequest("Updating user first name was unsuccessful.");
            }
            return NoContent();
        }

        /// <summary>
        /// Update an app user last name controller 
        /// </summary>
        /// <param name="updateInfo">Object containing the new last name and the account id to be updated.</param>
        /// <returns></returns>
        [HttpPut("UpdateAppUser/LastName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLastName(UpdateUser updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUserService.UpdateByInfo(updateInfo, UpdateType.LastName);
            if (!result.Success)
            {
                return BadRequest("Updating user last name was unsuccessful.");
            }
            return NoContent();
        }

        /// <summary>
        /// Update an app user email controller 
        /// </summary>
        /// <param name="updateInfo">Object containing the new email and the account id to be updated.</param>
        /// <returns></returns>
        [HttpPut("UpdateAppUser/Email")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmail(UpdateUser updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUserService.UpdateByInfo(updateInfo, UpdateType.Email);
            if (!result.Success)
            {
                return BadRequest("Updating user email was unsuccessful.");
            }
            return NoContent();
        }

        /// <summary>
        /// Controller that handdles Updating an app user Locked status 
        /// </summary>
        /// <param name="accountId">The account id to be updated.</param>
        /// <returns></returns>
        [HttpPut("UpdateAppUser/IsLocked")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIsLocked(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUserService.UpdateById(accountId, UpdateType.IsLocked);
            if (!result.Success)
            {
                return BadRequest("Updating locked status was unsuccessful.");
            }
            return NoContent();
        }

        /// <summary>
        /// Controller that handdles Updating an app user banned status 
        /// </summary>
        /// <param name="accountId">The account id to be updated.</param>
        /// <returns></returns>
        [HttpPut("UpdateAppUser/IsBanned")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIsBanned(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUserService.UpdateById(accountId, UpdateType.IsBanned);
            if (!result.Success)
            {
                return BadRequest("Updating banned status was unsuccessful.");
            }
            return NoContent();
        }

        /// <summary>
        /// Controller that handdles Updating increamenting an app user report count 
        /// </summary>
        /// <param name="accountId">The account id to be updated.</param>
        /// <returns></returns>
        [HttpPut("UpdateAppUser/ReportCount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateReportCount(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUserService.UpdateById(accountId, UpdateType.ReportCount);
            if (!result.Success)
            {
                return BadRequest("Updating report count was unsuccessful.");
            }
            return NoContent();
        }

        /// <summary>
        /// Controller that handdles Updating an app user phone number
        /// </summary>
        /// <param name="updateInfo">Object containing the new phone and the account id to be updated.</param>
        /// <returns></returns>
        [HttpPut("UpdateAppUser/PhoneNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePhoneNumber(UpdateUser updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUserService.UpdateByInfo(updateInfo, UpdateType.PhoneNumber);
            if (!result.Success)
            {
                return BadRequest("Updating report count was unsuccessful.");
            }
            return NoContent();
        }

        /// <summary>
        /// Controller that handles deleting an app user
        /// </summary>
        /// <param name="accountId">The id of the app user to be deleted</param>
        /// <returns></returns>
        [HttpDelete("DeleteAppUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAppUser(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _deleteAppUserService.DeleteUser(accountId);
            if (!result.Success)
            {
                return BadRequest("User was not found");
            }
            return Ok(result);
        }

        /// <summary>
        /// Controller that handles getting an app user
        /// </summary>
        /// <param name="accountId">The id of the app user to be deleted</param>
        /// <returns></returns>
        [HttpGet("GetAppUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAppUser(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _getAppUserService.GetAppUserById(accountId);
            if (!result.Success)
            {
                return BadRequest("User was not found");
            }
            return Ok(result);
        }

        /// <summary>
        /// Controller that handles getting all app users
        /// </summary>
        /// <param name="pageStart">Where to start retriving from</param>
        /// <returns></returns>
        [HttpGet("GetAllAppUsers")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAppUser(int pageStart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _getAppUserService.GetAllAppUser(pageStart);
            if (!result.Success)
            {
                return BadRequest("User was not found");
            }
            return Ok(result);
        }
    }
}
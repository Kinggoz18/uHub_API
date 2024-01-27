using uHubAPI.Features.AppUserRepo.AppUserService;
using Microsoft.AspNetCore.Mvc;
using uHubAPI.Features.AppUserRepo.Models;

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
        private readonly DeleteAppUser _deleteAppUser;
        private readonly UpdateAppUser _updateAppUser;
        private readonly GetAppUser _getAppUser;

        public AppUserController(IAppUserServiceFactory userServiceFactory)
        {
            _createAppUserService = (CreateAppUser)userServiceFactory.Create("CreateAppUser")
                ?? throw new ArgumentNullException("CreateAppUser Service was not configured.");

            _loginAppUserService = (LoginAppUser)userServiceFactory.Create("LoginAppUser")
                ?? throw new ArgumentNullException("LoginAppUser Service was not configured.");

            _deleteAppUser = (DeleteAppUser)userServiceFactory.Create("CreateAppUser")
               ?? throw new ArgumentNullException("CreateAppUser Service was not configured.");

            _updateAppUser = (UpdateAppUser)userServiceFactory.Create("LoginAppUser")
                ?? throw new ArgumentNullException("LoginAppUser Service was not configured.");

            _getAppUser = (GetAppUser)userServiceFactory.Create("LoginAppUser")
                ?? throw new ArgumentNullException("LoginAppUser Service was not configured.");
        }


        /// <summary>
        /// Create App user controller
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

        [HttpPut("UpdateAppUser/FirstName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFirstName(UpdateUser updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUser.UpdateByInfo(updateInfo, UpdateType.FirstName);
            if (!result.Success)
            {
                return BadRequest("Updating user first name was unsuccessful.");
            }
            return NoContent();
        }

        [HttpPut("UpdateAppUser/LastName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLastName(UpdateUser updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUser.UpdateByInfo(updateInfo, UpdateType.LastName);
            if (!result.Success)
            {
                return BadRequest("Updating user last name was unsuccessful.");
            }
            return NoContent();
        }

        [HttpPut("UpdateAppUser/Email")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmail(UpdateUser updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUser.UpdateByInfo(updateInfo, UpdateType.Email);
            if (!result.Success)
            {
                return BadRequest("Updating user email was unsuccessful.");
            }
            return NoContent();
        }

        [HttpPut("UpdateAppUser/IsLocked")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIsLocked(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUser.UpdateById(accountId, UpdateType.IsLocked);
            if (!result.Success)
            {
                return BadRequest("Updating locked status was unsuccessful.");
            }
            return NoContent();
        }

        [HttpPut("UpdateAppUser/IsBanned")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIsBanned(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUser.UpdateById(accountId, UpdateType.IsBanned);
            if (!result.Success)
            {
                return BadRequest("Updating banned status was unsuccessful.");
            }
            return NoContent();
        }

        [HttpPut("UpdateAppUser/ReportCount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateReportCount(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUser.UpdateById(accountId, UpdateType.ReportCount);
            if (!result.Success)
            {
                return BadRequest("Updating report count was unsuccessful.");
            }
            return NoContent();
        }


        [HttpPut("UpdateAppUser/PhoneNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePhoneNumber(UpdateUser userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateAppUser.UpdateByInfo(userInfo, UpdateType.PhoneNumber);
            if (!result.Success)
            {
                return BadRequest("Updating report count was unsuccessful.");
            }
            return NoContent();
        }

        [HttpDelete("DeleteAppUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAppUser(string accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _deleteAppUser.DeleteUser(accountId);
            if (!result.Success)
            {
                return BadRequest("User was not found");
            }
            return Ok();
        }
    }
}
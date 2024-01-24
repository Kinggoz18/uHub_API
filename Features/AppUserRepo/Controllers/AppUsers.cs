using uHubAPI.Features.AppUserRepo.Services;
using Microsoft.AspNetCore.Mvc;
using uHubAPI.Features.AppUserRepo.Models;
using uHubAPI.Database.DBContext;

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

        public AppUserController(IAppUserServiceFactory userServiceFactory)
        {
            _createAppUserService = (CreateAppUser?)userServiceFactory.Create("CreateAppUser")
                ?? throw new ArgumentNullException("CreateAppUser Service was not configured.");
        }


        /// <summary>
        /// Create App user controller
        /// </summary>
        /// <param name="appUser">Body request</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateAppUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAppUserAsync(AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _createAppUserService.CreateUser(appUser);

            if(!result.Success )
            {
                return BadRequest();
            }
            return CreatedAtAction("CreateAppUser", new { result.Entity.UserId }, result.Entity);
        }


    }
}
namespace uHubAPI.Features.AppUserRepo.Models
{
    /// <summary>
    /// Entity class to represent a user login request
    /// </summary>
	public class LoginUser
	{
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}


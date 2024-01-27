using System;
namespace uHubAPI.Features.AppUserRepo.AppUserService
{
    /// <summary>
    ///  App service Factory Interface
    /// </summary>
    public interface IAppUserServiceFactory
    {
        IAppUserService Create(string key);
    }

    /// <summary>
    /// Factory class to build appropriate app user service during DI.
    /// </summary>
    public class AppUserServiceFactory : IAppUserServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AppUserServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Returns an instance of the appropriate app user service during DI.
        /// </summary>
        /// <param name="key">Name of the AppUser service</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IAppUserService Create(string key)
        {
            return key switch
            {
                "CreateAppUser" => _serviceProvider.GetRequiredService<CreateAppUser>(),
                "LoginAppUser" => _serviceProvider.GetRequiredService<LoginAppUser>(),
                "GetAppUser" => _serviceProvider.GetRequiredService<GetAppUser>(),
                "DeleteAppUser" => _serviceProvider.GetRequiredService<DeleteAppUser>(),
                "UpdateAppUser" => _serviceProvider.GetRequiredService<UpdateAppUser>(),
                _ => throw new ArgumentException($"Unknown key: {key}")
            };
        }
    }
}


using System;
namespace uHubAPI.Features.AppUserRepo.Services
{
    /// <summary>
    ///  App service Factory Interface
    /// </summary>
    public interface IAppUserServiceFactory
    {
        IAppUserService Create(string key);
    }

    /// <summary>
    /// Factory class to call appropriate app user service during DI.
    /// </summary>
    public class AppUserServiceFactory : IAppUserServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AppUserServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates an instance of the appropriate app user service during DI.
        /// </summary>
        /// <param name="key">Name of the AppUser service</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IAppUserService Create(string key)
        {
            return key switch
            {
                "CreateAppUser" => _serviceProvider.GetRequiredService<CreateAppUser>(),
                _ => throw new ArgumentException($"Unknown key: {key}")
            };
        }
    }
}


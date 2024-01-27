using uHubAPI.Database;
using MySql.Data.MySqlClient;
using uHubAPI.Database.DbContext;
using Microsoft.EntityFrameworkCore;
using uHubAPI.Extensions.Services.EntityFinder;
using uHubAPI.Features.AppUserRepo.AppUserService;

namespace uHubAPI.Configurations
{
    /// <summary>
    /// TODO: Add summary
    /// </summary>
	public class BulderConfigurations
	{
        private WebApplicationBuilder _builder;

        public BulderConfigurations(WebApplicationBuilder builder)
        {
            _builder = builder ?? throw new ArgumentException(nameof(builder));
        }

        /// <summary>
        /// Adds database context to builder
        /// </summary>
        /// <param name="service"></param>
        public void ConfigureDbContext(IServiceCollection service)
        {
            // Get the connection string for MySQL
            string connectionString = MYSQLConnectionString.GetConnection(_builder);

            // Configure DbContext for the Application
            service.AddDbContext<AppDbContext>(optionsBuilder =>
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
                    {
                        mySqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    })
                    .EnableSensitiveDataLogging(); //TODO: Remove EnableSensitiveDataLogging in production 
                }
            });
        }

        /// <summary>
        /// Add SQL configurations to builder
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <exception cref="Exception"></exception>
        public void ConfigureSQLServices(IServiceCollection services)
        {
            try
            {
                string connectionString = MYSQLConnectionString.GetConnection(_builder);
                services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds extra configurations to builder. See implementation
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            //Services Cofiurations
            services.AddScoped<IFindEntity, FindUser>();
            services.AddScoped<IFindUser, FindUser>();
            services.AddScoped<IAppUserServiceFactory, AppUserServiceFactory>();
            services.AddScoped<CreateAppUser>();
            services.AddScoped<LoginAppUser>();
            services.AddScoped<UpdateAppUser>();
            services.AddScoped<GetAppUser>();
            services.AddScoped<DeleteAppUser>();

            // Add services to the container.
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using uHubAPI.Database.DBContext;
using uHubAPI.Database;
using uHubAPI.Features.AppUserRepo.Services;

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
            services.AddTransient<IAppUserServiceFactory, AppUserServiceFactory>();
            services.AddTransient<CreateAppUser>();

            // Add services to the container.
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
        }
    }
}


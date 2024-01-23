using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using uHubAPI.Database.DBContext;
using uHubAPI.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add MYSQL and DB configuration
ConfigureSQLServices(builder.Services);
ConfigureDbContext();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//Connection Db context
void ConfigureDbContext()
{
    // Get the connection string for MySQL
    string connectionString = MYSQLConnectionString.GetConnection(builder);

    // Configure DbContext for the Application
    builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 7, 3)), mySqlOptions =>
            {
                mySqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });
        }
    });
}

//Connection to MySQL
void ConfigureSQLServices(IServiceCollection services)
{
    try
    {
        string connectionString = MYSQLConnectionString.GetConnection(builder);
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


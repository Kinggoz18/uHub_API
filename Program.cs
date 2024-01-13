using uHubAPI.DBContext;
using uHubAPI.Lib;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureDbContext();   // Add configuration for the database


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



void ConfigureDbContext()
{
    //Get the connection string
    string connectionString = AzureConnectionString.GetConnection(builder);

    // Configure DbContext for Account Management
    builder.Services.AddDbContext<AccountDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });

    // Configure DbContext for Marketplace
    builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });

}

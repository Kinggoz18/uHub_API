using uHubAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Setup configurations
BulderConfigurations bulderConfigurations = new BulderConfigurations(builder);
bulderConfigurations.ConfigureServices(builder.Services);
bulderConfigurations.ConfigureSQLServices(builder.Services);
bulderConfigurations.ConfigureDbContext(builder.Services);

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


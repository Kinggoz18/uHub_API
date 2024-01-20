namespace uHubAPI.Lib
{
    /// <summary>
    ///     Used in development and production to connect to Azure SQL server
    /// </summary>
    /// <returns>
    ///     A connection string
    /// </returns>
    public class AzureConnectionString
    {
        
        public static string GetConnection(WebApplicationBuilder builder){
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
            }
            // Specify the key for the Azure SQL connection string
            var connectionStrings = builder.Configuration.GetSection("ConnectionStrings");
            string azureConnectionStringKey = "AZURE_SQL_CONNECTIONSTRING";
            string connectionString = connectionStrings[azureConnectionStringKey]!;
            return connectionString ?? throw new InvalidOperationException($"Connection string for {azureConnectionStringKey} is missing or empty.");
        }
    }
    
    /// <summary>
    ///     Used in development to connect to an instance of MSSQL on docker
    /// </summary>
    /// <returns>
    ///     A connection string
    /// </returns>
    public static class DockerConnectionString{
            public static string GetConnection(WebApplicationBuilder builder){
            if (builder.Environment.IsDevelopment())
            {
                // Specify the key for the Azure SQL connection string
                var connectionStrings = builder.Configuration.GetSection("ConnectionStrings");
                string dockerConnectionStringKey = "DOCKER_MSSQL_CONNECTIONSTRING";
                string connectionString = connectionStrings[dockerConnectionStringKey]!;
                return connectionString ?? throw new InvalidOperationException($"Connection string for {dockerConnectionStringKey} is missing or empty.");
            }
            else
            {
                throw new ArgumentException("Docker connection string cannot be used in production.");
            }
        }
    }
}
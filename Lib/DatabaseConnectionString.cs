using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uHub_API.Lib
{
    /// <summary>
    /// Used in development and production to connect to Azure SQL server
    /// </summary>
    /// <returns>
    /// A connection string
    /// </returns>
    public class AzureConnectionString
    {
        
        public static string GetConnection(WebApplicationBuilder builder){
            string connection = String.Empty;
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
                connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            }
            else
            {
                connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
            }
            return connection;
        }
    }
    
    /// <summary>
    /// Used in development to connect to an instance of MSSQL on docker
    /// </summary>
    /// <returns>
    /// A connection string
    /// </returns>
    public static class DockerConnectionString{
            public static string GetConnection(WebApplicationBuilder builder){
            string connection = String.Empty;
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
                connection = builder.Configuration.GetConnectionString("DOCKER_MSSQL_CONNECTIONSTRING");
            }
            else
            {
                throw new ArgumentException("Docker connection string cannot be used in production.");
            }
            return connection;
        }
    }
}
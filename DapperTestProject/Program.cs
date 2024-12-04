using DapperTestProject.Models;
using Microsoft.Extensions.Configuration;

namespace DapperTestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                       .Build();

            string? connectionString = configuration["ConnectionStrings:ConnectionString"];

            Requests requests = new(connectionString);
            requests.AllQueries();
        }
    }
}

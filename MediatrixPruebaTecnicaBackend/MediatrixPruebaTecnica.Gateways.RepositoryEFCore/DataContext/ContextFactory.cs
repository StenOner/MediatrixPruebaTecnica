using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "MediatrixPruebaTecnica.Api");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));


            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}

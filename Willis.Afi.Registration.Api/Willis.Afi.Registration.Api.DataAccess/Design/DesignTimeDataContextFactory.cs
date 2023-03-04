using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Willis.Afi.Registration.Api.DataAccess.Design
{
    public class DesignTimeDataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private readonly string _relativeConfigurationLocation = "/../Willis.Afi.Registration.Api/appsettings.json";

        public DataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + _relativeConfigurationLocation).Build();
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("RegistrationDatabase");
            builder.UseSqlite(connectionString);
            return new DataContext(builder.Options);
        }
    }
}

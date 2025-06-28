using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Persistence;

public class DatabaseDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Get the base path of the API project (where appsettings.json is located)
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Server");
        
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)  // Look in the API directory
            .AddJsonFile("appsettings.json")
            .Build();
            
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("DbConnectionString");
        builder.UseSqlServer(connectionString);
        return new ApplicationDbContext(builder.Options);
    }
}
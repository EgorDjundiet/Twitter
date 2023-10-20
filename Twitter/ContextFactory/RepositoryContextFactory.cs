using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Twitter.Repository;

namespace Twitter.WebAPI.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("mainConnection"), b => b.MigrationsAssembly("Twitter.WebAPI"));

            return new RepositoryContext(builder.Options);
        }
    }
}

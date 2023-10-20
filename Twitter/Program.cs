using Microsoft.EntityFrameworkCore;
using Twitter.Repository;
using Twitter.Repository.Contracts;
using Twitter.Repository.Implementations;
using Twitter.Service.Contracts;
using Twitter.Service.Implementations;
using Twitter.WebAPI.Extensions;

namespace Twitter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddScoped<RepositoryErrorFlag>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof(Service.MappingProfile));
            builder.Services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(builder.Configuration.GetConnectionString("mainConnection")));
            var app = builder.Build();
            app.ConfigureExceptionMiddleware();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
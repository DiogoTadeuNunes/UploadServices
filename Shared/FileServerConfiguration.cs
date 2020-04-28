using Application.AppService;
using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Shared
{
    public class FileServerConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<FileServerContext>();

            //Repositorios
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IFileRepository, FileRepository>();

            //AppServices
            services.AddScoped<IFileServerAppService, FileServerAppService>();
        }
    }
}

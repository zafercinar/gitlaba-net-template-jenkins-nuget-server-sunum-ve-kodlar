using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZACx.Templates.WebApiProject.DataAccess.Contexts;
using ZACx.Templates.WebApiProject.DataAccess.Repositories.Abstract.EntityFramework;
using ZACx.Templates.WebApiProject.DataAccess.Repositories.Concrete.EntityFramework;

namespace ZACx.Templates.WebApiProject.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// IServiceCollection referanslarının eklenmesini sağlar.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccessRegistration(this IServiceCollection services)
        {
            //DbContext Settings
            services.AddDbContext<ProjectDbContext>((sp, opt) =>
            {
                opt.UseSqlServer("ConnectionStringBurayaYazilacaktir");
                opt.EnableSensitiveDataLogging(false);
            });

            //DataAccess Layer Dependencies will be custom added here
            services.AddScoped<IExampleRepository, ExampleRepository>();
            return services;
        }
    }
}

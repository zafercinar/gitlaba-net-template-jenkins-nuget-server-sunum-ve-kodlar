using AutoMapper;
using ZACx.Templates.WebApiProject.Business.Mappings.Examples;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZACx.Templates.WebApiProject.Business.Services.Abstract;
using ZACx.Templates.WebApiProject.Business.Services.Concrete;

namespace ZACx.Templates.WebApiProject.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// IServiceCollection referanslarının eklenmesini sağlar.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBusinessRegistration(this IServiceCollection services)
        {
            //Business Layer Dependencies will be custom added here

            //AutoMapper Configurations
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ExampleMappingProfile());
            }).CreateMapper());

            //Service DI Configurations
            services.AddScoped<IExampleService, ExampleService>();
            return services;
        }
    }
}

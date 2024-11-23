
namespace ZACx.Templates.WebApiProject.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// IServiceCollection ve IHostBuilder referanslarının eklenmesini sağlar.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiRegistration(this IServiceCollection services, IHostBuilder hostBuilder)
        {
            //log paketi için kullanıldı.
            hostBuilder.ConfigureLogging(options => options.ClearProviders());

            services.AddHttpClient();

            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)//Json PropertyName özelliğini kullanmak için eklenmiştir. İhtiyaç halinde kullanılmaktadır.
                    ;

            return services;
        }

        /// <summary>
        /// Uygulama Build Run sonrasında eklenilecek middleware ve diğer ayarların eklenmesini sağlar.
        /// </summary>
        /// <param name="app">Uygulamanın servislerine karşılık gelir.</param>
        /// <returns></returns>
        public static WebApplication UseApiRegistration(this WebApplication app)
        {
            if (System.Diagnostics.Debugger.IsAttached)
                app.UseDeveloperExceptionPage();

            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
                c.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}

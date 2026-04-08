using StudentPlatform.Infrastructure;

namespace StudentPlatform
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Подключаем в конфигурацию файл appsettings.json
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // Оборачиваем секцию Project в обьектную форму для удобства
            IConfiguration configuration = configBuild.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;
            // Подкючаем функционал контроллеров
            builder.Services.AddControllersWithViews();
            // Собираем концфигурацию
            WebApplication app = builder.Build();
            // Порядок слеодования middleware очень важен, они буду выполняться согласно нему
            // Подключаем использование статичных файлов
            app.UseStaticFiles();
            // Подключаем маршрутизацию
            app.UseRouting();
            // Регистрируем нужные маршруты
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            await app.RunAsync();
        }
    }
}

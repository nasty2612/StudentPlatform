using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;
using StudentPlatform.Domain;
using StudentPlatform.Domain.Repositories.Abstract;
using StudentPlatform.Domain.Repositories.EntityFramework;
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
            // Подключаем контекст бд
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.Database.ConnectionString)
            .ConfigureWarnings(WarningsConfiguration => WarningsConfiguration.Ignore(RelationalEventId.PendingModelChangesWarning))); // Предупреждения на всякий случай подавляем
            // Вставляем репозитории для функций
            builder.Services.AddTransient<IServiceCategoriesRepository, EFServiceCategoriesRepository>();
            builder.Services.AddTransient<IServicesRepository, EFServicesRepository>();
            builder.Services.AddTransient<DataManager>();
            // Настравиваем Identity систему
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            // Настравиваем auth cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "studentPlatformAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });
            // Подкючаем функционал контроллеров
            builder.Services.AddControllersWithViews();
            // Подключаем логи
            builder.Host.UseSerilog((context , configuration) => configuration.ReadFrom.Configuration(context.Configuration));
            // Собираем концфигурацию
            WebApplication app = builder.Build();
            // Порядок следования middleware очень важен, они буду выполняться согласно нему
            // Сразу же используем логгирование
            app.UseSerilogRequestLogging();
            // Далее подключаем обработку исключений
            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            // Подключаем использование статичных файлов
            app.UseStaticFiles();
            // Подключаем маршрутизацию
            app.UseRouting();
            // Пoдключаем аутенфикацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            // Регистрируем нужные маршруты
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            await app.RunAsync();
        }
    }
}

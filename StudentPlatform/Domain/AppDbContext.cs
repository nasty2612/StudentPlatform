using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using StudentPlatform.Domain.Entities;
namespace StudentPlatform.Domain
{
    // Контекст бд
    public class AppDbContext : IdentityDbContext <IdentityUser>
    {
        public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminName = "admin"; // Админ
            string userName = "user"; // Обычный пользователь
            string roleAdminId = Guid.NewGuid().ToString();
            string UserAdminId = Guid.NewGuid().ToString();
            string roleUSerId = Guid.NewGuid().ToString();

            // Добавляем роль администратора сайта
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });

            // Добавляем роль пользователя
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleUSerId,
                Name = userName,
                NormalizedName = userName.ToUpper()
            });

            // Добавляем нового IdentityUser  как администратора сайта
            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = UserAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "bnastya261206@mail.ru",
                NormalizedEmail = "bnastya261206@mail.ru",
                EmailConfirmed = true,
                TwoFactorEnabled = true, // 2FA
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), adminName),
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });
            // Определяем админа в соотвествующую роль
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = UserAdminId
            });
        }
    }
}

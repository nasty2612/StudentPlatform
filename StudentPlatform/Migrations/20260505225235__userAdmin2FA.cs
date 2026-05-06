using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentPlatform.Migrations
{
    /// <inheritdoc />
    public partial class _userAdmin2FA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c51f1b2-4a20-43c8-b7c9-76f315731a1f", "b743d6e0-bb9f-454a-98fa-21dd9420021b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c51f1b2-4a20-43c8-b7c9-76f315731a1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b743d6e0-bb9f-454a-98fa-21dd9420021b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b0ab31f-a723-4529-9f04-722b744b992f", null, "user", "USER" },
                    { "984feb94-2a4d-4d05-b612-78057e50f9e6", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "072d2e49-4b9e-4dbe-9806-76586c4da64d", 0, "2613003a-a994-4178-8e9c-a404f9ca4f25", "bnastya261206@mail.ru", true, false, null, "bnastya261206@mail.ru", "ADMIN", "AQAAAAIAAYagAAAAEPbtZNu5XOU7pw4oLXFN4IFOy78SPAhDQHfR83BrPEa6Ws1qG44hUfRXdjGGN/ZzoA==", null, true, "", true, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "984feb94-2a4d-4d05-b612-78057e50f9e6", "072d2e49-4b9e-4dbe-9806-76586c4da64d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b0ab31f-a723-4529-9f04-722b744b992f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "984feb94-2a4d-4d05-b612-78057e50f9e6", "072d2e49-4b9e-4dbe-9806-76586c4da64d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "984feb94-2a4d-4d05-b612-78057e50f9e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "072d2e49-4b9e-4dbe-9806-76586c4da64d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c51f1b2-4a20-43c8-b7c9-76f315731a1f", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b743d6e0-bb9f-454a-98fa-21dd9420021b", 0, "61051b15-609d-4680-b86e-26e6df2763a6", "bnastya261206@mail.ru", true, false, null, "bnastya261206@mail.ru", "ADMIN", "AQAAAAIAAYagAAAAEKGspFiqp73zzBqFVQzqJh0ZCDJ3UD6oeWYt4GdiZ/DMgYNF/ZyIsVA71u2Tamse/A==", null, true, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5c51f1b2-4a20-43c8-b7c9-76f315731a1f", "b743d6e0-bb9f-454a-98fa-21dd9420021b" });
        }
    }
}

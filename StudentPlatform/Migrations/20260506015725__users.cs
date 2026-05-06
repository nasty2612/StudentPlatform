using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentPlatform.Migrations
{
    /// <inheritdoc />
    public partial class _users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a2cfb47-a7be-4fdd-8568-261ae68c0ccc", null, "user", "USER" },
                    { "6a61bc02-0964-4e42-bbb9-ef14fba0a9cd", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f2535b7c-8180-474b-991d-5646d4ece2ab", 0, "ab3fc952-5f04-4d5f-938e-94e42002dbfe", "bnastya261206@mail.ru", true, false, null, "bnastya261206@mail.ru", "ADMIN", "AQAAAAIAAYagAAAAELKDXyV0rnSM8qR48W4tvMH72hrOOnQi4gEEmpulIShD5lMlpFh//n+MPks8biMOMg==", null, true, "", true, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6a61bc02-0964-4e42-bbb9-ef14fba0a9cd", "f2535b7c-8180-474b-991d-5646d4ece2ab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a2cfb47-a7be-4fdd-8568-261ae68c0ccc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a61bc02-0964-4e42-bbb9-ef14fba0a9cd", "f2535b7c-8180-474b-991d-5646d4ece2ab" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a61bc02-0964-4e42-bbb9-ef14fba0a9cd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2535b7c-8180-474b-991d-5646d4ece2ab");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Services");

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
    }
}

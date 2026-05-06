using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentPlatform.Migrations
{
    /// <inheritdoc />
    public partial class _usersAudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Transcriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "552c7929-8715-43fa-95b1-bebd9f6f71d6", null, "admin", "ADMIN" },
                    { "f6e8d0fc-05a4-4e4d-9f6b-49ce0f6b2cee", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "44144e4b-6b76-4f71-b01e-141b40660918", 0, "db4cbeae-0625-4841-8924-9dd2962dc52c", "bnastya261206@mail.ru", true, false, null, "bnastya261206@mail.ru", "ADMIN", "AQAAAAIAAYagAAAAEJ4a004s9DK8/iXqoj5VU70+VhBzd1J9Ycg0Z/f/5116gCtN4cyZqId7/IkbwTQSnw==", null, true, "", true, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "552c7929-8715-43fa-95b1-bebd9f6f71d6", "44144e4b-6b76-4f71-b01e-141b40660918" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transcriptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6e8d0fc-05a4-4e4d-9f6b-49ce0f6b2cee");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "552c7929-8715-43fa-95b1-bebd9f6f71d6", "44144e4b-6b76-4f71-b01e-141b40660918" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "552c7929-8715-43fa-95b1-bebd9f6f71d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44144e4b-6b76-4f71-b01e-141b40660918");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMS.infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("21e56e0e-cf41-4602-a8ba-e38853c26954"), null, "Editor", "EDITOR" },
                    { new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("f8886107-ee3d-4156-9fbc-673aec657c72"), null, "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"), 0, "8f544974-8cdb-4865-b876-e6f632b78547", "admin@example.com", true, true, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEGdZJ96+tzfhnoq4BV41DcqJbWM95tzl/FkNppVlALrj9k52wuLzttG5pl216pnpbw==", null, false, "WSC5KCXECFWP474KDDZNQOVKVZIRBGBS", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"), new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21e56e0e-cf41-4602-a8ba-e38853c26954"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8886107-ee3d-4156-9fbc-673aec657c72"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"), new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"));
        }
    }
}

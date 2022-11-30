using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.Migrations
{
    /// <inheritdoc />
    public partial class roleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dec7d49-e584-438b-8637-7b3e9d82fe9d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9bfe0739-5983-476d-94d1-3e90d94d6770", "e60409dc-8bbb-4c23-9452-7219418a9028" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfe8e3cd-e6d8-43c4-94ee-4363f39a25d0", "e60409dc-8bbb-4c23-9452-7219418a9028" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "b92db16c-54ca-4f5d-a778-660f71e5a18c" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "cef20ae5-817c-4924-a264-78760331da6f" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "fc4f7211-d458-4d65-b338-bba0c00da577" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "b92db16c-54ca-4f5d-a778-660f71e5a18c" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "fc4f7211-d458-4d65-b338-bba0c00da577" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 3, "cef20ae5-817c-4924-a264-78760331da6f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bfe0739-5983-476d-94d1-3e90d94d6770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfe8e3cd-e6d8-43c4-94ee-4363f39a25d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e60409dc-8bbb-4c23-9452-7219418a9028");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "b92db16c-54ca-4f5d-a778-660f71e5a18c");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "cef20ae5-817c-4924-a264-78760331da6f");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "fc4f7211-d458-4d65-b338-bba0c00da577");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", "7456caec-6dd1-4fff-be8f-e396ef20652f", "Admin", "ADMIN" },
                    { "Moderator", "072f602a-34cc-4c75-902c-3b4c34f17547", "Moderator", "MODERATOR" },
                    { "User", "bf16f7c3-f094-43d0-8d4b-09a8127098cb", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "812eefc3-7ea3-4393-bf06-e6b4e344b06b", 0, new DateTime(1993, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "df9007e3-4f3a-429b-b5ff-d4dddd4204df", "admin@admin.se", true, "Caroline", "Wallbäck", false, null, "ADMIN@ADMIN.SE", "ADMIN@ADMIN.SE", "AQAAAAEAACcQAAAAEILIdxdssxD/bzXkZ5bE8jbURSVdi9/lU3GQ+YRNaT2LIbiioe4ZL8vhTcoPTZe9ww==", null, false, "a1a709ee-905f-4a90-a980-493ad32c26e0", false, "admin@admin.se" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CityId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "40e85fbb-7aaa-4f2b-9ccc-60172d2ea5ea", 3, "Gun", "0765487028" },
                    { "ab049b2c-3ef8-48f0-8ce2-4d4c832eb8b4", 3, "Alberto", "0735648701" },
                    { "af238e26-9aa0-4991-8728-a19f37aa4080", 1, "Hilda", "0756845297" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Admin", "812eefc3-7ea3-4393-bf06-e6b4e344b06b" },
                    { "Moderator", "812eefc3-7ea3-4393-bf06-e6b4e344b06b" }
                });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesLanguageId", "PeopleId" },
                values: new object[,]
                {
                    { 1, "40e85fbb-7aaa-4f2b-9ccc-60172d2ea5ea" },
                    { 1, "ab049b2c-3ef8-48f0-8ce2-4d4c832eb8b4" },
                    { 1, "af238e26-9aa0-4991-8728-a19f37aa4080" },
                    { 2, "40e85fbb-7aaa-4f2b-9ccc-60172d2ea5ea" },
                    { 2, "af238e26-9aa0-4991-8728-a19f37aa4080" },
                    { 3, "ab049b2c-3ef8-48f0-8ce2-4d4c832eb8b4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "812eefc3-7ea3-4393-bf06-e6b4e344b06b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Moderator", "812eefc3-7ea3-4393-bf06-e6b4e344b06b" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "40e85fbb-7aaa-4f2b-9ccc-60172d2ea5ea" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "ab049b2c-3ef8-48f0-8ce2-4d4c832eb8b4" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "af238e26-9aa0-4991-8728-a19f37aa4080" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "40e85fbb-7aaa-4f2b-9ccc-60172d2ea5ea" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "af238e26-9aa0-4991-8728-a19f37aa4080" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 3, "ab049b2c-3ef8-48f0-8ce2-4d4c832eb8b4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Moderator");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "812eefc3-7ea3-4393-bf06-e6b4e344b06b");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "40e85fbb-7aaa-4f2b-9ccc-60172d2ea5ea");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "ab049b2c-3ef8-48f0-8ce2-4d4c832eb8b4");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "af238e26-9aa0-4991-8728-a19f37aa4080");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8dec7d49-e584-438b-8637-7b3e9d82fe9d", "9490bbf0-bca4-400a-ac13-aa82b821e2ae", "User", "USER" },
                    { "9bfe0739-5983-476d-94d1-3e90d94d6770", "e5aa629b-dde4-40a7-ba66-fdc17c023471", "Admin", "ADMIN" },
                    { "bfe8e3cd-e6d8-43c4-94ee-4363f39a25d0", "14a94042-bd74-450f-a51b-b7b58a0f6232", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e60409dc-8bbb-4c23-9452-7219418a9028", 0, new DateTime(1993, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "c248170f-ad13-4152-831c-30a33075fda0", "admin@admin.se", true, "Caroline", "Wallbäck", false, null, "ADMIN@ADMIN.SE", "ADMIN@ADMIN.SE", "AQAAAAEAACcQAAAAEHO6iiqJZlzzr2o3RXU/qhXiLs+ZkG6kpdHC1OrKzcUpqFrRr+Ode4R0vXvva4PZmQ==", null, false, "40d5cf66-df14-48bd-ba7b-e79c467104c9", false, "admin@admin.se" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CityId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "b92db16c-54ca-4f5d-a778-660f71e5a18c", 3, "Gun", "0765487028" },
                    { "cef20ae5-817c-4924-a264-78760331da6f", 3, "Alberto", "0735648701" },
                    { "fc4f7211-d458-4d65-b338-bba0c00da577", 1, "Hilda", "0756845297" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9bfe0739-5983-476d-94d1-3e90d94d6770", "e60409dc-8bbb-4c23-9452-7219418a9028" },
                    { "bfe8e3cd-e6d8-43c4-94ee-4363f39a25d0", "e60409dc-8bbb-4c23-9452-7219418a9028" }
                });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesLanguageId", "PeopleId" },
                values: new object[,]
                {
                    { 1, "b92db16c-54ca-4f5d-a778-660f71e5a18c" },
                    { 1, "cef20ae5-817c-4924-a264-78760331da6f" },
                    { 1, "fc4f7211-d458-4d65-b338-bba0c00da577" },
                    { 2, "b92db16c-54ca-4f5d-a778-660f71e5a18c" },
                    { 2, "fc4f7211-d458-4d65-b338-bba0c00da577" },
                    { 3, "cef20ae5-817c-4924-a264-78760331da6f" }
                });
        }
    }
}

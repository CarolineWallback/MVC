using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.Migrations
{
    /// <inheritdoc />
    public partial class moderatorrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "79846ed1-0371-4956-8b6b-496e3e1997ec" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "33a9984d-7df4-4cce-98c9-692ff7605d43" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "388b7816-b1f7-44fd-ba22-738e33a6e444" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "97df2012-15cb-427b-a656-97fb52578b1f" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "388b7816-b1f7-44fd-ba22-738e33a6e444" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "97df2012-15cb-427b-a656-97fb52578b1f" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 3, "33a9984d-7df4-4cce-98c9-692ff7605d43" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79846ed1-0371-4956-8b6b-496e3e1997ec");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "33a9984d-7df4-4cce-98c9-692ff7605d43");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "388b7816-b1f7-44fd-ba22-738e33a6e444");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "97df2012-15cb-427b-a656-97fb52578b1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "05477f3d-3853-44a9-a637-6446a07d722d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "408b6248-a817-4d92-b0b6-1c14944fb720");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Moderator", "ed6800ad-d02e-4704-885a-686286a0a24b", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "758c978d-e673-4c56-b6cf-e23642dd535d", 0, new DateTime(1993, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "f33491f0-ba36-41bb-81ed-64be99177f80", "admin@admin.se", true, "Caroline", "Wallbäck", false, null, "ADMIN@ADMIN.SE", "ADMIN@ADMIN.SE", "AQAAAAEAACcQAAAAELkerk1gIyYaVyWR97LuYTsx8EC5WYBvYQGjVuvvQZhKNDZsufofvZ5brIWhsfozvw==", null, false, "350d3c49-28cc-429e-9683-3fe4241e85fc", false, "admin@admin.se" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CityId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "691b40e4-300f-4c52-8d68-2dc3c50b8339", 3, "Gun", "0765487028" },
                    { "c8c6d498-360e-4713-bc3f-66aed8d77791", 1, "Hilda", "0756845297" },
                    { "e3a30395-59b9-48c5-968c-7daf36d3ad86", 3, "Alberto", "0735648701" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Admin", "758c978d-e673-4c56-b6cf-e23642dd535d" },
                    { "Moderator", "758c978d-e673-4c56-b6cf-e23642dd535d" }
                });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesLanguageId", "PeopleId" },
                values: new object[,]
                {
                    { 1, "691b40e4-300f-4c52-8d68-2dc3c50b8339" },
                    { 1, "c8c6d498-360e-4713-bc3f-66aed8d77791" },
                    { 1, "e3a30395-59b9-48c5-968c-7daf36d3ad86" },
                    { 2, "691b40e4-300f-4c52-8d68-2dc3c50b8339" },
                    { 2, "c8c6d498-360e-4713-bc3f-66aed8d77791" },
                    { 3, "e3a30395-59b9-48c5-968c-7daf36d3ad86" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "758c978d-e673-4c56-b6cf-e23642dd535d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Moderator", "758c978d-e673-4c56-b6cf-e23642dd535d" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "691b40e4-300f-4c52-8d68-2dc3c50b8339" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "c8c6d498-360e-4713-bc3f-66aed8d77791" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 1, "e3a30395-59b9-48c5-968c-7daf36d3ad86" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "691b40e4-300f-4c52-8d68-2dc3c50b8339" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 2, "c8c6d498-360e-4713-bc3f-66aed8d77791" });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeopleId" },
                keyValues: new object[] { 3, "e3a30395-59b9-48c5-968c-7daf36d3ad86" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Moderator");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "758c978d-e673-4c56-b6cf-e23642dd535d");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "691b40e4-300f-4c52-8d68-2dc3c50b8339");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "c8c6d498-360e-4713-bc3f-66aed8d77791");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: "e3a30395-59b9-48c5-968c-7daf36d3ad86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "6a610a56-9ad3-40ca-9b29-1f65c7b24ba5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "0d2d9c45-e60f-4cf1-bc80-86639c9cb857");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "79846ed1-0371-4956-8b6b-496e3e1997ec", 0, new DateTime(1993, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "aa24723b-6fe5-4598-94fe-aa684d9001fb", "admin@admin.se", true, "Caroline", "Wallbäck", false, null, "ADMIN@ADMIN.SE", "ADMIN@ADMIN.SE", "AQAAAAEAACcQAAAAEL5gctmiO9wV8V5+HEpYEEqKOZk/Yae34TSAKIAPY1zY5E2W6utrPZzcFYv3BRuV0w==", null, false, "c6abb9bc-9313-4c48-8be5-cde3bbee1f59", false, "admin@admin.se" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CityId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "33a9984d-7df4-4cce-98c9-692ff7605d43", 3, "Alberto", "0735648701" },
                    { "388b7816-b1f7-44fd-ba22-738e33a6e444", 1, "Hilda", "0756845297" },
                    { "97df2012-15cb-427b-a656-97fb52578b1f", 3, "Gun", "0765487028" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Admin", "79846ed1-0371-4956-8b6b-496e3e1997ec" });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesLanguageId", "PeopleId" },
                values: new object[,]
                {
                    { 1, "33a9984d-7df4-4cce-98c9-692ff7605d43" },
                    { 1, "388b7816-b1f7-44fd-ba22-738e33a6e444" },
                    { 1, "97df2012-15cb-427b-a656-97fb52578b1f" },
                    { 2, "388b7816-b1f7-44fd-ba22-738e33a6e444" },
                    { 2, "97df2012-15cb-427b-a656-97fb52578b1f" },
                    { 3, "33a9984d-7df4-4cce-98c9-692ff7605d43" }
                });
        }
    }
}

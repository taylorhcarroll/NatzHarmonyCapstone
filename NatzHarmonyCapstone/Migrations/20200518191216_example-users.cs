using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NatzHarmonyCapstone.Migrations
{
    public partial class exampleusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaa",
                column: "ConcurrencyStamp",
                value: "e68a60ec-e25e-43ba-b517-949765e8b5a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2d0e7b6-4d86-4ed8-ae2d-5b3547bcf6e6", "AQAAAAEAACcQAAAAEBgFzxoueiclI3mAW+Z8mmDfhUnfOEWYN4n72HA+cDre6cM8kYwc9xP3NmhM9n86dQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Admin", "Availability", "AvatarUrl", "CountryId", "CountryPref", "DoB", "FirstName", "Gender", "GenderPref", "LanguagePref", "LastName", "Mentor", "Pronouns" },
                values: new object[,]
                {
                    { "00000000-ffff-ffff-ffff-ffffffffffaf", 0, "72e81795-8daf-40ee-9ba9-cac56ac86991", "ApplicationUser", "alexander@example.com", false, false, null, "ALEXANDER@EXAMPLE.COM", "ALEXANDER@EXAMPLE.COM", null, "6155555557", false, "7f434309-a4d9-48e9-9ebb-8803db794583", false, "alexander@example.com", false, null, null, 2, false, new DateTime(1988, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander", "Male", false, false, "Silva", true, "He / Him" },
                    { "00000000-ffff-ffff-ffff-ffffffffffab", 0, "4c3d5df6-65d0-4062-aa74-ab86bc10378d", "ApplicationUser", "adam@example.com", false, false, null, "ADAM@EXAMPLE.COM", "ADAM@EXAMPLE.COM", null, "6155555556", false, "7f434309-a4d9-48e9-9ebb-8803db794579", false, "adam@example.com", false, null, null, 1, false, new DateTime(1992, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "Male", false, false, "Kodansha", true, "He / Him" },
                    { "00000000-ffff-ffff-ffff-ffffffffffad", 0, "cc402ce4-3f0b-4bd3-a650-e6733c33c9e2", "ApplicationUser", "miguel@example.com", false, false, null, "MIGUEL@EXAMPLE.COM", "MIGUEL@EXAMPLE.COM", null, "6155555557", false, "7f434309-a4d9-48e9-9ebb-8803db794581", false, "miguel@example.com", false, null, null, 2, false, new DateTime(1988, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miguel", "Male", false, false, "Garcia", true, "He / Him" },
                    { "00000000-ffff-ffff-ffff-ffffffffffae", 0, "bfc46f65-d3f4-4478-b0e6-b31563615b26", "ApplicationUser", "an@example.com", false, false, null, "AN@EXAMPLE.COM", "AN@EXAMPLE.COM", null, "6155555557", false, "7f434309-a4d9-48e9-9ebb-8803db794582", false, "an@example.com", false, null, null, 1, false, new DateTime(1992, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "An", "Male", false, false, "Nguyen", true, "He / Him" },
                    { "00000000-ffff-ffff-ffff-ffffffffffac", 0, "729040a1-e87e-4545-a738-3dff039e87b3", "ApplicationUser", "namita@example.com", false, false, null, "NAMITA@EXAMPLE.COM", "NAMITA@EXAMPLE.COM", null, "6155555557", false, "7f434309-a4d9-48e9-9ebb-8803db794580", false, "namita@example.com", false, null, null, 2, false, new DateTime(1986, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namita", "Female", false, false, "Patel", true, "She / Her" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 16, "Bangladesh" },
                    { 15, "Bahrain" },
                    { 13, "Azerbaijan" },
                    { 11, "Austrailia" },
                    { 10, "Armenia" },
                    { 14, "Bahamas" },
                    { 8, "Argentina" },
                    { 7, "Angola" },
                    { 6, "Andorra" },
                    { 5, "Algeria" },
                    { 4, "Albania" },
                    { 3, "Afghanistan" },
                    { 9, "Armenia" },
                    { 12, "Austria" }
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessagesId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 5, 18, 12, 12, 16, 415, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.InsertData(
                table: "UserLanguage",
                columns: new[] { "UserLanguageId", "ApplicationUserId", "LanguageId", "UserId" },
                values: new object[,]
                {
                    { 25, null, 11, "00000000-ffff-ffff-ffff-ffffffffffaf" },
                    { 26, null, 1, "00000000-ffff-ffff-ffff-ffffffffffaf" },
                    { 27, null, 4, "00000000-ffff-ffff-ffff-ffffffffffae" },
                    { 28, null, 1, "00000000-ffff-ffff-ffff-ffffffffffad" },
                    { 29, null, 6, "00000000-ffff-ffff-ffff-ffffffffffac" },
                    { 30, null, 7, "00000000-ffff-ffff-ffff-ffffffffffab" },
                    { 31, null, 8, "00000000-ffff-ffff-ffff-ffffffffffaa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaf");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserLanguage",
                keyColumn: "UserLanguageId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UserLanguage",
                keyColumn: "UserLanguageId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UserLanguage",
                keyColumn: "UserLanguageId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "UserLanguage",
                keyColumn: "UserLanguageId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "UserLanguage",
                keyColumn: "UserLanguageId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserLanguage",
                keyColumn: "UserLanguageId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "UserLanguage",
                keyColumn: "UserLanguageId",
                keyValue: 31);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaa",
                column: "ConcurrencyStamp",
                value: "c78dbcd1-2972-4c8a-8b7c-6ad4c367f581");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c45e9858-8e20-45e6-b9b5-111edb5a90b4", "AQAAAAEAACcQAAAAEKzEempCqP7ewAjrPTWQweGJiwF/HGItPKG+PT+xMooYtDiATWqoY/mKSNZH+kOnSA==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessagesId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 5, 11, 13, 39, 59, 141, DateTimeKind.Local).AddTicks(9209));
        }
    }
}

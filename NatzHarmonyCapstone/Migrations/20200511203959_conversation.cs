using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NatzHarmonyCapstone.Migrations
{
    public partial class conversation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessagesId", "Content", "IsRead", "RecipientId", "SenderId", "TimeStamp" },
                values: new object[] { 1, null, false, "e65db829-8ed8-433a-9e40-32bce7803339", "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2020, 5, 11, 13, 39, 59, 141, DateTimeKind.Local).AddTicks(9209) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessagesId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaa",
                column: "ConcurrencyStamp",
                value: "1efbbd96-c776-4f47-94ca-d7f2881d2da9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2408db7a-c3a8-473c-84e7-7b6fb1c0a47b", "AQAAAAEAACcQAAAAEAgToM0v/mlUXbI7W9fbAYOUi5sBeeajxXfeYT9fv5u+JjpI7YD4PPWAbQ9p4s1SdA==" });
        }
    }
}

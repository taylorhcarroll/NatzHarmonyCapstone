using Microsoft.EntityFrameworkCore.Migrations;

namespace NatzHarmonyCapstone.Migrations
{
    public partial class pronouns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pronouns",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b4c30c2-909b-45ba-81ff-18dc743d08ab", "AQAAAAEAACcQAAAAEEL0it1bqb7QgS9q8zYuGsc0/ADmeOwQ5tUt4TmDCHRzu/EBfLzMQX7KdNc5BzaVjw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pronouns",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5117b3f-dd55-4b99-b002-14ab0858ad9c", "AQAAAAEAACcQAAAAEFerkbiz5fgjopBnvRxm6KAmL/l9Qgr9q8IudPYbMkIZlO6TwlkxtxaRSo5fnCH4Qw==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NatzHarmonyCapstone.Migrations
{
    public partial class pwdHashr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "066741e0-e163-407e-952e-e6fa36db25ea", "AQAAAAEAACcQAAAAEI2ZIBVHI9+OCBsYVUARf9ue/NeNnLHxYU2DlZgRDA8Z4ZXJzJ/PctdhCv8SdUwB4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "7cba8164-a3c9-4994-a5c1-c5513e13e7b8", "AQAAAAEAACcQAAAAEK+/E738IQFSYdXcDWtG2Vz+Spatr06vjC2EoLrHZPy5qTZ8OtXALmzJvlPeMIA5Fg==", "Mornings" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "c709ff51-d602-45b1-9c0e-6421a4e223b2", "AQAAAAEAACcQAAAAEE6iY6APROM5pj1X+a+GTMR17rYdoP/y7SVRyiTf8krzs3m8SqUi+z2Jk8cXEujFPg==", "Midday" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffad",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "fd5356d0-a479-45ae-b388-402129807191", "AQAAAAEAACcQAAAAEPbL08eULGF7m2sHiBWcfSCr0Nt3VGr0lJRsAqIHAzyeIiOmKQwsJGVMaaoaFj5KbQ==", "Evenings" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "69c6725b-4eb1-4b74-b02d-3179e49b0ecb", "AQAAAAEAACcQAAAAEDIAqmkXWCVd0/BwrEpDGYKn0Zv4pt3tGPMFcHVK/9p6mtb0XDuxH1naWy4Z9A07Tw==", "Mornings" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "c1a2efd2-6bff-40e8-9484-abcdc13f4ea7", "AQAAAAEAACcQAAAAEOtbGpbW87XZF7Y3dYC5+VEQvbBvthAhDGEJMGoVrU1FnBWDvNLAXyX3xG6oE+ejjQ==", "Evenings" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bfbb729b-5b15-4c53-b607-d5bad28dee8b", "AQAAAAEAACcQAAAAEEJ+6/w8NHULqsc/Gg1a8/37jgfOtm+3qPH4hBxIUAMtGGGHpS1tiFAQlcfa88jG3A==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessagesId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 5, 19, 11, 25, 5, 29, DateTimeKind.Local).AddTicks(5858));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e68a60ec-e25e-43ba-b517-949765e8b5a0", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "4c3d5df6-65d0-4062-aa74-ab86bc10378d", null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "729040a1-e87e-4545-a738-3dff039e87b3", null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffad",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "cc402ce4-3f0b-4bd3-a650-e6733c33c9e2", null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "bfc46f65-d3f4-4478-b0e6-b31563615b26", null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffaf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Availability" },
                values: new object[] { "72e81795-8daf-40ee-9ba9-cac56ac86991", null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2d0e7b6-4d86-4ed8-ae2d-5b3547bcf6e6", "AQAAAAEAACcQAAAAEBgFzxoueiclI3mAW+Z8mmDfhUnfOEWYN4n72HA+cDre6cM8kYwc9xP3NmhM9n86dQ==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessagesId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 5, 18, 12, 12, 16, 415, DateTimeKind.Local).AddTicks(7699));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodShop.API.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userType",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "151189ac-1c0c-4205-8321-0d1fc875b855", "e88cac68-bacc-4776-a2f5-b8a74fc114df", "User", "USER" },
                    { "587d56d0-aa0b-4f28-b1fb-4e646fe3566e", "53a5e1b0-e6fc-48dc-814f-443e12687c42", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "70a29864-7af3-4247-84ae-89ac78c0e6ba", 0, "8aadd0c4-f54a-4c2e-92a0-42e2e9e415dc", "user@gmail.com", false, false, null, "Tarun Mukherjee", "USER@GMAIL.COM", "TARUN", "AQAAAAEAACcQAAAAELZutV/qn20e4c+4h932+hZ0XCvNULVnJgeEhVMrvI4jTD8ZKe3qwHOvwGfflU/e+w==", null, false, "8a3dc035-f32a-454f-9171-9004f261a378", false, "tarun" },
                    { "b0a68a4e-38e1-40ac-bbd7-312e36e25619", 0, "19cba921-b898-4a4d-9e28-02948b210907", "admin@gmail.com", false, false, null, "Sayan Mukherjee", "ADMIN@GMAIL.COM", "SAYAN", "AQAAAAEAACcQAAAAEAKRIqNexlnpI8saGFih0Gj+TSTzUUmPF/ZUaBx+0y3+may1xmxLuftmgcsaTteP9g==", null, false, "8f66bfee-bbeb-44e1-ad1b-6962c438699a", false, "sayan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "151189ac-1c0c-4205-8321-0d1fc875b855", "70a29864-7af3-4247-84ae-89ac78c0e6ba" },
                    { "587d56d0-aa0b-4f28-b1fb-4e646fe3566e", "b0a68a4e-38e1-40ac-bbd7-312e36e25619" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "151189ac-1c0c-4205-8321-0d1fc875b855", "70a29864-7af3-4247-84ae-89ac78c0e6ba" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "587d56d0-aa0b-4f28-b1fb-4e646fe3566e", "b0a68a4e-38e1-40ac-bbd7-312e36e25619" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "151189ac-1c0c-4205-8321-0d1fc875b855");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "587d56d0-aa0b-4f28-b1fb-4e646fe3566e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70a29864-7af3-4247-84ae-89ac78c0e6ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0a68a4e-38e1-40ac-bbd7-312e36e25619");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

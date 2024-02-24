using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodShop.API.Migrations
{
    /// <inheritdoc />
    public partial class ph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phno",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "151189ac-1c0c-4205-8321-0d1fc875b855",
                column: "ConcurrencyStamp",
                value: "50a7d743-3614-42d3-891e-5be7370eb13a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "587d56d0-aa0b-4f28-b1fb-4e646fe3566e",
                column: "ConcurrencyStamp",
                value: "379f87c9-ad37-4e21-9693-47e4994e3d10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70a29864-7af3-4247-84ae-89ac78c0e6ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Phno", "SecurityStamp" },
                values: new object[] { "4c63ef7d-c442-4209-ac04-8bb654b3395c", "AQAAAAEAACcQAAAAEHShjVU/P58fRhRQp40lmFjGe/NnbG46OvVrrD1HHjQ9GDybSH5adyx58FXvW0ofPg==", "9051033177", "c4bcdf15-11e9-4b85-afc8-c52ed610cf84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0a68a4e-38e1-40ac-bbd7-312e36e25619",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Phno", "SecurityStamp" },
                values: new object[] { "6a81bdf8-17ab-4766-a985-e68ddddfd0cb", "AQAAAAEAACcQAAAAEMQqpcdlYq2dWfi+k2r+syjtd4HbJBlVfO3q+nwKCkP/b1j4Cc57notVO89se5yklg==", "7908502446", "9c47f623-32bd-4e47-9d5d-95fd855d5358" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phno",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "151189ac-1c0c-4205-8321-0d1fc875b855",
                column: "ConcurrencyStamp",
                value: "e88cac68-bacc-4776-a2f5-b8a74fc114df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "587d56d0-aa0b-4f28-b1fb-4e646fe3566e",
                column: "ConcurrencyStamp",
                value: "53a5e1b0-e6fc-48dc-814f-443e12687c42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70a29864-7af3-4247-84ae-89ac78c0e6ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aadd0c4-f54a-4c2e-92a0-42e2e9e415dc", "AQAAAAEAACcQAAAAELZutV/qn20e4c+4h932+hZ0XCvNULVnJgeEhVMrvI4jTD8ZKe3qwHOvwGfflU/e+w==", "8a3dc035-f32a-454f-9171-9004f261a378" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0a68a4e-38e1-40ac-bbd7-312e36e25619",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19cba921-b898-4a4d-9e28-02948b210907", "AQAAAAEAACcQAAAAEAKRIqNexlnpI8saGFih0Gj+TSTzUUmPF/ZUaBx+0y3+may1xmxLuftmgcsaTteP9g==", "8f66bfee-bbeb-44e1-ad1b-6962c438699a" });
        }
    }
}

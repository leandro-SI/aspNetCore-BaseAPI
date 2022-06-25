using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleUsuario.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "7d1955b9-c67e-425f-9fa8-b1c280022061");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "97290e29-67d2-41a3-b051-c0422ac81379", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "303436ed-6213-4348-9fcb-661bf32adcfe", "AQAAAAEAACcQAAAAEKZV/CY+60GFTEDBq/ma/gg42eZVk+XC2LHGYsTvYgoyXzeJjVhu79cZT+AQhOCNkg==", "ebadbedf-599d-46a0-bea6-45f40471773b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a36c70ae-eaf1-48aa-9230-fc1783a4dda3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62c41d62-71eb-48f7-9a4d-9274bcc30b40", "AQAAAAEAACcQAAAAEDZUK+MR3cH1moG5JrvVtRich0B8iqQUSWn/mIhGT7SN/gfzTS47NBuvz0ZTk0x0XQ==", "6e8b826c-e3e5-4f08-81ac-0c57e5321ef5" });
        }
    }
}

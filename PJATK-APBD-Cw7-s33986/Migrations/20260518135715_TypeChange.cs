using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PJATK_APBD_Cw7_s33986.Migrations
{
    /// <inheritdoc />
    public partial class TypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Weight",
                value: 12.5f);

            migrationBuilder.UpdateData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Weight",
                value: 4.2f);

            migrationBuilder.UpdateData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Weight",
                value: 8.9f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Weight",
                value: 12.5);

            migrationBuilder.UpdateData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Weight",
                value: 4.2000000000000002);

            migrationBuilder.UpdateData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Weight",
                value: 8.9000000000000004);
        }
    }
}

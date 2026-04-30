using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class EquipmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "EquipmentTable");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "EquipmentTable",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "EquipmentTable");

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "EquipmentTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

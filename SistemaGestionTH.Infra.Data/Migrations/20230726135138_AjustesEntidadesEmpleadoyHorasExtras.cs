using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionTH.Infra.Data.Migrations
{
    public partial class AjustesEntidadesEmpleadoyHorasExtras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manager",
                table: "HorasExtras");

            migrationBuilder.AddColumn<int>(
                name: "TypeRemuneration",
                table: "HorasExtras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TypeIdentification",
                table: "Empleados",
                type: "int",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeRemuneration",
                table: "HorasExtras");

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "HorasExtras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TypeIdentification",
                table: "Empleados",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);
        }
    }
}

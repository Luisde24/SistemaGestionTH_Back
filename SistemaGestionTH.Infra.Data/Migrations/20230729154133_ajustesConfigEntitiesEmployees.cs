using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionTH.Infra.Data.Migrations
{
    public partial class ajustesConfigEntitiesEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_Empleados_AreaId",
                table: "HorasExtras");

            migrationBuilder.CreateIndex(
                name: "IX_HorasExtras_EmployeesId",
                table: "HorasExtras",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_Empleados_EmployeesId",
                table: "HorasExtras",
                column: "EmployeesId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_Empleados_EmployeesId",
                table: "HorasExtras");

            migrationBuilder.DropIndex(
                name: "IX_HorasExtras_EmployeesId",
                table: "HorasExtras");

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_Empleados_AreaId",
                table: "HorasExtras",
                column: "AreaId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

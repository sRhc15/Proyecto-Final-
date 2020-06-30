using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class CreateKalumCarreraTecnica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_CarreraTecnica_CarreraTecnicaId",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_CarreraTecnicaId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "CarreraTecnicaId",
                table: "Alumnos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarreraTecnicaId",
                table: "Alumnos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CarreraTecnicaId",
                table: "Alumnos",
                column: "CarreraTecnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_CarreraTecnica_CarreraTecnicaId",
                table: "Alumnos",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnica",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

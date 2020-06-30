using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class CreateKalumClase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarreraTecnicaId",
                table: "Alumnos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarreraTecnica",
                columns: table => new
                {
                    CarreraTecnicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraTecnica", x => x.CarreraTecnicaId);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioInicio = table.Column<DateTime>(nullable: false),
                    HorarioFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellidos = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Comentario = table.Column<string>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    SalonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSalon = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Capacidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.SalonId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clase_CarreraTecnicaId",
                table: "Clase",
                column: "CarreraTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_HorarioId",
                table: "Clase",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_InstructorId",
                table: "Clase",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_SalonId",
                table: "Clase",
                column: "SalonId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_CarreraTecnica_CarreraTecnicaId",
                table: "Clase",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnica",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Horario_HorarioId",
                table: "Clase",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Instructor_InstructorId",
                table: "Clase",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Salon_SalonId",
                table: "Clase",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_CarreraTecnica_CarreraTecnicaId",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_CarreraTecnica_CarreraTecnicaId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Horario_HorarioId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Instructor_InstructorId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Salon_SalonId",
                table: "Clase");

            migrationBuilder.DropTable(
                name: "CarreraTecnica");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropIndex(
                name: "IX_Clase_CarreraTecnicaId",
                table: "Clase");

            migrationBuilder.DropIndex(
                name: "IX_Clase_HorarioId",
                table: "Clase");

            migrationBuilder.DropIndex(
                name: "IX_Clase_InstructorId",
                table: "Clase");

            migrationBuilder.DropIndex(
                name: "IX_Clase_SalonId",
                table: "Clase");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_CarreraTecnicaId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "CarreraTecnicaId",
                table: "Alumnos");
        }
    }
}

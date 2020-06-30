using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class CreateKalumAsignacionAlumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    ClaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Ciclo = table.Column<int>(nullable: false),
                    CarreraTecnicaId = table.Column<int>(nullable: false),
                    SalonId = table.Column<int>(nullable: false),
                    HorarioId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    CupoMinimo = table.Column<int>(nullable: false),
                    CupoMaximo = table.Column<int>(nullable: false),
                    CantidadAsignaciones = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.ClaseId);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionAlumno",
                columns: table => new
                {
                    AsignacionAlumnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaseId = table.Column<int>(nullable: false),
                    AlumnoId = table.Column<int>(nullable: false),
                    FechaAsignacion = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionAlumno", x => x.AsignacionAlumnoId);
                    table.ForeignKey(
                        name: "FK_AsignacionAlumno_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionAlumno_Clase_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clase",
                        principalColumn: "ClaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionAlumno_AlumnoId",
                table: "AsignacionAlumno",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionAlumno_ClaseId",
                table: "AsignacionAlumno",
                column: "ClaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionAlumno");

            migrationBuilder.DropTable(
                name: "Clase");
        }
    }
}

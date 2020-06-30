using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class ModifyTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumno_Clase_ClaseId",
                table: "AsignacionAlumno");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salon",
                table: "Salon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horario",
                table: "Horario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clase",
                table: "Clase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarreraTecnica",
                table: "CarreraTecnica");

            migrationBuilder.RenameTable(
                name: "Salon",
                newName: "Salones");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructores");

            migrationBuilder.RenameTable(
                name: "Horario",
                newName: "Horarios");

            migrationBuilder.RenameTable(
                name: "Clase",
                newName: "Clases");

            migrationBuilder.RenameTable(
                name: "CarreraTecnica",
                newName: "CarreraTecnicas");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_SalonId",
                table: "Clases",
                newName: "IX_Clases_SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_InstructorId",
                table: "Clases",
                newName: "IX_Clases_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_HorarioId",
                table: "Clases",
                newName: "IX_Clases_HorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_CarreraTecnicaId",
                table: "Clases",
                newName: "IX_Clases_CarreraTecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salones",
                table: "Salones",
                column: "SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructores",
                table: "Instructores",
                column: "InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horarios",
                table: "Horarios",
                column: "HorarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clases",
                table: "Clases",
                column: "ClaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas",
                column: "CarreraTecnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumno_Clases_ClaseId",
                table: "AsignacionAlumno",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "ClaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnicas",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Horarios_HorarioId",
                table: "Clases",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases",
                column: "InstructorId",
                principalTable: "Instructores",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Salones_SalonId",
                table: "Clases",
                column: "SalonId",
                principalTable: "Salones",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumno_Clases_ClaseId",
                table: "AsignacionAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Horarios_HorarioId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Salones_SalonId",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salones",
                table: "Salones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructores",
                table: "Instructores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horarios",
                table: "Horarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clases",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas");

            migrationBuilder.RenameTable(
                name: "Salones",
                newName: "Salon");

            migrationBuilder.RenameTable(
                name: "Instructores",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "Horarios",
                newName: "Horario");

            migrationBuilder.RenameTable(
                name: "Clases",
                newName: "Clase");

            migrationBuilder.RenameTable(
                name: "CarreraTecnicas",
                newName: "CarreraTecnica");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_SalonId",
                table: "Clase",
                newName: "IX_Clase_SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_InstructorId",
                table: "Clase",
                newName: "IX_Clase_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_HorarioId",
                table: "Clase",
                newName: "IX_Clase_HorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_CarreraTecnicaId",
                table: "Clase",
                newName: "IX_Clase_CarreraTecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salon",
                table: "Salon",
                column: "SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horario",
                table: "Horario",
                column: "HorarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clase",
                table: "Clase",
                column: "ClaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarreraTecnica",
                table: "CarreraTecnica",
                column: "CarreraTecnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumno_Clase_ClaseId",
                table: "AsignacionAlumno",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "ClaseId",
                onDelete: ReferentialAction.Cascade);

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
    }
}

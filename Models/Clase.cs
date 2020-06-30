using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class Clase
    {
        public int ClaseId {get; set;}
	    public string Descripcion {get; set;}
	    public int Ciclo {get; set;}
	    public int CarreraTecnicaId {get; set;}
	    public int SalonId {get; set;}
	    public int HorarioId {get; set;}
	    public int InstructorId {get; set;}
	    public int CupoMinimo {get; set;}
	    public int CupoMaximo {get; set;}
	    public int CantidadAsignaciones {get; set;}
        public virtual CarreraTecnica CarreraTecnica {get; set;}
        public virtual Horario Horario {get; set;}
	    public virtual Salon Salon {get; set;}
	    public virtual Instructor Instructor {get; set;}
        public virtual List<AsignacionAlumno> AsignacionAlumnos {get; set;}
    }
}
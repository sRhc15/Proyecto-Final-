using System;

namespace Kalum2020v1.Models
{
    public class AsignacionAlumno
    {
        public int AsignacionAlumnoId {get; set;}
	    public int ClaseId {get; set;}
	    public int AlumnoId {get; set;}
	    public DateTime FechaAsignacion {get; set;}
	    public string Observaciones {get; set;}
	    public virtual Alumno Alumno {get; set;}
	    public virtual Clase Clase {get; set;}
    }
}
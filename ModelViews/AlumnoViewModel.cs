using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Input;
using Kalum2020v1.DataContext;
using Kalum2020v1.Models;
using Microsoft.EntityFrameworkCore;

namespace Kalum2020v1.ModelViews
{
    enum ACCION
    {
        NINGUNO,
        NUEVO,
        MODIFICAR
    }
    public class AlumnoViewModel : INotifyPropertyChanged, ICommand
    {
        private ACCION _accion = ACCION.NINGUNO;
        private KalumDbContext dbContext;

        private AlumnoViewModel _Instancia;

        //private IDialogCoordinator dialogCoordinator;
        
        
        
        private bool _IsGuardar = false;
        private bool _IsCancelar = false;
        private bool _IsNuevo = true;
        private bool _IsModificar = true;
        private bool _IsEliminar = true;
        private bool _IsReadOnlyApellidos = true;

        private int _Posicion;
        public int Posicion
        {
            get { return _Posicion; }
            set { _Posicion = value; }
        }

        private bool _IsReadOnlyCarne =true;
        public bool IsReadOnlyCarne
        {
            get { return _IsReadOnlyCarne; }
            set { _IsReadOnlyCarne = value; NotificarCambio("IsReadOnlyCarne"); }
        }
        
        public bool IsReadOnlyApellidos 
        { 
            get
            {
                return _IsReadOnlyApellidos;
            }
            set
            {
                this._IsReadOnlyApellidos =value;
                NotificarCambio("IsReadOnlyAppellidos");
            }   
        }
        private bool _IsReadOnlyNombres;
        public bool IsReadOnlyNombres
        {
            get { return _IsReadOnlyNombres; }
            set { _IsReadOnlyNombres = value;  NotificarCambio("IsReadOnlyNombres"); }
        }

        private bool _IsReadOnlyFechaNacimiento;
        public bool IsReadOnlyFechaNacimiento
        {
            get { return _IsReadOnlyFechaNacimiento; }
            set { _IsReadOnlyFechaNacimiento = value; NotificarCambio("IsReadOnlyFechaNacimiento");}
        }
        
        private Alumno _Update;
        public Alumno Update
        {
            get { return _Update; }
            set { _Update = value; }
        }
        
        public bool IsEliminar
        {
            get
            {
                return this._IsEliminar;
            }
            set
            {
                this._IsEliminar = value;
                NotificarCambio("IsEliminar");
            }
        }
        private bool IsModificar
        {
            get
            {
                return this._IsModificar;
            }
            set
            {
                this._IsModificar = value;
                NotificarCambio("isModificar");
            }
        }
        private bool IsNuevo
        {
            get
            {
                return this._IsNuevo;
            }
            set
            {
                this._IsNuevo = value;
                NotificarCambio("isNuevo");
            }
        }
        private bool IsCancelar
        {
            get
            {
                return this._IsCancelar;
            }
            set
            {
                this._IsCancelar = value;
                NotificarCambio("isCancelar");
            }
        }
        private bool IsGuardar
        {
            get
            {
                return this._IsGuardar;
            }
            set
            {
                this._IsGuardar = value;
                NotificarCambio("isGuardar");
            }
        }

        public AlumnoViewModel Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
                NotificarCambio("Instancia");
            }
        }

        private Alumno _ElementoSeleccionado;

        public Alumno ElementoSeleccionado
        {
            get
            {
                return this._ElementoSeleccionado;
            }
            set
            {
                this._ElementoSeleccionado = value;
                NotificarCambio("ElementoSeleccionado");
            }
        }
        private ObservableCollection<Alumno> _ListaAlumno;

        public ObservableCollection<Alumno> ListaAlumno
        {
            get
            {
                if (_ListaAlumno == null)
                {
                    _ListaAlumno = new ObservableCollection<Alumno>(dbContext.Alumnos.ToList());  //Esto es como hacer select * from Alumno
                }
                return _ListaAlumno;
            }
            set
            {
                _ListaAlumno = value;
            }
        }

        public AlumnoViewModel()
        {
            this.dbContext = new KalumDbContext();
            this.Instancia = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if (parametro.Equals("Nuevo"))
            {
                this._accion = ACCION.NUEVO;
                this.ElementoSeleccionado = new Alumno();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
            }
            else if (parametro.Equals("Modificar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    this._accion = ACCION.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyFechaNacimiento=true;
                    this.IsReadOnlyNombres = false;
                    this.IsReadOnlyApellidos = false;
                    this.Posicion = this.ListaAlumno.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Alumno();
                    this.Update.AlumnoId = this.ElementoSeleccionado.AlumnoId;
                    this.Update.Carne = this.ElementoSeleccionado.Carne;
                    this.Update.Apellidos = this.ElementoSeleccionado.Apellidos;
                    this.Update.Nombres = this.ElementoSeleccionado.Nombres;
                    this.Update.FechaNacimiento = this.ElementoSeleccionado.FechaNacimiento;
                }  
            }
            else if (parametro.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCION.NUEVO:
                        try
                        {
                            Religion r = this.dbContext.Religiones.Find(1); //Select * from Religiones where ReligionId = 1
                            this.ElementoSeleccionado.Religion = r;
                            this.dbContext.Alumnos.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();  //Se almacena primero a la base de datos
                            this.ListaAlumno.Add(this.ElementoSeleccionado); //Luego se almacena a la lista en el Grid
                            SystemSounds.Beep.Play();
                            MessageBox.Show("Datos almacenados!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    break;
                    case ACCION.MODIFICAR:
                        if(this.ElementoSeleccionado != null)
                        {
                            this.dbContext.Entry(this.ElementoSeleccionado).State = EntityState.Modified;
                            this.dbContext.SaveChanges();
                            MessageBox.Show("Datos Actualizados!!");
                            this.IsNuevo = true;
                            this.IsEliminar = true;
                            this.IsModificar = true;
                            this.IsGuardar = false;
                            this.IsCancelar = false;
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un elemento!");
                        }
                    break;    
                }
            }

            else if(parametro.Equals("Cancelar"))
            {
                if(this._accion == ACCION.MODIFICAR)
                {
                    this.ListaAlumno.RemoveAt(this.Posicion);
                    ListaAlumno.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyApellidos = true;
                this.IsReadOnlyNombres = true;
                this.IsReadOnlyFechaNacimiento = false;
                
            }
            

            else if (parametro.Equals("Eliminar"))
            {
                
                if(this.ElementoSeleccionado !=null)
                {
                    MessageBoxResult resultado = MessageBox.Show("Realmente desea eliminar el registro?", "Eliminar",MessageBoxButton.YesNo);
                    if(resultado == MessageBoxResult.Yes)
                    {
                        this.dbContext.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();
                        this.ListaAlumno.Remove(this.ElementoSeleccionado);
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Registro eliminado!!!");
                        
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento!!");
                    SystemSounds.Hand.Play();
                }
                /*try
                {
                    this.dbContext.Alumnos.Remove(this.ElementoSeleccionado);
                    this.dbContext.SaveChanges();
                    this.ListaAlumno.Remove(this.ElementoSeleccionado);
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Registro Eliminado!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }*/
            }
        }

        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}
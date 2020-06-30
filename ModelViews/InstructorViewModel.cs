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
    public class InstructorViewModel : INotifyPropertyChanged, ICommand
    {
        private ACCION _accion = ACCION.NINGUNO;
        private KalumDbContext dbContext;
        private InstructorViewModel _Instancia;

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
        public bool IsReadOnlyApellidos
        {
            get { return _IsReadOnlyApellidos; }
            set { _IsReadOnlyApellidos = value; NotificarCambio("IsReadOnlyApellidos"); }
        }
        private bool _IsReadOnlyNombres;
        public bool IsReadOnlyNombres
        {
            get { return _IsReadOnlyNombres; }
            set { _IsReadOnlyNombres = value; NotificarCambio("IsReadOnlyNombres"); }
        }
        private bool _IsReadOnlyDireccion;
        public bool IsReadOnlyDireccion
        {
            get { return _IsReadOnlyDireccion; }
            set { _IsReadOnlyDireccion = value; NotificarCambio("IsReadOnlyDireccion"); }
        }
        private bool _IsReadOnlyTelefono;
        public bool IsReadOnlyTelefono
        {
            get { return _IsReadOnlyTelefono; }
            set { _IsReadOnlyTelefono = value; NotificarCambio("IsReadOnlyTelefono"); }
        }
        private bool _IsReadOnlyComentario;
        public bool IsReadOnlyComentario
        {
            get { return _IsReadOnlyComentario; }
            set { _IsReadOnlyComentario = value; NotificarCambio("IsReadOnlyComentario"); }
        }
        private bool _IsReadOnlyEstatus;
        public bool IsReadOnlyEstatus
        {
            get { return _IsReadOnlyEstatus; }
            set { _IsReadOnlyEstatus = value; NotificarCambio("IsReadOnlyEstatus"); }
        }
        private bool _IsReadOnlyFoto;
        public bool IsReadOnlyFoto
        {
            get { return _IsReadOnlyFoto; }
            set { _IsReadOnlyFoto = value; NotificarCambio("IsReadOnlyFoto"); }
        }

        private Instructor _Update;
        public Instructor Update
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


        public InstructorViewModel Instancia
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

        private Instructor _ElementoSeleccionado;
        public Instructor ElementoSeleccionado
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
        private ObservableCollection<Instructor> _ListaInstructor;

        public ObservableCollection<Instructor> ListaInstructor
        {
            get
            {
                if (_ListaInstructor == null)
                {
                    _ListaInstructor = new ObservableCollection<Instructor>(dbContext.Instructores.ToList());  //Esto es como hacer select * from Alumno
                }
                return _ListaInstructor;
            }
            set
            {
                _ListaInstructor = value;
            }
        }

        public InstructorViewModel()
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

        public void Execute(object parameter)
        {
            if (parameter.Equals("Nuevo"))
            {
                this._accion = ACCION.NUEVO;
                this.ElementoSeleccionado = new Instructor();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
            }
            else if (parameter.Equals("Modificar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    this._accion = ACCION.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyNombres = false;
                    this.IsReadOnlyApellidos = false;
                    this.Posicion = this.ListaInstructor.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Instructor();
                    this.Update.InstructorId = this.ElementoSeleccionado.InstructorId;
                    this.Update.Direccion = this.ElementoSeleccionado.Direccion;
                    this.Update.Apellidos = this.ElementoSeleccionado.Apellidos;
                    this.Update.Nombres = this.ElementoSeleccionado.Nombres;
                    this.Update.Telefono = this.ElementoSeleccionado.Telefono;
                    this.Update.Comentario = this.ElementoSeleccionado.Comentario;
                    this.Update.Estatus = this.ElementoSeleccionado.Estatus;
                    this.Update.Foto = this.ElementoSeleccionado.Foto;
                }
            }
            else if (parameter.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCION.NUEVO:
                        try
                        {
                            this.dbContext.Instructores.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();  //Se almacena primero a la base de datos
                            this.ListaInstructor.Add(this.ElementoSeleccionado); //Luego se almacena a la lista en el Grid
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
            else if(parameter.Equals("Cancelar"))
            {
                if(this._accion == ACCION.MODIFICAR)
                {
                    this.ListaInstructor.RemoveAt(this.Posicion);
                    ListaInstructor.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyApellidos = true;
                this.IsReadOnlyNombres = true;
                this.IsReadOnlyDireccion = true;
                this.IsReadOnlyTelefono = true;
                this.IsReadOnlyComentario = true;
                this.IsReadOnlyEstatus = true;
                this.IsReadOnlyFoto = true;
            }
            else if (parameter.Equals("Eliminar"))
            {
                if(this.ElementoSeleccionado !=null)
                {
                    MessageBoxResult resultado = MessageBox.Show("Realmente desea eliminar el registro?", "Eliminar",MessageBoxButton.YesNo);
                    if(resultado == MessageBoxResult.Yes)
                    {
                        this.dbContext.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();
                        this.ListaInstructor.Remove(this.ElementoSeleccionado);
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Registro eliminado!!!");
                        
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento!!");
                    SystemSounds.Hand.Play();
                }
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
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
    public class SalonViewModel : INotifyPropertyChanged, ICommand
    {
        private ACCION _accion = ACCION.NINGUNO;
        private KalumDbContext dbContext;

        private SalonViewModel _Instancia;

        private bool _IsGuardar = false;
        private bool _IsCancelar = false;
        private bool _IsNuevo = true;
        private bool _IsModificar = true;
        private bool _IsEliminar = true;
        private bool _IsReadOnlyNombreSalon = true;

        private int _Posicion;
        public int Posicion
        {
            get { return _Posicion; }
            set { _Posicion = value; }
        }
        private bool _IsReadOnlyDescripcion;
        public bool IsReadOnlyDescripcion
        {
            get { return _IsReadOnlyDescripcion; }
            set { _IsReadOnlyDescripcion = value; NotificarCambio("IsReadOnlyDescripcion"); }
        }
        private bool _IsReadOnlyCapacidad;
        public bool IsReadOnlyCapacidad
        {
            get { return _IsReadOnlyCapacidad; }
            set { _IsReadOnlyCapacidad = value; NotificarCambio("IsReadOnlyCapacidad"); }
        }

        public bool IsReadOnlyNombreSalon
        {
            get { return _IsReadOnlyNombreSalon; }
            set { this._IsReadOnlyNombreSalon = value; NotificarCambio("IsReadOnlyNombreSalon"); }
        }

        private Salon _Update;
        public Salon Update
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

        public SalonViewModel Instancia
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

        private Salon _ElementoSeleccionado;
        public Salon ElementoSeleccionado
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
        private ObservableCollection<Salon> _ListaSalon;

        public ObservableCollection<Salon> ListaSalon
        {
            get
            {
                if (_ListaSalon == null)
                {
                    _ListaSalon = new ObservableCollection<Salon>(dbContext.Salones.ToList());  //Esto es como hacer select * from Alumno
                }
                return _ListaSalon;
            }
            set
            {
                _ListaSalon = value;
            }
        }

        public SalonViewModel()
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
                this.ElementoSeleccionado = new Salon();
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
                    this.IsReadOnlyNombreSalon = false;
                    this.IsReadOnlyDescripcion = false;
                    this.IsReadOnlyCapacidad = false;
                    this.Posicion = this.ListaSalon.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Salon();
                    this.Update.SalonId = this.ElementoSeleccionado.SalonId;
                    this.Update.NombreSalon = this.ElementoSeleccionado.NombreSalon;
                    this.Update.Descripcion = this.ElementoSeleccionado.Descripcion;
                    this.Update.Capacidad = this.ElementoSeleccionado.Capacidad;
                }
            }
            else if (parameter.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCION.NUEVO:
                        try
                        {
                            this.dbContext.Salones.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();  //Se almacena primero a la base de datos
                            this.ListaSalon.Add(this.ElementoSeleccionado); //Luego se almacena a la lista en el Grid
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
                    this.ListaSalon.RemoveAt(this.Posicion);
                    ListaSalon.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyNombreSalon = true;
                this.IsReadOnlyDescripcion = true;
                this.IsReadOnlyCapacidad = false;
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
                        this.ListaSalon.Remove(this.ElementoSeleccionado);
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
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
    /*enum ACCION
    {
        NINGUNO,
        NUEVO,
        MODIFICAR
    }*/
    public class CarreraTecnicaViewModel : INotifyPropertyChanged, ICommand
    {
        private ACCION _accion = ACCION.NINGUNO;
        private KalumDbContext dbContext;
        private CarreraTecnicaViewModel _Instancia;

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

        private bool _IsReadOnlyNombreCarrera;
        public bool IsReadOnlyNombreCarrera
        {
            get { return _IsReadOnlyNombreCarrera; }
            set { this._IsReadOnlyNombreCarrera = value; NotificarCambio("IsReadOnlyNombreCarrera"); }
        }

        private CarreraTecnica _Update;
        public CarreraTecnica Update
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


        public CarreraTecnicaViewModel Instancia
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

        private CarreraTecnica _ElementoSeleccionado;
        public CarreraTecnica ElementoSeleccionado
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
        private ObservableCollection<CarreraTecnica> _ListaCarreraTecnica;
        public ObservableCollection<CarreraTecnica> ListaCarreraTecnica
        {
            get
            {
                if (_ListaCarreraTecnica == null)
                {
                    _ListaCarreraTecnica = new ObservableCollection<CarreraTecnica>(dbContext.CarreraTecnicas.ToList());
                }
                return _ListaCarreraTecnica;
            }
            set
            {
                _ListaCarreraTecnica = value;
            }
        }

        public CarreraTecnicaViewModel()
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
                this.ElementoSeleccionado = new CarreraTecnica();
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
                    this.IsReadOnlyNombreCarrera = true;
                    this.Posicion = this.ListaCarreraTecnica.IndexOf(this.ElementoSeleccionado);
                    this.Update = new CarreraTecnica();
                    this.Update.CarreraTecnicaId = this.ElementoSeleccionado.CarreraTecnicaId;
                    this.Update.NombreCarrera = this.ElementoSeleccionado.NombreCarrera;
                }
            }

            else if (parameter.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCION.NUEVO:
                        try
                        {
                            this.dbContext.CarreraTecnicas.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();
                            this.ListaCarreraTecnica.Add(this.ElementoSeleccionado);
                            MessageBox.Show("Datos Guardados");
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
                    this.ListaCarreraTecnica.RemoveAt(this.Posicion);
                    ListaCarreraTecnica.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyNombreCarrera = true;
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
                        this.ListaCarreraTecnica.Remove(this.ElementoSeleccionado);
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

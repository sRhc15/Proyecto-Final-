using System;
using System.ComponentModel;
using System.Media;
using System.Windows;
using System.Windows.Input;
using Kalum2020v1.Models;
using Kalum2020v1.Views;

namespace Kalum2020v1.ModelViews
{
    public class MainViewModel : INotifyPropertyChanged, ICommand
    {
        private string _ImgFoto = $"{Environment.CurrentDirectory}\\Imagenes\\fondo.jpg";
        public string ImgFoto
        {
            get { return _ImgFoto; }
            set { _ImgFoto = value; }
        }
        
        private Usuario _Usuario;
        public Usuario Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value;  }
        }
        
        private bool _IsMenuCatalogo = false;
        public bool IsMenuCatalogo
        {
            get { return _IsMenuCatalogo; }
            set { _IsMenuCatalogo = value; NotificarCambio("IsMenuCatalogo");}
        }

        private bool _IsMenuLogin = true;
        public bool IsMenuLogin
        {
            get { return _IsMenuLogin; }
            set { _IsMenuLogin = value; NotificarCambio("IsMenuLogin"); }
        }
        
        
        private MainViewModel _Instancia;

        public MainViewModel Instancia
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
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if(parametro.Equals("AlumnosView"))
            {
                AlumnoView view = new AlumnoView();
                view.ShowDialog();
            }
            else if(parametro.Equals("CarreraTecnicasView"))
            {
                CarreraTecnicaView view = new CarreraTecnicaView();
                view.ShowDialog();
            }
            else if(parametro.Equals("HorariosView"))
            {
                HorarioView view = new HorarioView();
                view.ShowDialog();
            }
            else if(parametro.Equals("InstructoresView"))
            {
                InstructorView view = new InstructorView();
                view.ShowDialog();
            }
            else if(parametro.Equals("SalonesView"))
            {
                SalonView view = new SalonView();
                view.ShowDialog();
            }
            else if(parametro.Equals("LoginView"))
            {
                try{
                    LoginView view = new LoginView(this.Usuario, this);
                    if(this.Usuario !=null)
                    {
                        this.IsMenuCatalogo = true;
                    }
                    view.ShowDialog();
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        public MainViewModel()
        {
            this.Instancia = this;
        }

        public void NotificarCambio(string propiedad)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}
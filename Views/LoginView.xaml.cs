using System.Windows;
using Kalum2020v1.Models;
using Kalum2020v1.ModelViews;

namespace Kalum2020v1.Views
{
    public partial class LoginView :Window
    {
        private LoginModelView _ModelView;
        public LoginView(Usuario usuario, MainViewModel mainViewModel)
        {
            InitializeComponent();
            _ModelView = new LoginModelView(usuario, mainViewModel);
            this.DataContext = _ModelView;
        }
    }
}
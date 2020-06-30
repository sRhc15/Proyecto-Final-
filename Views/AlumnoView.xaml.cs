using System.Windows;
using Kalum2020v1.ModelViews;

namespace Kalum2020v1.Views
{
    public partial class AlumnoView :Window
    {
        private AlumnoViewModel model;
        public AlumnoView()
        {
            InitializeComponent();
            model = new AlumnoViewModel();
            this.DataContext = model;
        }
    }
}
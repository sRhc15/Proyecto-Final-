using System.Windows;
using Kalum2020v1.ModelViews;

namespace Kalum2020v1.Views
{
    public partial class SalonView: Window
    {
        private SalonViewModel model4;
        public SalonView()
        {
            InitializeComponent();
            model4 = new SalonViewModel();
            this.DataContext = model4;
        }
    }
}
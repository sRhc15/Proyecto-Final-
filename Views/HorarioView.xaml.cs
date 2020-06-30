using System.Windows;
using Kalum2020v1.ModelViews;

namespace Kalum2020v1.Views
{
    public partial class HorarioView: Window
    {
        private HorarioViewModel model2;
        public HorarioView()
        {
            InitializeComponent();
            model2 = new HorarioViewModel();
            this.DataContext = model2;
        }
    }
}
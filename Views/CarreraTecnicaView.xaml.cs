using System;
using System.Windows;
using Kalum2020v1.ModelViews;

namespace Kalum2020v1.Views
{
    public partial class CarreraTecnicaView: Window
    {
        private CarreraTecnicaViewModel model1;
        public CarreraTecnicaView()
        {
            InitializeComponent();
            model1 = new CarreraTecnicaViewModel();
            this.DataContext = model1;
        }

        
    }
}
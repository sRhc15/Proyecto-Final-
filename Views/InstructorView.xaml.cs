using System.Windows;
using Kalum2020v1.ModelViews;

namespace Kalum2020v1.Views
{
    public partial class InstructorView: Window
    {
        private InstructorViewModel model3;
        public InstructorView()
        {
            InitializeComponent();
            model3 = new InstructorViewModel();
            this.DataContext = model3;
        }
    }
}
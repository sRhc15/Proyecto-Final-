using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kalum2020v1.ModelViews;
using Kalum2020v1.Views;

namespace Kalum2020v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel model;
        public MainWindow()
        {
            InitializeComponent(); 
            model = new MainViewModel();
            this.DataContext = model;
            
        }

       /* private void Btn_Alumno (object sender, RoutedEventArgs e)
        {
            new AlumnoView().ShowDialog();
        }

        private void Btn_CarreraTecnica (object sender, RoutedEventArgs e)
        {
            new CarreraTecnicaView().ShowDialog();
        }

        private void Btn_Horario (object sender, RoutedEventArgs e)
        {
            new HorarioView().ShowDialog();
        }

        private void Btn_Instructor (object sender, RoutedEventArgs e)
        {
            new InstructorView().ShowDialog();
        }

        private void Btn_Salon (object sender, RoutedEventArgs e)
        {
            new SalonView().ShowDialog();
        }*/

    }
}

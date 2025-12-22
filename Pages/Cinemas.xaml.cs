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
using Cinema_Shashin.Elements;

namespace Cinema_Shashin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cinemas.xaml
    /// </summary>
    public partial class Cinemas : Page
    {
        public List<Classes.Cinemas> _cinemas;
        public Cinemas()
        {
            InitializeComponent();
            MainWindow.mainWindow.LoadCinemas();
            var _cinemas = MainWindow.mainWindow.cinemas;
            foreach(var cinemas in _cinemas)
            {
                parent.Children.Add(new CinemasItm(cinemas));
            }
            parent.Children.Add(new AddCinema());
        }
    }
}

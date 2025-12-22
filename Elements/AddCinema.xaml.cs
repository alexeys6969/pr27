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

namespace Cinema_Shashin.Elements
{
    /// <summary>
    /// Логика взаимодействия для AddCinema.xaml
    /// </summary>
    public partial class AddCinema : UserControl
    {
        public AddCinema()
        {
            InitializeComponent();
        }

        private void addCinema(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.AddCin());
        }
    }
}

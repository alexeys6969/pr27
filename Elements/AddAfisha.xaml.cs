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
    /// Логика взаимодействия для AddAfisha.xaml
    /// </summary>
    public partial class AddAfisha : UserControl
    {
        Classes.Afish _afish;
        Classes.Cinemas _cinema;
        public AddAfisha(Classes.Cinemas cinema)
        {
            InitializeComponent();
            _cinema = cinema;
        }

        private void addAfisha(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Afisha.EditAfishaInfo(_afish, _cinema));
        }
    }
}

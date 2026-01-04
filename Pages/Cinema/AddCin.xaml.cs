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
using Cinema_Shashin.Classes;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Cinema_Shashin.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddCin.xaml
    /// </summary>
    public partial class AddCin : Page
    {
        public AddCin()
        {
            InitializeComponent();
        }

        private void editCinema(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCinema = new Classes.Cinemas(titleTb.Text, int.Parse(hallCountTb.Text), int.Parse(seatsCountTb.Text));
                MainWindow.mainWindow.AddCinema(newCinema);
                MessageBox.Show("Успешное выполнение запроса");
                MainWindow.mainWindow.frame.Navigate(new Pages.Cinemas());
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Cinemas());
        }
    }
}

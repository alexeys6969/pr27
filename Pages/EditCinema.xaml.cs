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

namespace Cinema_Shashin.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditCinema.xaml
    /// </summary>
    public partial class EditCinema : Page
    {
        Classes.Cinemas cinemas;
        public EditCinema(Classes.Cinemas _cinemas)
        {
            InitializeComponent();
            cinemas = _cinemas;
            titleTb.Text = cinemas.Title;
            hallCountTb.Text = cinemas.Hall_Count.ToString();
            seatsCountTb.Text = cinemas.Total_Seats.ToString();
        }

        private void editCinema(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.mainWindow.EditCinema(titleTb.Text.ToString(), int.Parse(hallCountTb.Text), int.Parse(seatsCountTb.Text));
                MessageBox.Show("Успешное выполнение запроса");
                MainWindow.mainWindow.frame.Navigate(new Pages.Cinemas());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void deleteCinema(object sender, RoutedEventArgs e)
        {

        }

        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Cinemas());
        }
    }
}

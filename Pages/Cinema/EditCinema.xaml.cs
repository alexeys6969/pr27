using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        Classes.Cinemas currentCinema;
        public EditCinema(Classes.Cinemas _cinemas)
        {
            InitializeComponent();
            currentCinema = _cinemas;
            titleTb.Text = currentCinema.Title;
            hallCountTb.Text = currentCinema.Hall_Count.ToString();
            seatsCountTb.Text = currentCinema.Total_Seats.ToString();
        }

        private void editCinema(object sender, RoutedEventArgs e)
        {
            try
            {
                currentCinema.Title = titleTb.Text;
                currentCinema.Hall_Count = int.Parse(hallCountTb.Text);
                currentCinema.Total_Seats = int.Parse(seatsCountTb.Text);
                MainWindow.mainWindow.EditCinema(currentCinema);
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
            try
            {
                var deleteDialogResult = MessageBox.Show("Вы точно хотите удалить этот кинотеатр?","Удаление", MessageBoxButton.YesNo);
                if (deleteDialogResult == MessageBoxResult.Yes)
                {
                    MainWindow.mainWindow.DeleteCinema(currentCinema);
                    MessageBox.Show("Успешное выполнение запроса");
                }
                MainWindow.mainWindow.frame.Navigate(new Pages.Cinemas());
            }
            catch (Exception ex)
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

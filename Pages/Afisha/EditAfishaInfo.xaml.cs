using Cinema_Shashin.Classes;
using MySql.Data.MySqlClient;
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

namespace Cinema_Shashin.Pages.Afisha
{
    /// <summary>
    /// Логика взаимодействия для EditAfishaInfo.xaml
    /// </summary>
    public partial class EditAfishaInfo : Page
    {
        Classes.Afish afish;
        Classes.Cinemas cinema;
        public EditAfishaInfo(Classes.Afish _afish, Classes.Cinemas _cinemas)
        {
            InitializeComponent();
            afish = _afish;
            cinema = _cinemas;
            if (afish == null)
            {
                cinemaName.Text += cinema.Title;
                mainLabel.Content = "Добавить афишу";
                editBtn.Content = "Добавить афишу";
            } else
            {
                cinemaName.Text += cinema.Title;
                movieTb.Text = afish.movie;
                dateSeans.SelectedDate = afish.date_seans;
                DateTime timeValue = DateTime.Today.Add(afish.time_film);
                timeSeans.Value = timeValue;
                priceTb.Text = afish.price.ToString();
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Afisha.Afishas(cinema));
        }
        private void editAfisha(object sender, RoutedEventArgs e)
        {
            if(afish == null)
            {
                cinemaName.Text += cinema.Title;
                TimeSpan time = timeSeans.Value.Value.TimeOfDay;
                afish = new Classes.Afish(
                cinema_id: cinema.Id,
                movie: movieTb.Text,
                date_seans: dateSeans.SelectedDate.Value,
                time_film: time,
                price: decimal.Parse(priceTb.Text)
            );
                try
                {
                    MainWindow.mainWindow.AddAfisha(afish);
                    MessageBox.Show("Успешное выполнение запросы");
                } catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            } else
            {
                try
                {
                    afish.movie = movieTb.Text;
                    afish.date_seans = (DateTime)dateSeans.SelectedDate;
                    afish.time_film = timeSeans.Value.Value.TimeOfDay;
                    afish.price = decimal.Parse(priceTb.Text);
                    MainWindow.mainWindow.EditAfisha(afish);
                    MessageBox.Show("Успешное выполнение запросы");
                    MainWindow.mainWindow.frame.Navigate(new Pages.Afisha.Afishas(cinema));
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}

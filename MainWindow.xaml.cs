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
using Cinema_Shashin.Classes;
using MySql.Data.MySqlClient;

namespace Cinema_Shashin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Cinemas> cinemas = new List<Cinemas>();
        public static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            frame.Navigate(new Pages.Cinemas());
        }

        public void LoadCinemas()
        {
            cinemas.Clear();
            string connection = "server=localhost;port=3307;database=Cinemas;uid=root;";
            MySqlConnection mySqlConnection = new MySqlConnection(connection);
            mySqlConnection.Open();
            string query = $"SELECT * FROM `cinema`";
            MySqlDataReader reader = Connection.Query(query, mySqlConnection);
            while (reader.Read())
            {
                cinemas.Add(new Cinemas(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)
                    ));
            }
            mySqlConnection.Close();
        }


        public void AddCinema(Cinemas _cinema)
        {
            string connect = "server=localhost;port=3307;database=Cinemas;uid=root;";
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "INSERT INTO Cinema (title, hall_count, total_seats) VALUES (@title, @hallCount, @seatsCount);";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", _cinema.Title);
                    command.Parameters.AddWithValue("@hallCount", _cinema.Hall_Count);
                    command.Parameters.AddWithValue("@seatsCount", _cinema.Total_Seats);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditCinema(Cinemas _cinema)
        {
            string connect = "server=localhost;port=3307;database=Cinemas;uid=root;";
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "UPDATE Cinema set title = @title, " +
                    "hall_count = @hallCount, " +
                    "total_seats = @seatsCount " +
                    "WHERE id = @id;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", _cinema.Id);
                    command.Parameters.AddWithValue("@title", _cinema.Title);
                    command.Parameters.AddWithValue("@hallCount", _cinema.Hall_Count);
                    command.Parameters.AddWithValue("@seatsCount", _cinema.Total_Seats);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

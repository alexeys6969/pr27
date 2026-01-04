using Cinema_Shashin.Classes;
using Cinema_Shashin.Pages.Afisha;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace Cinema_Shashin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Cinemas> cinemas = new List<Cinemas>();
        public List<Afish> afishas = new List<Afish>();
        public static MainWindow mainWindow;
        public string connection = "server=localhost;port=3307;database=Cinemas;uid=root;";

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            frame.Navigate(new Pages.Cinemas());
        }

        public void LoadAfishas(Cinemas cinema)
        {
            cinemas.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(connection);
            mySqlConnection.Open();
            string query = $"SELECT * FROM `afisha` where cinema_id = {cinema.Id}";
            MySqlDataReader reader = Connection.Query(query, mySqlConnection);
            while (reader.Read())
            {
                afishas.Add(new Afish(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetDateTime(3),
                    reader.GetTimeSpan(4),
                    reader.GetDecimal(5)
                    ));
            }
            mySqlConnection.Close();
        }

        public void LoadCinemas()
        {
            cinemas.Clear();
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
                using (var connect = new MySqlConnection(connection))
                {
                    connect.Open();
                    string query = "INSERT INTO Cinema (title, hall_count, total_seats) VALUES (@title, @hallCount, @seatsCount);";

                    using (var command = new MySqlCommand(query, connect))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@title", _cinema.Title);
                            command.Parameters.AddWithValue("@hallCount", _cinema.Hall_Count);
                            command.Parameters.AddWithValue("@seatsCount", _cinema.Total_Seats);
                            command.ExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }

                    }
                }
        }

        public void EditCinema(Cinemas _cinema)
        {
            using (var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "UPDATE Cinema set title = @title, " +
                    "hall_count = @hallCount, " +
                    "total_seats = @seatsCount " +
                    "WHERE id = @id;";

                using (var command = new MySqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", _cinema.Id);
                    command.Parameters.AddWithValue("@title", _cinema.Title);
                    command.Parameters.AddWithValue("@hallCount", _cinema.Hall_Count);
                    command.Parameters.AddWithValue("@seatsCount", _cinema.Total_Seats);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCinema(Cinemas _cinema)
        {
            using (var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "DELETE FROM cinema where id = @Id";

                using (var command = new MySqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", _cinema.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

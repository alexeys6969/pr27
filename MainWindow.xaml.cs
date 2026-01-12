using Cinema_Shashin.Classes;
using Cinema_Shashin.Pages;
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
        public List<Classes.Cinemas> cinemas = new List<Classes.Cinemas>();
        public List<Afish> afishas = new List<Afish>();
        public static MainWindow mainWindow;
        public string connection = "server=localhost;port=3306;database=Cinemas;uid=root;";

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            frame.Navigate(new Pages.Cinemas());
        }

        #region Afishas
        public void LoadAfishas(Classes.Cinemas cinema)
        {
            afishas.Clear();
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

        public void AddAfisha(Afish _afish)
        {
            using (var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "INSERT INTO afisha (cinema_id, movie, date_seans, time_film, price) VALUES (@cinema_id, @movie, @date_seans, @time_film, @price);";

                using (var command = new MySqlCommand(query, connect))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@cinema_id", _afish.cinema_id);
                        command.Parameters.AddWithValue("@movie", _afish.movie);
                        command.Parameters.AddWithValue("@date_seans", _afish.date_seans);
                        command.Parameters.AddWithValue("@time_film", _afish.time_film);
                        command.Parameters.AddWithValue("@price", _afish.price);
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
            }
        }

        public void EditAfisha(Afish _afish)
        {
            using (var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "UPDATE afisha set cinema_id = @cinema_id, " +
                    "movie = @movie, " +
                    "date_seans = @date_seans, " +
                    "time_film = @time_film, " +
                    "price = @price " +
                    "WHERE id = @id;";

                using (var command = new MySqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", _afish.id);
                    command.Parameters.AddWithValue("@cinema_id", _afish.cinema_id);
                    command.Parameters.AddWithValue("@movie", _afish.movie);
                    command.Parameters.AddWithValue("@date_seans", _afish.date_seans);
                    command.Parameters.AddWithValue("@time_film", _afish.time_film);
                    command.Parameters.AddWithValue("@price", _afish.price);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAfisha(Afish _afish)
        {
            using (var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "DELETE FROM afisha where id = @Id";

                using (var command = new MySqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", _afish.id);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion
        #region Cinema
        public void LoadCinemas()
        {
            cinemas.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(connection);
            mySqlConnection.Open();
            string query = $"SELECT * FROM `cinema`";
            MySqlDataReader reader = Connection.Query(query, mySqlConnection);
            while (reader.Read())
            {
                cinemas.Add(new Classes.Cinemas(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)
                    ));
            }
            mySqlConnection.Close();
        }
        public void AddCinema(Classes.Cinemas _cinema)
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

        public void EditCinema(Classes.Cinemas _cinema)
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

        public void DeleteCinema(Classes.Cinemas _cinema)
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

        #endregion
    }
}

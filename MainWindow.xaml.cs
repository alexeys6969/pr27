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
            string query = $"SELECT id, titile, hall_count, SUM(capacity) " +
                $"FROM Cinema " +
                $"JOIN Halls ON id = cinema_id " +
                $"GROUP BY id, titile;";
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
    }
}

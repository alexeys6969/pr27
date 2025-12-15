using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cinema_Shashin.Classes
{
    public static class Connection
    {
        public static MySqlDataReader Query(string query, MySqlConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new MySqlCommand(query, connection);
                return command.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

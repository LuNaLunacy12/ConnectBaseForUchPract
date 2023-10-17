using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp4
{
    public class Connection
    {
        public static NpgsqlConnection connection;
        public static void Connect(string host, string port, string user, string dbname)
        {
            string cs = $"Server={host};Port={port};User ID={user}; DataBase={dbname}";

            connection = new NpgsqlConnection(cs);
            connection.Open();
        }

        public static ObservableCollection<CLProducts> products { get; set; } = new ObservableCollection<CLProducts>();

        public static NpgsqlCommand GetCommand(string sql)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            return command;
        }

        public static void SelectTableProduct()
        {
            NpgsqlCommand cmd = GetCommand("SELECT \"product_id\",\"photo\",\"nameproduct\",\"description\",\"price\",\"discount\",\"manufactures\",\"quantity\" FROM \"products\"");
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    products.Add(new CLProducts(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetInt32(4), result.GetInt32(5), result.GetString(6), result.GetInt32(7)));
                }

            }
            result.Close();
        }
    }

}

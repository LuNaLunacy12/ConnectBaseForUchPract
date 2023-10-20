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
        public static void Connect(string host, string port, string user, string pass, string dbname)
        {
            string cs = $"Server={host};Port={port};User ID={user}; Password={pass}; DataBase={dbname}";

            connection = new NpgsqlConnection(cs);
            connection.Open();
        }

        public static ObservableCollection<CLProducts> products { get; set; } = new ObservableCollection<CLProducts>();
        public static ObservableCollection<CLManufacture> manufactures { get; set; } = new ObservableCollection<CLManufacture>();
        public static ObservableCollection<CLOrders> orders { get; set; } = new ObservableCollection<CLOrders> { };
        public static ObservableCollection<CLPointOfIssue> points { get; set; } = new ObservableCollection<CLPointOfIssue> { };
        public static ObservableCollection<ClProductsOfOrders> productsOfOrders { get; set; } = new ObservableCollection<ClProductsOfOrders> { };
        public static ObservableCollection<CLUsers> users { get; set; } = new ObservableCollection<CLUsers> { };
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

        public static void SelectTableManufacturer()
        {
            NpgsqlCommand cmd = GetCommand("Select \"namemanufacturer\" from \"manufacturer\"");
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    manufactures.Add(new CLManufacture(result.GetString(0)));
                }

            }
            result.Close();
        }
        
        public static void SelectTableOrders()
        {
            NpgsqlCommand cmd = GetCommand("Select \"order_id\", \"userid\", \"pointofissue_id\", \"kode\", \"dataOrder\" from \"orders\" ");
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    orders.Add(new CLOrders(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2), result.GetString(3), result.GetDateTime(4)));
                }

            }
            result.Close();
        }
        public static void SelectTablePointofissue()
        {
            NpgsqlCommand cmd = GetCommand("Select \"pointofissue_id\", \"adress\" from \"poitofissue\"");
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    points.Add(new CLPointOfIssue(result.GetInt32(0), result.GetString(1)));
                }

            }
            result.Close();
        }
        public static void SelectTableProductsOfOvner()
        {
            NpgsqlCommand cmd = GetCommand("Select \"ordersID\", \"productsID\", \"quantity\" from \"productsOfOvners\"");
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    productsOfOrders.Add(new ClProductsOfOrders(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2)));
                }

            }
            result.Close();
        }
        public static void SelectTableUsers()
        {
            NpgsqlCommand cmd = GetCommand("Select \"usersid\", \"fullnameusers\", \"userphone\", \"userpassword\" from \"users\"");
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    users.Add(new CLUsers(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3)));
                }

            }
            result.Close();
        }
    }

}

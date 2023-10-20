
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Ink;
using System.Data;
using NpgsqlTypes;

namespace WpfApp4
{

    public partial class login : Page
    {
        //public cmd database;

        public login()
        {
            InitializeComponent();
            //database = new cmd();
  
        }

        
        private void singin_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlCommand cmd = Connection.GetCommand("select \"usersid\", \"usersphone\", \"fullnameusers\", \"userspassword\" from \"users\"  where \"usersphone\" = @log and \"userspassword\" = @pass");
            cmd.Parameters.AddWithValue("@log", NpgsqlDbType.Varchar, loginus.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", NpgsqlDbType.Varchar, passwordus.Text.Trim());
            NpgsqlDataReader result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    Connection.users.Add(new CLUsers(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3)));
                }
            }
            result.Close();
            NavigationService.Navigate( new ContentProducts());
           
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ContentProducts.xaml", UriKind.Relative));
        }

    }
}

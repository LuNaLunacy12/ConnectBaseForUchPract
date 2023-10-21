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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для ContentProducts.xaml
    /// </summary>
    public partial class ContentProducts : Page
    {
        public ContentProducts()
        {
         
                InitializeComponent();
                lvBindingProduct();
            if (Connection.user != null) { 
                LogIn.Content = Connection.user.Userphone;
            }
        }
         public void lvBindingProduct()
            {
                Binding binding = new Binding
                { Source = Connection.products };
                lvProduct.SetBinding(ItemsControl.ItemsSourceProperty, binding);
                Connection.SelectTableProduct();
            }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            
            if (Connection.user == null)
            {
                Connection.products.Clear();
                NavigationService.Navigate(new Uri("/login.xaml", UriKind.Relative));
            }
            else
            {

            }
           
            
        }
    }
    }


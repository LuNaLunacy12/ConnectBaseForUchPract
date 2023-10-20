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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void NazadforSingIN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/login.xaml", UriKind.Relative));
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

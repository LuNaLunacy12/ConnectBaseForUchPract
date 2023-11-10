
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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Interop;


namespace WpfApp4
{

    public partial class login : Page
    {
    [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteObject([In] IntPtr hObject);
    public ImageSource ImageSourceFromBitmap(Bitmap bmp)
    {
        var handle = bmp.GetHbitmap();
        try
        {
            return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
        finally { DeleteObject(handle); }
    }
    

    public login()
        {
            InitializeComponent();
            CaptchaPicture.Source = ImageSourceFromBitmap(CreateImage((int)CaptchaPicture.Width, (int)CaptchaPicture.Height));
        }

        
        private void singin_Click(object sender, RoutedEventArgs e)
        {
            if (CapthaBox.Text == this.text)
            {


                NpgsqlCommand cmd = Connection.GetCommand("select \"usersid\", \"usersphone\", \"fullnameusers\", \"userspassword\" from \"users\"  where \"usersphone\" = @log and \"userspassword\" = @pass");
                cmd.Parameters.AddWithValue("@log", NpgsqlDbType.Varchar, loginus.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", NpgsqlDbType.Varchar, passwordus.Text.Trim());
                NpgsqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Connection.user = new CLUsers(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3));
                    }
                }
                result.Close();
                NavigationService.Navigate(new ContentProducts());
            }

            else
            {
                MessageBox.Show("Капча введена неверно!");
            }
           
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new Uri("/ContentProducts.xaml", UriKind.Relative));
            
            
        }

        private string text = String.Empty;
        
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();
            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);
            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 60);
            int Ypos = rnd.Next(15, Height - 35);
            //Добавим различные цвета
            System.Drawing.Brush[] colors = { System.Drawing.Brushes.Black,
            System.Drawing.Brushes.Firebrick,
            System.Drawing.Brushes.DarkBlue,
            System.Drawing.Brushes.DarkGreen };
            //Укажем где рисовать
            Graphics g = Graphics.FromImage((System.Drawing.Image)result);
            //Пусть фон картинки будет серым
            g.Clear(System.Drawing.Color.LightSteelBlue);
            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i <4 ; ++i)
                text += ALF[rnd.Next(ALF.Length)];
            //Нарисуем сгенирируемый текст
            g.DrawString(text,
            new Font("Areal", 15),
            colors[rnd.Next(colors.Length)],
            new PointF(Xpos, Ypos));
            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
            new System.Drawing.Point(0, 0),
            new System.Drawing.Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
            new System.Drawing.Point(0, Height - 1),
            new System.Drawing.Point(Width - 1, 0));
            g.DrawLine(Pens.Black,
                new System.Drawing.Point(0, Height-1),
                new System.Drawing.Point(Width + 1, Height- 10 ));

            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, System.Drawing.Color.White);
            return result;
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {

            CaptchaPicture.Source = ImageSourceFromBitmap(CreateImage((int)CaptchaPicture.Width, (int)CaptchaPicture.Height));

        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            if (CapthaBox.Text == this.text)
                MessageBox.Show("Верно!");
            else
                MessageBox.Show("Капча введена неверно!");

        }

        private void GuestR_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ContentProducts());
        }
    }
}

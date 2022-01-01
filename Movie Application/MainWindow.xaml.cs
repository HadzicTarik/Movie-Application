using System;
using System.IO;
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
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Movie_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
    
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Movie_Application.Properties.Settings.MovieAppConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            
            StartProperties();
            //UseIDFromUserInfo();
        }
        private void StartProperties()
        {
            Label l = new Label();
            int z = 1;

            sqlConnection.Open();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string readString = "SELECT Name FROM MovieInfo WHERE ID=" + z;
                    SqlCommand readCommand = new SqlCommand(readString, sqlConnection);
                    using (SqlDataReader dataRead = readCommand.ExecuteReader())
                    {
                        if (dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                                l = (Label)FindName("lbl" + i + j);
                                l.Content = dataRead["Name"].ToString();
                            }
                        }
                    }
                    z++;
                }
            }
            sqlConnection.Close();

            Image img = new Image();
            byte[] imageByte;
            z = 1;
            sqlConnection.Open();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string readString = "SELECT MovieImage FROM MovieInfo WHERE ID=" + z;
                    SqlCommand readCommand = new SqlCommand(readString, sqlConnection);

                    using (SqlDataReader dataRead = readCommand.ExecuteReader())
                    {
                        if (dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                                img = (Image)FindName("ib" + i + j);
                                imageByte = (byte[])dataRead["MovieImage"];
                                img.Source = BytesToImage(imageByte);
                            }
                        }
                    }
                    z++;
                }
            }
            sqlConnection.Close();

            dpGenre.IsEnabled = true;
            dpYear.IsEnabled = true;
            tbOption.Visibility = Visibility.Hidden;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        //----------------Konvertovanje bita u sliku--------------------------
        public static BitmapImage BytesToImage(byte[] bytes)
        {
            var bm = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                stream.Position = 0;
                bm.BeginInit();
                bm.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bm.CacheOption = BitmapCacheOption.OnLoad;
                bm.UriSource = null;
                bm.StreamSource = stream;
                bm.EndInit();
            }
            return bm;
        }
        //--------------------------------------------------------------------
        private void ActionMovie_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();

            lbl00.Content = lbl30.Content;
            ib00.Source = ib30.Source;
            lbl20.Content = lbl50.Content;
            ib20.Source = ib50.Source;
            lbl30.Content = lbl02.Content;
            ib30.Source = ib02.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;

            tbOption.Text = "Action";
        }

        private void ActionHorror_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();

            lbl10.Content = lbl41.Content;
            ib10.Source = ib41.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;

            tbOption.Text = "Action-Horror";
        }

        private void Comedy_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Comedy";

            lbl00.Content = lbl20.Content;
            ib00.Source = ib20.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void Drama_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Drama";

            lbl00.Content = lbl12.Content;
            ib00.Source = ib12.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void Horror_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Horror";

            lbl00.Content = lbl52.Content;
            ib00.Source = ib52.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void Romance_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Romance";

            lbl00.Content = lbl01.Content;
            ib00.Source = ib01.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void ActionComedy_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Action-Comedy";

            lbl00.Content = lbl31.Content;
            ib00.Source = ib31.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void ActionDrama_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Action-Drama";

            lbl00.Content = lbl11.Content;
            ib00.Source = ib11.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void ActionRomance_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Action-Romance";

            lbl00.Content = lbl21.Content;
            ib00.Source = ib21.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void DramaComedy_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Drama-Comedy";

            lbl00.Content = lbl42.Content;
            ib00.Source = ib42.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void DramaRomance_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Drama-Romance";

            lbl00.Content = lbl01.Content;
            ib00.Source = ib01.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void DramaHorror_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Drama-Horror";

            lbl00.Content = lbl32.Content;
            ib00.Source = ib32.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void ComedyRomance_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Comedy-Romance";

            lbl00.Content = lbl22.Content;
            ib00.Source = ib22.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void ComedyHorror_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Comedy-Horror";

            lbl00.Content = lbl51.Content;
            ib00.Source = ib51.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }

        private void HorrorRomance_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();
            tbOption.Text = "Horror-Romance";

            lbl00.Content = lbl40.Content;
            ib00.Source = ib40.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;
        }
        private void ibLogo_MouseEnter(object sender, MouseEventArgs e)
        {
            StartProperties();
        }

        private void y2021_Click(object sender, RoutedEventArgs e)
        {
            StartProperties();

            lbl00.Content = lbl50.Content;
            ib00.Source = ib50.Source;

            gridContent01.Visibility = Visibility.Hidden;
            gridContent02.Visibility = Visibility.Hidden;
            gridContent10.Visibility = Visibility.Hidden;
            gridContent11.Visibility = Visibility.Hidden;
            gridContent12.Visibility = Visibility.Hidden;
            gridContent20.Visibility = Visibility.Hidden;
            gridContent21.Visibility = Visibility.Hidden;
            gridContent22.Visibility = Visibility.Hidden;
            gridContent30.Visibility = Visibility.Hidden;
            gridContent31.Visibility = Visibility.Hidden;
            gridContent32.Visibility = Visibility.Hidden;
            gridContent40.Visibility = Visibility.Hidden;
            gridContent41.Visibility = Visibility.Hidden;
            gridContent42.Visibility = Visibility.Hidden;
            gridContent50.Visibility = Visibility.Hidden;
            gridContent51.Visibility = Visibility.Hidden;
            gridContent52.Visibility = Visibility.Hidden;

            tbOption.Text = "Movie in 2021";
        }

        private void y2020_Click(object sender, RoutedEventArgs e)
        {

        }

        private void y2019_Click(object sender, RoutedEventArgs e)
        {

        }

        private void y2018_Click(object sender, RoutedEventArgs e)
        {

        }

        private void y2017_Click(object sender, RoutedEventArgs e)
        {

        }

        private void y2016_Click(object sender, RoutedEventArgs e)
        {

        }

        private void y2015_Click(object sender, RoutedEventArgs e)
        {

        }

        private void y2014_2000_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gridContent00_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayVideo playVideo = new PlayVideo();
            playVideo.tbUsername.Text = tbUsername.Text;
            playVideo.ShowDialog();
            playVideo.btnPlay.IsEnabled = true;
        }
        private void gridContent01_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayVideo01 playVideo = new PlayVideo01();
            playVideo.tbUsername.Text = tbUsername.Text;
            playVideo.ShowDialog();
            playVideo.btnPlay.IsEnabled = true;
        }
            private void gridContent02_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                PlayVideo02 playVideo = new PlayVideo02();
                playVideo.tbUsername.Text = tbUsername.Text;
                playVideo.ShowDialog();
                playVideo.btnPlay.IsEnabled = true;
            }
            private void gridContent01_MouseEnter(object sender, MouseEventArgs e)
        {
            b01.BorderBrush = Brushes.Red;
            i01.Visibility = Visibility.Visible;
        }
        private void gridContent00_MouseEnter(object sender, MouseEventArgs e)
        {
            br00.BorderBrush = Brushes.Red;
            i00.Visibility = Visibility.Visible;
        }
        private void gridContent02_MouseEnter(object sender, MouseEventArgs e)
        {
            b02.BorderBrush = Brushes.Red;
            i02.Visibility = Visibility.Visible;
        }
        private void gridContent00_MouseLeave(object sender, MouseEventArgs e)
        {
            br00.BorderBrush = Brushes.AliceBlue;
            i00.Visibility = Visibility.Hidden;
        }
        private void gridContent01_MouseLeave(object sender, MouseEventArgs e)
        {
            b01.BorderBrush = Brushes.AliceBlue;
            i01.Visibility = Visibility.Hidden;
        }
        private void gridContent02_MouseLeave(object sender, MouseEventArgs e)
        {
            b02.BorderBrush = Brushes.AliceBlue;
            i02.Visibility = Visibility.Hidden;
        }

        private void spWatchList_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WatchList watchList = new WatchList();

            watchList.lblUsername.Content = tbUsername.Text;

            watchList.ShowDialog();
            
        }
        public int UseIDFromUserInfo()
        {
            int userID;
            sqlConnection.Open();
            string readString = "SELECT ID FROM UserInfo WHERE Username='" + tbUsername.Text + "'";
            SqlCommand readCommand = new SqlCommand(readString, sqlConnection);
            SqlDataReader dataRead = readCommand.ExecuteReader();
            dataRead.Read();
            userID = (int)dataRead["ID"];
            sqlConnection.Close();
            return userID;
        }
    }
}

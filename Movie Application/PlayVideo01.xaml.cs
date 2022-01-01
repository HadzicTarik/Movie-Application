using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Movie_Application
{
    ///<summary>
    /// Interaction logic for PlayVideo.xaml
    /// </summary>
    public partial class PlayVideo01 : Window
    {
        //<materialDesign:RatingBar Foreground = "Yellow" />
        private readonly SqlConnection sqlConnection;
        public PlayVideo01()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Movie_Application.Properties.Settings.MovieAppConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            StartProperties();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            VideoControl.Play();
            btnPause.IsEnabled = true;
            btnPlay.IsEnabled = false;
            btnStop.IsEnabled = true;
            cbRatedMovie.Visibility = Visibility.Visible;
            cbRatedMovie.IsEnabled = true;
            tbRatedMovie.Text = "Rate the movie";

            int userInfoID;
            sqlConnection.Open();
            string readString1 = "SELECT ID FROM UserInfo WHERE Username='" + tbUsername.Text + "'";
            SqlCommand readCommand1 = new SqlCommand(readString1, sqlConnection);
            SqlDataReader dataRead1 = readCommand1.ExecuteReader();
            dataRead1.Read();
            userInfoID = (int)dataRead1["ID"];
            sqlConnection.Close();

            int movieInfoID;
            sqlConnection.Open();
            string readString2 = "SELECT ID FROM MovieInfo WHERE Name='" + tbMovieName.Text + "'";
            SqlCommand readCommand2 = new SqlCommand(readString2, sqlConnection);
            SqlDataReader dataRead2 = readCommand2.ExecuteReader();
            dataRead2.Read();
            movieInfoID = (int)dataRead2["ID"];
            sqlConnection.Close();

            string dt = DateTime.Now.ToLongDateString();

            sqlConnection.Open();
            string query1 = "SELECT COUNT(1) ID FROM WatchingMoviesAndRating WHERE UserInfo_ID='" + userInfoID + "' AND MovieInfo_ID=2";
            SqlCommand sqlCommand1 = new SqlCommand(query1, sqlConnection);
            int sum = Convert.ToInt32(sqlCommand1.ExecuteScalar());
            if (sum == 0)
            {
                string query = "INSERT INTO WatchingMoviesAndRating (UserInfo_ID, MovieInfo_ID, Date) " +
                           "VALUES (@ui, @mi, @dt)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ui", userInfoID);
                sqlCommand.Parameters.AddWithValue("@mi", movieInfoID);
                sqlCommand.Parameters.AddWithValue("@dt", dt);
                sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
            }
        }
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            VideoControl.Pause();
            btnPause.IsEnabled = false;
            btnPlay.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            VideoControl.Stop();
            btnPause.IsEnabled = false;
            btnPlay.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            VideoControl.Stop();
            this.Close();
        }
        private void ButtonMinimized_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void StartProperties()
        {
            sqlConnection.Open();
            string readString = "SELECT Name FROM MovieInfo WHERE ID=2";
            SqlCommand readCommand = new SqlCommand(readString, sqlConnection);
            SqlDataReader dataRead = readCommand.ExecuteReader();
            dataRead.Read();
            tbMovieName.Text = dataRead["Name"].ToString();
            tbMovieName.Foreground = Brushes.Yellow;
            sqlConnection.Close();

            sqlConnection.Open();
            string readString2 = "SELECT Release_Date FROM MovieInfo WHERE ID=2";
            SqlCommand readCommand2 = new SqlCommand(readString2, sqlConnection);
            SqlDataReader dataRead2 = readCommand2.ExecuteReader();
            dataRead2.Read();
            tbDataRelased.Text = dataRead2["Release_Date"].ToString();
            tbDataRelased.Foreground = Brushes.Yellow;
            sqlConnection.Close();

            sqlConnection.Open();
            string readString3 = "SELECT Name, Lastname FROM MovieActors WHERE ID=2";
            SqlCommand readCommand3 = new SqlCommand(readString3, sqlConnection);
            SqlDataReader dataRead3 = readCommand3.ExecuteReader();
            dataRead3.Read();
            tbActor.Text = dataRead3["Name"].ToString() + " " + dataRead3["Lastname"].ToString();
            tbActor.Foreground = Brushes.Yellow;
            sqlConnection.Close();

            sqlConnection.Open();
            string readString4 = "SELECT Name, Lastname FROM MovieDirector WHERE ID=2";
            SqlCommand readCommand4 = new SqlCommand(readString4, sqlConnection);
            SqlDataReader dataRead4 = readCommand4.ExecuteReader();
            dataRead4.Read();
            tbDirector.Text = dataRead4["Name"].ToString() + " " + dataRead4["Lastname"].ToString();
            tbDirector.Foreground = Brushes.Yellow;
            sqlConnection.Close();

            sqlConnection.Open();
            string readString5 = "SELECT Name FROM MovieGenre WHERE ID=11";
            SqlCommand readCommand5 = new SqlCommand(readString5, sqlConnection);
            SqlDataReader dataRead5 = readCommand5.ExecuteReader();
            dataRead5.Read();
            tbGenre.Text = dataRead5["Name"].ToString();
            tbGenre.Foreground = Brushes.Yellow;
            sqlConnection.Close();

            RatingScore();
        }
        public void RatingProces()
        {
            int userInfoID;
            sqlConnection.Open();
            string readString7 = "SELECT ID FROM UserInfo WHERE Username='" + tbUsername.Text + "'";
            SqlCommand readCommand7 = new SqlCommand(readString7, sqlConnection);
            SqlDataReader dataRead7 = readCommand7.ExecuteReader();
            dataRead7.Read();
            userInfoID = (int)dataRead7["ID"];
            sqlConnection.Close();

            sqlConnection.Open();
            string query1 = "SELECT COUNT(1) ID FROM WatchingMoviesAndRating WHERE UserInfo_ID='" + userInfoID + "' AND MovieInfo_ID=2";
            SqlCommand sqlCommand1 = new SqlCommand(query1, sqlConnection);
            int sum = Convert.ToInt32(sqlCommand1.ExecuteScalar());
            sqlConnection.Close();
            if (sum != 0)
            {
                int rating;
                sqlConnection.Open();
                string readString8 = "SELECT Rating FROM WatchingMoviesAndRating WHERE UserInfo_ID='" + userInfoID + "' AND MovieInfo_ID=2";
                SqlCommand readCommand8 = new SqlCommand(readString8, sqlConnection);
                SqlDataReader dataRead8 = readCommand8.ExecuteReader();
                dataRead8.Read();
                rating = (int)dataRead8["Rating"];
                sqlConnection.Close();
                if (rating != 0)
                {
                    cbRatedMovie.IsEnabled = false;
                    tbRatedMovie.Text = "You have already rated";
                    cbRatedMovie.Visibility = Visibility.Collapsed;
                }
                else
                {
                    cbRatedMovie.IsEnabled = true;
                    confirmRate.Visibility = Visibility.Visible;
                }
            }
            else
            {
                cbRatedMovie.IsEnabled = false;
                tbRatedMovie.Text = "Watch the movie first";
                cbRatedMovie.Visibility = Visibility.Collapsed;
            }
        }
        private void cbRatedMovie_MouseEnter(object sender, MouseEventArgs e)
        {
            RatingProces();
            if (cbRatedMovie.SelectedIndex < 10)
            {
                confirmRate.Visibility = Visibility.Visible;
            }
            else
            {
                confirmRate.Visibility = Visibility.Collapsed;
            }
        }
        private void confirmRate_Click(object sender, RoutedEventArgs e)
        {
            int userInfoID;
            sqlConnection.Open();
            string readString7 = "SELECT ID FROM UserInfo WHERE Username='" + tbUsername.Text + "'";
            SqlCommand readCommand7 = new SqlCommand(readString7, sqlConnection);
            SqlDataReader dataRead7 = readCommand7.ExecuteReader();
            dataRead7.Read();
            userInfoID = (int)dataRead7["ID"];
            sqlConnection.Close();

            sqlConnection.Open();
            string query = "UPDATE WatchingMoviesAndRating SET Rating=@Rating WHERE UserInfo_ID='" + userInfoID + "' AND MovieInfo_ID=2";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Rating", cbRatedMovie.Text);
            if (cbRatedMovie.Text != "1 to 10")
            {
                sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                confirmRate.Visibility = Visibility.Collapsed;
                MessageBox.Show("Congratulations! Your rated score is: " + cbRatedMovie.Text);
                RatingScore();
                cbRatedMovie.SelectedIndex = 10;
            }
        }
        private void RatingScore()
        {
            float count;
            string query = "SELECT COUNT(*) FROM WatchingMoviesAndRating WHERE Rating!=0 AND MovieInfo_ID=2";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            count = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            if (count != 0)
            {
                float sum;
                string query2 = "SELECT SUM(Rating) FROM WatchingMoviesAndRating WHERE Rating!=0 AND MovieInfo_ID=2";
                SqlCommand sqlCommand2 = new SqlCommand(query2, sqlConnection);
                sqlConnection.Open();
                sum = Convert.ToInt32(sqlCommand2.ExecuteScalar());
                sqlConnection.Close();

                tbMovieRating.Text = string.Format("{0:F2}", sum / count);
            }
            else
            {
                tbMovieRating.Text = "-.-";
            }
        }
    }
}

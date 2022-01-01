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
using System.Windows.Shapes;

namespace Movie_Application
{
    /// <summary>
    /// Interaction logic for WatchList.xaml
    /// </summary>
    public partial class WatchList : Window
    {
        private readonly SqlConnection sqlConnection;
        public string userName;
        public WatchList()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["Movie_Application.Properties.Settings.MovieAppConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            int count = 0;
            int[] moviesInfoIDs = new int[18];
            TextBlock tb = new TextBlock();

            moviesInfoIDs = UseAllMovieInfoIDsFromWatchingMoviesAndRating(UseIDFromUserInfo(), ref count);

            int[] ratings = new int[count];

            ratings = UseAllRatingsFromWatchingMoviesAndRating(UseIDFromUserInfo(), count);

            sqlConnection.Open();
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    for (int j = 1; j < (count + 1); j++)
                    {
                        string readString = "SELECT Name FROM MovieInfo WHERE ID='" + moviesInfoIDs[j - 1] + "'";
                        SqlCommand readCommand = new SqlCommand(readString, sqlConnection);
                        using (SqlDataReader dataRead = readCommand.ExecuteReader())
                        {
                            if (dataRead != null)
                            {
                                while (dataRead.Read())
                                {
                                    tb = (TextBlock)FindName("tb" + i + j);
                                    tb.Text = dataRead["Name"].ToString();
                                }
                            }
                        }
                    }
                }
                if (i == 2)
                {
                    for (int j = 1; j < (count + 1); j++)
                    {
                        tb = (TextBlock)FindName("tb" + i + j);
                        tb.Text = ratings[j - 1].ToString();
                    }
                }
            }
            sqlConnection.Close();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public int UseIDFromUserInfo()
        {
            int userID;
            sqlConnection.Open();
            string readString = "SELECT ID FROM UserInfo WHERE Username='" + lblUsername.Content + "'";
            SqlCommand readCommand = new SqlCommand(readString, sqlConnection);
            SqlDataReader dataRead = readCommand.ExecuteReader();
            dataRead.Read();
            userID = (int)dataRead["ID"];
            sqlConnection.Close();
            return userID;
        }
        public int[] UseAllMovieInfoIDsFromWatchingMoviesAndRating(int userInfoID, ref int count)
        {
            int[] movieInfoID = new int[18];
            sqlConnection.Open();
            string readString = "SELECT MovieInfo_ID FROM WatchingMoviesAndRating WHERE UserInfo_ID='" + userInfoID + "'";
            SqlCommand readCommand = new SqlCommand(readString, sqlConnection);
            using (SqlDataReader dataRead = readCommand.ExecuteReader())
            {
                if (dataRead != null)
                {
                    while (dataRead.Read())
                    {
                        count++;
                        movieInfoID[count - 1] = (int)dataRead["MovieInfo_ID"];
                    }
                }
            }
            sqlConnection.Close();
            return movieInfoID;
        }
        public int[] UseAllRatingsFromWatchingMoviesAndRating(int userInfoID, int count)
        {
            int[] movieInfoID = new int[count];
            int i = 0;
            sqlConnection.Open();
            string readString = "SELECT Rating FROM WatchingMoviesAndRating WHERE UserInfo_ID='" + userInfoID + "'";
            SqlCommand readCommand = new SqlCommand(readString, sqlConnection);
            using (SqlDataReader dataRead = readCommand.ExecuteReader())
            {
                if (dataRead != null)
                {
                    while (dataRead.Read())
                    {
                        i++;
                        movieInfoID[i - 1] = (int)dataRead["Rating"];
                    }
                }
            }
            sqlConnection.Close();
            return movieInfoID;
        }
    }
}

using System;
using System.IO;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Media.Imaging;

namespace Movie_Application
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection sqlConnection;
        Register register = new Register();
        MainWindow movieApplication = new MainWindow();

        public Login()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["Movie_Application.Properties.Settings.MovieAppConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }
        private void LoginSubmit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                string query = "SELECT COUNT(1) FROM UserInfo WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", tbUsername.Text);
                sqlCommand.Parameters.AddWithValue("@Password", pbPassword.Password);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (count == 1)
                {
                    UsernameInAllPages();
                    if (tbUsername.Text == "admin")
                    {
                        movieApplication.Show();
                        Close();
                    }
                    else
                    {
                        movieApplication.spAdminMenu.Visibility = Visibility.Collapsed;
                        movieApplication.spAdminMenu1.Visibility = Visibility.Collapsed;
                        movieApplication.spAdminMenu2.Visibility = Visibility.Collapsed;
                        movieApplication.Show();
                        Close();
                    }
                }
                else if ((tbUsername.Text == "") || (pbPassword.Password == ""))
                {
                    if ((tbUsername.Text == "") && (pbPassword.Password == ""))
                    {
                        MessageBox.Show("Username and Password field is empty");
                    }
                    else if (tbUsername.Text == "")
                    {
                        MessageBox.Show("Username field is empty");
                    }
                    else
                    {
                        MessageBox.Show("Password field is empty");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is inncorect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                tbUsername.Clear();
                pbPassword.Clear();
                tbUsername.Focus();
            }
        }
        public void UsernameInAllPages()
        {
            movieApplication.tbUsername.Text = tbUsername.Text;
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            register.Show();
            Close();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}

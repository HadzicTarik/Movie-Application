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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;

namespace Movie_Application
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private readonly SqlConnection sqlConnection;
        private int execute, read;
        public Register()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["Movie_Application.Properties.Settings.MovieAppConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }
        private void ButtonAddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            BitmapImage bitmap = new BitmapImage();
            string selectedfileName;

            openFileDialog.ShowDialog();
            selectedfileName = openFileDialog.FileName;
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(selectedfileName);
            bitmap.EndInit();
            ibImage.Source = bitmap;
        }
        private void ButtonRegisterSubmit_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            try
            {
                string query = "INSERT INTO UserInfo (Name, Lastname, Country, Gender, DateOfBirth, Username, Password, RePassword, Image) " +
                               "VALUES (@Name, @Lastname, @Country, @Gender, @DateOfBirth, @Username, @Password, @RePassword, @Image)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", tbName.Text);
                sqlCommand.Parameters.AddWithValue("@Lastname", tbLastname.Text);
                sqlCommand.Parameters.AddWithValue("@Country", cbCountry.Text);
                sqlCommand.Parameters.AddWithValue("@Gender", cbGender.Text);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", dpDateOfBirth.SelectedDate.Value.Date);
                sqlCommand.Parameters.AddWithValue("@Username", tbUsername.Text);
                sqlCommand.Parameters.AddWithValue("@Password", pbPassword.Password);
                sqlCommand.Parameters.AddWithValue("@RePassword", pbRePassword.Password);

                if (ibImage.Source != null)
                {
                    MemoryStream ms = new MemoryStream();
                    byte[] imageArray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(imageArray, 0, imageArray.Length);
                    sqlCommand.Parameters.AddWithValue("@Image", imageArray);
                }
                string query2 = "SELECT COUNT(Username) FROM UserInfo WHERE Username='" + tbUsername.Text + "'";
                SqlCommand sqlCommand2 = new SqlCommand(query2, sqlConnection);
                read = Convert.ToInt32(sqlCommand2.ExecuteScalar());
                if (read == 1)
                {
                    MessageBox.Show("Username " + tbUsername.Text + " already exists");
                    tbUsername.Clear();
                    tbUsername.Focus();
                    //sqlConnection.Close();
                }
                else
                {
                    if (pbPassword.Password == pbRePassword.Password)
                    {
                        execute = 1;
                        sqlCommand.ExecuteScalar();
                    }
                    else
                    {
                        MessageBox.Show("Password are not matching");
                        pbPassword.Clear();
                        pbPassword.Focus();
                        pbRePassword.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                if (execute == 1)
                {
                    Close();
                    login.Show();
                }
            }
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

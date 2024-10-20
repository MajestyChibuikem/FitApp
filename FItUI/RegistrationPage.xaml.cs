using fittrack.DataAccess;
using fittrack;
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
using System.Windows.Shapes;
using UI;
using System.Text.RegularExpressions;
namespace FItUI
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string c_password = ConfirmPasswordBox.Password;
            if (!IsValidUsername(username))
            {
                MessageBox.Show("Username can only contain alphanumeric characters.");
                UsernameTextBox.Clear();
                return;
            }
            if (!IsSamePassword(password, c_password))
            {
                MessageBox.Show("Passwords dont match");
                PasswordBox.Clear();
                ConfirmPasswordBox.Clear();
                return;
            }
            else
            {
                if (!IsValidPassword(password))
                {
                    MessageBox.Show("Password must be up to 12 characters");
                    PasswordBox.Clear();
                    ConfirmPasswordBox.Clear();
                    return;
                }
            }
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return;
            }
            var connector = new TextFileConnector();
            var newUser = new User { Username = username, Password = password };
            connector.CreatenewUser(newUser);
            MessageBox.Show("User registered successfully.");
            LoginPage Login = new LoginPage();
            Login.Show();
            this.Close();
            //Dashboard dashboard = new Dashboard();
            //dashboard.Show();
            //this.Close();


        }
        public static bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
        }
        public static bool IsValidPassword(string password)
        {
            if (password.Count() < 12)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsSamePassword(string password, string c_password)
        {
            if (c_password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
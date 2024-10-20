using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using fittrack;
using fittrack.DataAccess;
using FItUI;
namespace UI
{
    public partial class LoginPage : Window
    {
        private IDataconnection dataConnection;
        private int failedAttempts = 0;
        private const int MaxFailedAttempts = 3;
        public LoginPage()
        {
            InitializeComponent();
            dataConnection = new TextFileConnector(); // Initialize your data connection
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            if (failedAttempts >= MaxFailedAttempts)
            {
                // If login attempts exceed the maximum, disable further login attempts
                MessageBox.Show("Too many failed login attempts. Please try again later.");
                return;
            }
            
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return;
            }
            try
            {
                var connector = new TextFileConnector();
                var users = connector.FindAllUsers();
                var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    // Successful login
                    MessageBox.Show("User logged in successfully.");
                    Dashboard dashboard = new Dashboard(user);
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    // Invalid username or password
                    HandleFailedLogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }
        private void HandleFailedLogin()
        {
            failedAttempts++;
            if (failedAttempts >= MaxFailedAttempts)
            {
                MessageBox.Show("Too many failed login attempts. Please try again later.");
                Login.IsEnabled = false;
            }
            else
            {
                MessageBox.Show($"Login failed. You have {MaxFailedAttempts - failedAttempts} attempt(s) left.");
            }
        }
        public static bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
        }
        public static bool IsValidPassword(string password)
        {
            return password.Length == 12;
        }
        private void RegisterLink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
            this.Close();
        }
    }
}
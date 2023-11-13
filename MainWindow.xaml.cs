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
using Newtonsoft.Json;
using System.Security.Cryptography;
using BCrypt.Net;
namespace WpfAppAuthentication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>
        {
            new User { Username = "user1", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password1") },
            new User { Username = "user2", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password2") }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

           
            User user = users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                
                if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    messageTextBlock.Text = "Вход выполнен успешно!";
                }
                else
                {
                    messageTextBlock.Text = "Неверный пароль.";
                }
            }
            else
            {
                messageTextBlock.Text = "Пользователь не найден.";
            }
        }
    }
}
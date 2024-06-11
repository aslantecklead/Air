using Air.Windows.UserWindows;
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

namespace Air.Windows.Defication
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        Session1_XXEntities1 db = new Session1_XXEntities1();
        public Authentication()
        {
            InitializeComponent();
            List_Reload();
        }

        private void List_Reload()
        {
            //var userList = db.Users.ToList();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate_Form(Email.Text, Password.Text))
            {
                MessageBox.Show("Логин и/или пароль не должны быть пустыми!");
                return;
            }
            else
            {
                Check_Account(Email.Text, Password.Text);
            }
        }

        private void Check_Account(string login, string password)
        {
            var userList = db.Users.ToList();
            var usersWithRole = db.Users.ToList();
            userList = userList.Where(x => x.Email == login && x.Password == password).ToList();
            var roleId = 1; 
            usersWithRole = usersWithRole.Where(x => x.RoleID == roleId).ToList();
            if (userList.Count > 0)
            {
                if (usersWithRole.Count > 0)
                {
                    var adminWindow = new MainWindow();
                    adminWindow.Show();
                    Close();
                }
                else
                {
                    var userWindow = new UserWindow();
                    userWindow.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private bool Validate_Form(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

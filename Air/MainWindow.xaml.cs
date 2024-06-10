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
using System.Security.Cryptography;
using System.Security.Policy;
using System.Data.Entity.Infrastructure;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace Air
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Session1_XXEntities1 db = new Session1_XXEntities1();
        public MainWindow()
        {
            InitializeComponent();
            Title = "Пользователи";
            List_Reload();
        }

        public void List_Reload()
        {
            var userList = db.Users.ToList();
            ListCheck.SelectedValuePath = "ID";
            ListCheck.ItemsSource = userList;
            ListCheck.SelectionMode = SelectionMode.Single;

            var OfficeList = db.Offices.ToList();
            Offices.ItemsSource = OfficeList;
            Offices.SelectedIndex = 0;
            Offices.DisplayMemberPath = "Title";
            Offices.SelectedValuePath = "ID";
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("INFO", "User Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }        

        private void Warning_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Warning", "User warn", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Console.WriteLine("Yes");
                    break;
                case MessageBoxResult.No:
                    Console.WriteLine("No");
                    break;
            }
        }

        public void ClearForm()
        {
            Email.Text = "";
            Last_Name.Text = "";
            First_Name.Text = "";
            Offices.SelectedItem = "";
            Password.Text = "";
            //Birthday.SelectedDate = ;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string hash = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password.Text))).Replace("-","");
            Users users = new Users
            {
                Email = Email.Text,
                Password = hash,
                LastName = Last_Name.Text,
                FirstName = First_Name.Text,
                OfficeID = (int)Offices.SelectedValue,
                Birthdate = Birthday.SelectedDate.Value,
                RoleID = (bool)Role.IsChecked ? 1 : 2,
                Active = true,
            };
            db.Users.Add(users);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Error adding: " + ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.Message);
                Trace.WriteLine(ex.InnerException.Message);
            }
            List_Reload();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ListCheck.SelectedItems != null)
            {
                Users selectedItem = (Users)ListCheck.SelectedItem;
                selectedItem.LastName = Last_Name.Text;
                selectedItem.Email = Email.Text;
                selectedItem.LastName = Last_Name.Text;
                selectedItem.FirstName = First_Name.Text;
                selectedItem.Password = Password.Text;
                selectedItem.Birthdate = Birthday.SelectedDate.Value;
                selectedItem.OfficeID = (int)Offices.SelectedValue;
                db.SaveChanges();
                List_Reload();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ListCheck.SelectedItems != null)
            {
                Users selectedItem = (Users)ListCheck.SelectedItem;
                db.Users.Remove(selectedItem);
                db.SaveChanges();
                List_Reload();
            }
        }

        private void ListCheck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListCheck.SelectedItem != null)
            {
                Users selectedItem = (Users)ListCheck.SelectedItem;
                if (selectedItem != null) 
                {
                    Email.Text = selectedItem.Email;
                    Last_Name.Text = selectedItem.LastName;
                    First_Name.Text = selectedItem.FirstName;
                    Offices.SelectedItem = selectedItem.Offices;
                    Password.Text = selectedItem.Password;
                    Birthday.SelectedDate = selectedItem.Birthdate;
                    if (selectedItem.RoleID == 1)
                    {
                        Role.IsChecked = true;
                    }
                    else
                    {
                        Role.IsChecked = false;
                    }
                }
            }
        }

        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выбор фотографии";
            openFileDialog.Filter = "All suported gapfics|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                Prifile.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                File.Delete(Directory.GetCurrentDirectory()+"/Photo/"+openFileDialog.SafeFileName);
                File.Copy(openFileDialog.FileName, Directory.GetCurrentDirectory() + "/Photo/" + openFileDialog.SafeFileName);
            }
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Grid grid = button.Parent as Grid;
                if (grid != null)
                {
                    Users user = grid.DataContext as Users;
                    if (user != null)
                    {
                        Window1 window = new Window1(user);
                        window.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}

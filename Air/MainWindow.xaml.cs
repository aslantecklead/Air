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

namespace Air
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Session1_XXEntities db = new Session1_XXEntities();
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
    }
}

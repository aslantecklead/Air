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

namespace Air.Windows.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для DataUsers.xaml
    /// </summary>
    public partial class DataUsers : Window
    {
        public Session1_XXEntities1 db = new Session1_XXEntities1();
        public DataUsers()
        {
            InitializeComponent();
            Data_Reload();
        }

        public void Data_Reload()
        {
            var userList = db.Users.ToList();
            dgDataUsers.Items.Clear();
            dgDataUsers.SelectedValuePath = "ID";
            dgDataUsers.ItemsSource = userList;
            dgDataUsers.SelectionMode = DataGridSelectionMode.Single;

            var OfficeList = db.Offices.ToList();
            Parametr.ItemsSource = OfficeList;
            Parametr.SelectedIndex = 0;
            Parametr.DisplayMemberPath = "Title";
            Parametr.SelectedValuePath = "ID";

            //Functional functional = new Functional();

            All.Text = userList.Count().ToString();
            Cairo.Text = userList.Where(a => a.Offices.Title == "Cairo").ToList().Count().ToString();
            double averageCount = 0;
            foreach (var user in userList) 
            {
                averageCount += user.ID;
            }
            if (averageCount != 0 && averageCount > 0)
            {
                averageCount /= userList.Count();
            }
            Average.Text = averageCount.ToString();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var UserList = db.Users.Where(a => a.FirstName.Contains(Search.Text) || a.LastName.Contains(Search.Text)).ToList();
            dgDataUsers.SelectedValuePath = "ID";
            dgDataUsers.ItemsSource = UserList;
            dgDataUsers.SelectionMode = DataGridSelectionMode.Single;
        }

        private void Parametr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (true)
            {

            }
        }
    }
}

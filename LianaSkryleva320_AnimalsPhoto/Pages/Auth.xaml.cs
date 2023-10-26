using LianaSkryleva320_AnimalsPhoto.DBConnection;
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


namespace LianaSkryleva320_AnimalsPhoto.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public static List<User> Users { get; set; }
        public Auth()
        {
            InitializeComponent();

        }

        private void EnterBt_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordPb.Password.Trim();
            User currentUser = DBConnection.Connection.animals.User.FirstOrDefault(x => x.Login == login && x.Password == password);
            User Andrey = DBConnection.Connection.animals.User.FirstOrDefault(x => x.Login == "1" && x.Password == "1");
            User Delya = DBConnection.Connection.animals.User.FirstOrDefault(x => x.Login == "2" && x.Password == "2");
            if (currentUser == Andrey)
            {
                MessageBox.Show("Welcome Andrey");
                NavigationService.Navigate(new Pages.InfoPage());
            }
            else if (currentUser == Delya)
            {
                MessageBox.Show("Welcome Delya");
                NavigationService.Navigate(new Pages.InfoPageForDelya());
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}

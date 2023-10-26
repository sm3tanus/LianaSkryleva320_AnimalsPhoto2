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
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public static List<Animal> animal { get; set; }
        public static List<DBConnection.Type> type { get; set; }
        public InfoPage()
        {
            InitializeComponent();
            animal= new List<Animal>(Connection.animals.Animal.Where(i => i.IDType == 1).ToList());
            this.DataContext = this;
        }

        private void FindTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = animal.Where(i => i.Age.StartsWith(FindTb.Text) || i.HowLifeInNowDay.StartsWith(FindTb.Text));
        }

        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterCb.SelectedIndex == 0)
                ListView.ItemsSource = animal.FindAll(i => i.IDType == 1);
            else
                ListView.ItemsSource = "";
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAnimal());
        }
    }
}

using LianaSkryleva320_AnimalsPhoto.DBConnection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddAnimal.xaml
    /// </summary>
    public partial class AddAnimal : Page
    {
        public static List<Animal> animal { get; set; }
        public static List<DBConnection.Type> type { get; set; }
        public AddAnimal()
        {
            InitializeComponent();
            type = new List<DBConnection.Type>(Connection.animals.Type.ToList());
            this.DataContext = this;
        }
        public Animal animals = new Animal();
        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jfif|*.jfif"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                animals.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PhotoAnimal.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void EmplCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            animals.Type = EmplCb.SelectedItem as DBConnection.Type;
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            animals.Age = Ageb.Text.Trim();
            animals.HowLifeInNowDay = InfoTb.Text.Trim();
            Connection.animals.Animal.Add(animals);
            Connection.animals.SaveChanges();
            NavigationService.Navigate(new Auth());
        }
    }
}

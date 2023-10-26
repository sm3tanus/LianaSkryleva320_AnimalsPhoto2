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
        public static List<User> Users { get; set; }
        public InfoPage()
        {
            InitializeComponent();
            Users = new List<User>((IEnumerable<User>)Connection.animals.Animal.ToList());
            this.DataContext = this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public class Ring
    {
        public double Width { get; set; }
    }
    public partial class Page3 : Page
    {
        public ObservableCollection<Ring> Rings { get; set; }
        public Page3()
        {
            InitializeComponent();
            Rings = new ObservableCollection<Ring>
            {
            new Ring { Width = 50 },
            new Ring { Width = 70 },
            new Ring { Width = 90 }
            };
            DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame3.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }
    }
}

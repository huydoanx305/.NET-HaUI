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

namespace Bai9._5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int dem = 0;
            string douong = "";
            if (check1.IsChecked == true)
            {
                dem++;
                douong += "Nước cam tươi; ";
            }
            if (check2.IsChecked == true)
            {
                dem++;
                douong += "Nước kiwi ép; ";
            }
            if (check3.IsChecked == true)
            {
                dem++;
                douong += "Nước xoài ép; ";
            }
            if (check4.IsChecked == true)
            {
                dem++;
                douong += "Sữa tươi tiệt trùng; ";
            }
            if (check5.IsChecked == true)
            {
                dem++;
                douong += "Cà phê Espresso";
            }
            if (dem == 0)
            {
                MessageBox.Show("Bạn chưa chọn đồ uống nào");
            }
            else
            {
                String result = "Bạn đã chọn " + douong;
                MessageBox.Show(result);
            }

        }
        
    }
}

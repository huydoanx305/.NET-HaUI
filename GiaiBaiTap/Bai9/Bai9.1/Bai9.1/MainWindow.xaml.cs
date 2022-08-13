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

namespace Bai9._1
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
            newList.Items.Add(list.SelectedItem.ToString().Split(':')[1]);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                newList.Items.Add(list.Items[i].ToString().Split(':')[1]);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            newList.Items.Remove(newList.SelectedItem);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            newList.Items.Clear();
        }
    }
}

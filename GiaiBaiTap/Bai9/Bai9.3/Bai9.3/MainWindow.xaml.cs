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

namespace Bai9._3
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
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String name = "Họ tên: " + fullName.Text;
            String gender = "Giới tính: ";
            String maritalStatus = "Tình trạng hôn nhân: ";
            String interests = "Sở thích: ";

            
            if (nam.IsChecked == true)
            {
                gender += "Nam";
            } else
            {
                gender += "Nữ";
            }

            if(docthan.IsChecked == true)
            {
                maritalStatus += "Chưa kết hôn";
            } else
            {
                maritalStatus += "Đã kết hôn";
            }

            if(bongda.IsChecked == true)
            {
                interests += "Bóng đá";
            } 
            if(boiloi.IsChecked == true)
            {
                interests += ", Bơi lội";
            }
            if (amnhac.IsChecked == true)
            {
                interests += ", Âm nhạc";
            }
            if (leonui.IsChecked == true)
            {
                interests += ", Leo núi";
            }

            list.Items.Add(name);
            list.Items.Add(gender);
            list.Items.Add(maritalStatus);
            list.Items.Add(interests);
        }
    }
}

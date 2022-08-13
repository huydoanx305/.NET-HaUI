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

namespace Bai9._4
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
            int chiSoCu = int.Parse(chisocu.Text);
            int chiSoMoi = int.Parse(chisomoi.Text);
            int tieuThu = chiSoMoi - chiSoCu;

            tieuthu.Text = tieuThu.ToString();

            int trongDinhMuc = 0;
            int vuotDinhMuc = 0;

            if (tieuThu <= 50)
            {
                trongDinhMuc = tieuThu;
                trongdinhmuc.Text = trongDinhMuc.ToString();
                vuotdinhmuc.Text = vuotDinhMuc.ToString();
            }
            else
            {
                trongDinhMuc = 50;
                trongdinhmuc.Text = trongDinhMuc.ToString();
                vuotDinhMuc = tieuThu - 50;
                vuotdinhmuc.Text = vuotDinhMuc.ToString();
            }
            int tongTien = trongDinhMuc * 500 + vuotDinhMuc * 1000;
            tongtien.Text = tongTien.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            list.Items.Add(khachhang.Text);
            list.Items.Add("Số kw tiêu thụ: " + tieuthu.Text);
            list.Items.Add("Tổng tiền: " + tongtien.Text);
        }
    }
}

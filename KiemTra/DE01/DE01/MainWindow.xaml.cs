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

namespace DE01
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

        private void nhap_Click(object sender, RoutedEventArgs e)
        {
            if (hoten.Text == "" || ngaysinh.SelectedDate == null || loainv.Text == null || tienban.Text == null)
            {
                MessageBox.Show("Các ô không được phép để trống");
                throw new Exception("Các ô không được phép để trống");
            }

            DateTime? datepicker = ngaysinh.SelectedDate;
            DateTime now = DateTime.Now;
            TimeSpan time = now - datepicker.Value;
            double tuoi = double.Parse((time.TotalDays / 365).ToString());
            if (tuoi < 19 || tuoi > 60)
            {
                MessageBox.Show("Tuổi không hợp lệ");
                throw new Exception("Tuổi không hợp lệ");
            }

            double tienBan = double.Parse(tienban.Text);
            double tb;
            if (!double.TryParse(tienban.Text, out tb) || tienBan <= 0)
            {
                MessageBox.Show("Tiền bán phải lớn hơn 0");
                throw new Exception("Số tiền bán phải là số thực và lớn hơn 0");
            }

            double hoaHong = 0;
            if(tienBan > 1000 && tienBan <= 5000)
            {
                hoaHong = tienBan * 0.05;
            } 
            else if (tienBan > 5000)
            {
                hoaHong = tienBan * 0.1;
            }
            listnv.Items.Add(hoten.Text + "-" + ngaysinh.Text + "-" + loainv.Text + "-" + tienban.Text + "-" + hoaHong);
        }

        private void win2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            if (listnv.SelectedItems.Count == 0)
                throw new Exception("Không có mục list box nào dc chọn");
            String data = listnv.SelectedItem.ToString();
            data.Split('-');
            String hoTen = data.Split('-')[0];
            String loaiNV = data.Split('-')[2];
            String ngaySinh = data.Split('-')[1];
            String tienBan = data.Split('-')[3];
            window2.hoten1.Text = hoTen;
            window2.loainv1.Text = loaiNV;
            window2.ngaysinh1.Text = ngaySinh;
            window2.tienban1.Text = tienBan;
            window2.Show();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            if (listnv.SelectedItems.Count == 0)
                throw new Exception("Không có mục list box nào dc chọn");
            hoten.Text = "";
            hoten.Focus();
            loainv.Text = "";
            ngaysinh.Text = DateTime.Now.ToString();
            tienban.Text = "";
            listnv.Items.Remove(listnv.SelectedItem);
        }
    }
}

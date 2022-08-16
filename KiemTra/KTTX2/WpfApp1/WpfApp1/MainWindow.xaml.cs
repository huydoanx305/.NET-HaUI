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

namespace WpfApp1
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

        static List<SinhVien> sinhViens = new List<SinhVien>();

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            String ma = masv.Text.ToString();
            String name = hoten.Text.ToString();
            String khoa = khoatt.Text.ToString();

            if(ma == "" || name == "" || khoa == "")
            {
                MessageBox.Show("Mã, họ tên, khoa/trung tâm của SV không được rỗng!");
                return;
            }

            foreach(SinhVien sv in sinhViens)
            {
                if(sv.maSV.Equals(ma))
                {
                    MessageBox.Show("Mã SV không được trùng nhau!");
                    return;
                }
            }

            int slxs;
            if(!int.TryParse(solanxs.Text, out slxs) || int.Parse(solanxs.Text.ToString()) < 1)
            {
                MessageBox.Show("Số lần xuất sắc phải là kiểu số nguyên và > 0!");
                return;
            }

            SinhVien sinhVien = new SinhVien();
            sinhVien.maSV = ma;
            sinhVien.hoTen = name;
            sinhVien.soLanXS = slxs;
            sinhVien.khoaTT = khoa;

            if(slxs >= 5)
            {
                sinhVien.tienThuong = 500000;
            } else if (slxs > 1 && slxs < 5)
            {
                sinhVien.tienThuong = 200000;
            } else
            {
                sinhVien.tienThuong = 0;
            }

            sinhViens.Add(sinhVien);
            listSV.Items.Add(sinhVien);
        }

        private void Tim_Click(object sender, RoutedEventArgs e)
        {
            listSV.Items.Clear();
            foreach(SinhVien sv in sinhViens)
            {
                if(sv.khoaTT.Equals("1. Khoa Công nghệ thông tin"))
                {
                    listSV.Items.Add(sv);
                }
            }
        }

        private void listSV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listSV.SelectedItem as SinhVien;
            masv.Text = item.maSV;
            hoten.Text = item.hoTen;
            solanxs.Text = item.soLanXS.ToString();
            khoatt.Text = item.khoaTT;
        }
    }
}

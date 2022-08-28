using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using DE01.Models;

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

        QuanLyBenhNhanDBContext db = new QuanLyBenhNhanDBContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showData();
            showKhoa();
        }

        private void showData()
        {
            var query = from bn in db.BenhNhans
                        orderby bn.SoNgayNamVien descending
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            bn.MaKhoa,
                            bn.DiaChi,
                            bn.SoNgayNamVien,
                            VienPhi = bn.vienPhi()
                        };
            listBN.ItemsSource = query.ToList();
                        
        }

        private void showKhoa()
        {
            var query = from k in db.Khoas select k;
            khoa.ItemsSource = query.ToList();
            khoa.DisplayMemberPath = "TenKhoa";
            khoa.SelectedValuePath = "MaKhoa";
            khoa.SelectedIndex = 0;
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            if(mabn.Text == "")
            {
                MessageBox.Show("Mã bệnh nhân không được để trống");
                mabn.Focus();
                return;
            } 
            else if(hoten.Text == "")
            {
                MessageBox.Show("Họ tên không được để trống");
                hoten.Focus();
                return;
            }
            else if (diachi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống");
                diachi.Focus();
                return;
            }
            else if (songaynv.Text == "")
            {
                MessageBox.Show("Số ngày nhập viện không được để trống");
                songaynv.Focus();
                return;
            }

            if (khoa.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn khoa");
                return;
            }

            int maBn;
            if (!int.TryParse(mabn.Text, out maBn))
            {
                MessageBox.Show("Mã bn phải là kiểu số nguyên");
                return;
            }

            int soNgayNamVien;
            if (!int.TryParse(songaynv.Text, out soNgayNamVien))
            {
                MessageBox.Show("Số ngày phải là kiểu số nguyên");
                return;
            }

            if(soNgayNamVien < 1)
            {
                MessageBox.Show("Số ngày phải lớn hơn 0");
                return;
            }

            var benhNhan = db.BenhNhans.SingleOrDefault(b => b.MaBn.Equals(maBn));
            if (benhNhan != null)
                MessageBox.Show("Mã bệnh nhân đã tồn tại");
            else
            {
                BenhNhan bn = new BenhNhan();
                bn.MaBn = maBn;
                bn.HoTen = hoten.Text;
                bn.DiaChi = diachi.Text;
                bn.SoNgayNamVien = soNgayNamVien;
                Khoa k = (Khoa) khoa.SelectedItem;
                bn.MaKhoa = k.MaKhoa;
                db.BenhNhans.Add(bn);
                db.SaveChanges();
                MessageBox.Show("Thêm bênh nhân thành công !");
                showData();

                mabn.Clear();
                hoten.Clear();
                diachi.Clear();
                songaynv.Clear();
                khoa.SelectedIndex = 0;
                mabn.Focus();
            }
        }

        private void Tim_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            var query = from bn in db.BenhNhans
                        where bn.MaKhoa == 1
                        orderby bn.SoNgayNamVien descending
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            bn.MaKhoa,
                            bn.DiaChi,
                            bn.SoNgayNamVien,
                            VienPhi = bn.vienPhi()
                        };
            window1.listBN.ItemsSource = query.ToList();
            window1.Show();
        }

        private void listBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBN.SelectedItem != null)
            {
                try
                {
                    Type t = listBN.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    mabn.Text = p[0].GetValue(listBN.SelectedValue).ToString();
                    hoten.Text = p[1].GetValue(listBN.SelectedValue).ToString();
                    diachi.Text = p[3].GetValue(listBN.SelectedValue).ToString();
                    songaynv.Text = p[4].GetValue(listBN.SelectedValue).ToString();
                    khoa.SelectedValue = p[2].GetValue(listBN.SelectedValue).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn " + ex.Message, "Thông báo");
                }
            }
        }
    }
}

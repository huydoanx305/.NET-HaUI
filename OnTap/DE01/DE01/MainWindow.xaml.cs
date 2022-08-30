using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
                            VienPhi = bn.SoNgayNamVien * 200000
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
            if (checkData())
            {
                var benhNhan = db.BenhNhans.SingleOrDefault(b => b.MaBn.Equals(int.Parse(mabn.Text)));
                if (benhNhan != null)
                    MessageBox.Show("Mã bệnh nhân đã tồn tại");
                else
                {
                
                    BenhNhan bn = new BenhNhan();
                    bn.MaBn = int.Parse(mabn.Text);
                    bn.HoTen = hoten.Text;
                    bn.DiaChi = diachi.Text;
                    bn.SoNgayNamVien = int.Parse(songaynv.Text);
                    Khoa k = (Khoa) khoa.SelectedItem;
                    bn.MaKhoa = k.MaKhoa;

                    db.BenhNhans.Add(bn);
                    db.SaveChanges();

                    MessageBox.Show("Thêm bênh nhân thành công !");
                    mabn.Clear();
                    hoten.Clear();
                    diachi.Clear();
                    songaynv.Clear();
                    khoa.SelectedIndex = 0;
                    mabn.Focus();
                    showData();
                }
            }
        }

        private bool checkData()
        {
            string mess = "";
            if (mabn.Text == "" || hoten.Text == "" || diachi.Text == "" || songaynv.Text == "")
            {
                mess += "\nCác trường không được để trống!";
            } 
            else
            {
                
                int maBn;
                if (!int.TryParse(mabn.Text, out maBn))
                {
                    mess += "\nMã bn phải là kiểu số nguyên!";
                }
                
                int soNgayNamVien;
                if (!int.TryParse(songaynv.Text, out soNgayNamVien))
                {
                    mess += "\nSố ngày phải là số nguyên!";
                }
                else if (soNgayNamVien < 1)
                {
                    mess += "\nSố ngày phải lớn hơn 0!";
                }
            }
            if (!mess.Equals(""))
            {
                MessageBox.Show(mess, "Thong Bao");
                return false;
            }
            return true;
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
                            VienPhi = bn.SoNgayNamVien * 200000
                        };
            window1.listBN.ItemsSource = query.ToList();
            window1.Show();
        }

        private void listBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBN.SelectedItem != null)
            {
                
                Type t = listBN.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                mabn.Text = p[0].GetValue(listBN.SelectedValue).ToString();
                hoten.Text = p[1].GetValue(listBN.SelectedValue).ToString();
                diachi.Text = p[3].GetValue(listBN.SelectedValue).ToString();
                songaynv.Text = p[4].GetValue(listBN.SelectedValue).ToString();
                khoa.SelectedValue = p[2].GetValue(listBN.SelectedValue).ToString();
            }
        }


        // Bonus sửa, xóa, thống kê
        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            var bnChange = db.BenhNhans.SingleOrDefault(b => b.MaBn.Equals(int.Parse(mabn.Text)));
            if(bnChange != null)
            {
                if (checkData())
                {
                    bnChange.MaBn = int.Parse(mabn.Text);
                    bnChange.HoTen = hoten.Text;
                    bnChange.DiaChi = diachi.Text;
                    bnChange.SoNgayNamVien = int.Parse(songaynv.Text);
                    Khoa k = (Khoa)khoa.SelectedItem;
                    bnChange.MaKhoa = k.MaKhoa;

                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                    mabn.Clear();
                    hoten.Clear();
                    diachi.Clear();
                    songaynv.Clear();
                    khoa.SelectedIndex = 0;
                    mabn.Focus();
                    showData();
                }
            }

        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            var bnDelete = db.BenhNhans.SingleOrDefault(b => b.MaBn.Equals(int.Parse(mabn.Text)));
            if(bnDelete != null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thong Bao", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    db.BenhNhans.Remove(bnDelete);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    mabn.Clear();
                    hoten.Clear();
                    diachi.Clear();
                    songaynv.Clear();
                    khoa.SelectedIndex = 0;
                    mabn.Focus();
                    showData();
                }
            }
        }

        // Thống kê: Hiển thị thông tin các bệnh nhân có Mã khoa = 2 lên dataGrid trên cửa sổ mới, 
        // bao gồm các cột: Mã bệnh nhân, họ tên, địa chỉ, tên khoa, số ngày nằm viện, viện phí.
        private void ThongKe_Click(object sender, RoutedEventArgs e)
        {
            var query = from bn in db.BenhNhans
                        join k in db.Khoas
                        on bn.MaKhoa equals k.MaKhoa
                        where k.MaKhoa == 2
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            bn.DiaChi,
                            k.TenKhoa,
                            bn.SoNgayNamVien,
                            VienPhi = bn.SoNgayNamVien * 200000
                        };
            WindowTK windowTK = new WindowTK();
            windowTK.listBN.ItemsSource = query.ToList();

            // Thống kê số con vợ nằm viện của từng khoa
            var queryCount = from bn in db.BenhNhans
                             join k in db.Khoas
                             on bn.MaKhoa equals k.MaKhoa
                             group k by new { k.MaKhoa, k.TenKhoa} into result
                             select new
                             {
                                 MaKhoa = result.Key.MaKhoa,
                                 TenKhoa = result.Key.TenKhoa,
                                 SoNguoi = result.Count()
                             };
            // group by nhiều phần tử thì thêm new và {...phần tử}
            // 1 phần tử thì (group k by k.MaKhoa into result) (MaKhoa = result.Key)
            windowTK.listTK.ItemsSource = queryCount.ToList();

            windowTK.Show();
        }
    }
}

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
using DE02.Models;

namespace DE02
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

        QuanLySanPhamDBContext db = new QuanLySanPhamDBContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showData();
            showNhomHang();
        }

        private void showData()
        {
            var query = from sp in db.SanPhams
                        orderby sp.SoLuongBan descending
                        select new
                        {
                            sp.MaSp,
                            sp.TenSanPham,
                            sp.DonGia,
                            sp.SoLuongBan,
                            sp.MaNhomHang,
                            TienBan = sp.tienBan()
                        };
            listSP.ItemsSource = query.ToList();
        }

        private void showNhomHang()
        {
            var query = from nh in db.NhomHangs select nh;
            nhomhang.ItemsSource = query.ToList();
            nhomhang.SelectedValuePath = "MaNhomHang";
            nhomhang.DisplayMemberPath = "TenNhomHang";
            nhomhang.SelectedIndex = 0;
        }

        private bool checkData()
        {
            String mess = "";
            if(masp.Text == "" || tensp.Text == "" || dongia.Text == "" || soluongban.Text == "")
            {
                mess += "Các ô không được để trống!";
            } 
            else
            {
                int maSP;
                if(!Regex.IsMatch(masp.Text, @"\d+"))
                {
                    mess += "\nMã sản phẩm phải là số!";
                } else
                {
                    if (!int.TryParse(masp.Text, out maSP))
                    {
                        mess += "\nMã sản phẩm phải là số nguyên!";
                    }
                }

                if (!Regex.IsMatch(dongia.Text, @"\d+"))
                {
                    mess += "\nĐơn giá phải là số!";
                } else
                {
                    if(double.Parse(dongia.Text) <= 0)
                    {
                        mess += "\nĐơn giá phải > 0!";
                    }
                }

                if (!Regex.IsMatch(soluongban.Text, @"\d+"))
                {
                    mess += "\nSố lượng bán phải là số!";
                } else
                {
                    int soLuongBan;
                    if(!int.TryParse(soluongban.Text, out soLuongBan))
                    {
                        mess += "\nSố lượng bán phải là số nguyên!";
                    }
                    if (soLuongBan < 1)
                    {
                        mess += "\nSố lượng bán phải lớn hơn 0!";
                    }
                }
            }

            if (!mess.Equals(""))
            {
                MessageBox.Show(mess, "Thông báo");
                return false;
            }
            return false;
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            if(checkData())
            {
                var sp = db.SanPhams.SingleOrDefault(s => s.MaSp.Equals(int.Parse(masp.Text)));
                if(sp == null)
                {
                    SanPham sanPham = new SanPham();
                    sanPham.MaSp = int.Parse(masp.Text);
                    sanPham.TenSanPham = tensp.Text;
                    sanPham.DonGia = double.Parse(dongia.Text);
                    sanPham.SoLuongBan = double.Parse(soluongban.Text);
                    NhomHang nhomHang = (NhomHang)nhomhang.SelectedItem;
                    sanPham.MaNhomHang = nhomHang.MaNhomHang;
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                    masp.Clear();
                    tensp.Clear();
                    dongia.Clear();
                    soluongban.Clear();
                    nhomhang.SelectedIndex = 0;
                    masp.Focus();
                    showData();
                } else
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!");
                    return;
                }
            }
        }
        private void listSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listSP.SelectedItem != null)
            {
                Type t = listSP.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                masp.Text = p[0].GetValue(listSP.SelectedValue).ToString();
                tensp.Text = p[1].GetValue(listSP.SelectedValue).ToString();
                dongia.Text = p[2].GetValue(listSP.SelectedValue).ToString();
                soluongban.Text = p[3].GetValue(listSP.SelectedValue).ToString();
                nhomhang.SelectedValue = p[4].GetValue(listSP.SelectedValue).ToString();
            }
        }

        private void Tim_Click(object sender, RoutedEventArgs e)
        {
            var query = from sp in db.SanPhams
                        where sp.MaNhomHang == 1
                        select new
                        {
                            sp.MaSp,
                            sp.TenSanPham,
                            sp.DonGia,
                            sp.SoLuongBan,
                            sp.MaNhomHang,
                            TienBan = sp.tienBan()
                        };
            Window1 window1 = new Window1();
            window1.listSP.ItemsSource = query.ToList();
            window1.Show();
        }

    //Bonus sửa, xóa
        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            var spUpdate = db.SanPhams.SingleOrDefault(sp => sp.MaSp.Equals(int.Parse(masp.Text)));
            if(spUpdate != null)
            {
                spUpdate.MaSp = int.Parse(masp.Text);
                spUpdate.TenSanPham = tensp.Text;
                spUpdate.DonGia = double.Parse(dongia.Text);
                spUpdate.SoLuongBan = double.Parse(soluongban.Text);
                NhomHang nhomHang = (NhomHang)nhomhang.SelectedItem;
                spUpdate.MaNhomHang = nhomHang.MaNhomHang;
                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                masp.Clear();
                tensp.Clear();
                dongia.Clear();
                soluongban.Clear();
                nhomhang.SelectedIndex = 0;
                masp.Focus();
                showData();
            }
        }
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            var spDelete = db.SanPhams.SingleOrDefault(sp => sp.MaSp.Equals(int.Parse(masp.Text)));
            if(spDelete != null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    db.SanPhams.Remove(spDelete);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    masp.Clear();
                    tensp.Clear();
                    dongia.Clear();
                    soluongban.Clear();
                    nhomhang.SelectedIndex = 0;
                    masp.Focus();
                    showData();
                }
            }
        }
        
    }
}

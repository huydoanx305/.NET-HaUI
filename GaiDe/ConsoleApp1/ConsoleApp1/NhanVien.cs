using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class NhanVien : Nguoi, IComparable
    {
        private int maNV;
        private String chucVu;
        private int luongCoBan;

        static int ID = 1000;
        public NhanVien() : base()
        {
            maNV = ID++;
        }

        public NhanVien(String hoTen, String diaChi, int maNV, String chucVu, int luongCoBan) : base(hoTen, diaChi)
        {
            maNV = ID++;
            this.maNV = maNV;
            this.chucVu = chucVu;
            this.luongCoBan = luongCoBan;
        }

        public int getMaNV()
        {
            return this.maNV;
        }

        public void setChucVu(String chucVu)
        {
            this.chucVu = chucVu;
        }

        public String getChucVu()
        {
            return this.chucVu;
        }

        public void setLuongCoBan(int luongCoBan)
        {
            this.luongCoBan = luongCoBan;
        }

        public int getLuongCoBan()
        {
            return this.luongCoBan;
        }

        public override void inputNguoi()
        {
            base.inputNguoi();
            Console.Write("Nhập chức vụ: ");
            chucVu = Console.ReadLine();
            Console.Write("Nhập lương cơ bản: ");
            luongCoBan = int.Parse(Console.ReadLine());
        }

        public override void output()
        {
            string str = String.Format("{0, -10}", maNV);
            Console.Write(str);
            base.output();
            string str1 = String.Format("{0, -25}{1, -25}{2, -25}", chucVu, luongCoBan, heSoChucVu());
            Console.WriteLine(str1);
        }

        public int heSoChucVu()
        {
            if (chucVu.Equals("Giam Doc"))
                return 10;
            else if (chucVu.Equals("Truong Phong") || chucVu.Equals("Pho Giam Doc"))
                return 6;
            else if (chucVu.Equals("Pho Phong"))
                return 4;
            else
                return 2;
        }

        public int CompareTo(object obj)
        {
            NhanVien nhanVien = (NhanVien)obj;
            if (heSoChucVu() > nhanVien.heSoChucVu())
                return 1;
            else if (heSoChucVu() < nhanVien.heSoChucVu())
                return -1;
            else
            {
                if (luongCoBan - nhanVien.getLuongCoBan() > 0)
                    return 1;
                else if (luongCoBan - nhanVien.getLuongCoBan() < 0)
                    return -1;
                else
                    return 0;
            }
        }
    }
}

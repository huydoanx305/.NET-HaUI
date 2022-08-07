using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Nguoi
    {
        private String hoTen;
        private String diaChi;
        
        public Nguoi() { }
            
        public Nguoi(String hoTen, String diaChi)
        {
            this.hoTen = hoTen;
            this.diaChi = diaChi;
        }

        public void setHoTen(String hoTen)
        {
            this.hoTen = hoTen;
        }

        public String getHoTen()
        {
            return this.hoTen;
        }

        public void setDiaChi(String diaChi)
        {
            this.diaChi = diaChi;
        }

        public String getDiaChi()
        {
            return this.diaChi;
        }

        public virtual void inputNguoi()
        {
            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            diaChi = Console.ReadLine();
        }

        public virtual void output()
        {
            string str = String.Format("{0, -25}{1, -25}", hoTen, diaChi);
            Console.Write(str);
        }
    }
}

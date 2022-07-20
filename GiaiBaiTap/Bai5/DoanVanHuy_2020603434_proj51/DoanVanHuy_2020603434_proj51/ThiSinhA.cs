using System;
using System.Collections.Generic;
using System.Text;

namespace DoanVanHuy_2020603434_proj51
{
    class ThiSinhA
    {
        public int soBaoDanh { get; set; }

        public String hoTen { get; set; }

        public String diaChi { get; set; }

        public double toan { get; set; }

        public double ly { get; set; }

        public double hoa { get; set; }

        public double diemUuTien { get; set; }


        public static int ID = 1000;
        public ThiSinhA()
        {
            soBaoDanh = ID++;
        }


        public void nhapThiSinh()
        {
            Console.Write("Nhập họ tên thí sinh: ");
            hoTen = Convert.ToString(Console.ReadLine());
            
            Console.Write("Nhập địa chỉ: ");
            diaChi = Convert.ToString(Console.ReadLine());
            
            Console.Write("Nhập điểm toán: ");
            toan = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Nhập điểm lý: ");
            ly = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Nhập điểm hóa: ");
            hoa = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Nhập điểm ưu tiên: ");
            diemUuTien = Convert.ToDouble(Console.ReadLine());
        }

        public double tongdiem()
        {
            return Math.Round(toan + ly + hoa + diemUuTien, 3);
        }

    }
}

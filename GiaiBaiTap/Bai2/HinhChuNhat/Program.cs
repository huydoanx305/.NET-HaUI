using System;

namespace HinhChuNhat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            double chieuDai, chieuRong;

            Console.Write("Nhập chiều dài hcn: ");
            chieuDai = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập chiều rộng hcn: ");
            chieuRong = Convert.ToDouble(Console.ReadLine());

            double chuVi, dienTich;
            chuVi = (chieuDai + chieuRong) * 2;

            dienTich = (chieuDai * chieuRong);

            Console.WriteLine("Chu vi hình chữ nhật = " + chuVi);
            Console.WriteLine("Diện tích hình chữ nhật = " + dienTich);
        }
    }
}

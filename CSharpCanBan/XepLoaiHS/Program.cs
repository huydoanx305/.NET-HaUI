using System;

namespace XepLoaiHS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            String hoTen;
            double diemThi;

            Console.Write("Nhập họ tên học sinh: ");
            hoTen = Convert.ToString(Console.ReadLine());

            Console.Write("Nhập điểm thi cuối kỳ: ");
            do
            {
                diemThi = Convert.ToDouble(Console.ReadLine());
                if (diemThi < 0 || diemThi > 10)
                    Console.Write("Điểm không hợp lệ! Nhập lại: ");
            } while (diemThi < 0 || diemThi > 10);

            Console.WriteLine("\t=== Thông tin học sinh ===");
            Console.WriteLine("Họ tên: " + hoTen.ToUpper());
           
            if(diemThi >= 8) 
                Console.WriteLine("Xếp loại: Giỏi");
            else if(diemThi >= 6)
                Console.WriteLine("Xếp loại: Khá");
            else if(diemThi >= 5)
                Console.WriteLine("Xếp loại: Trung Bình");
            else
                Console.WriteLine("Xếp loại: Yếu");
        }
    }
}

using System;
using System.Text;

namespace NhapLieu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int n = 0;
            Console.WriteLine("\t\tWhile");
            Console.Write("(0 < n <= 100) Nhap n = ");
            while (n < 1 || n > 100)
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 1 || n > 100)
                    Console.Write("Không hợp lệ! Nhập lại = ");
            }

            Console.WriteLine("\t\tDo-While");
            Console.Write("(0 < n <= 100) Nhap n = ");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 1 || n > 100)
                    Console.Write("Không hợp lệ! Nhập lại = ");
            } while (n < 1 || n > 100);
        }
    }
}

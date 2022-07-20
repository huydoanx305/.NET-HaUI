using System;
using System.Text;

namespace TinhToan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhập số thực a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập số thực b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập phép tính: ");
            string phepTinh = Console.ReadLine();
            tinhToan(a, b, phepTinh);
        }

        static void tinhToan(double a, double b, string pt)
        {
            switch (pt)
            {
                case "+":
                    Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
                    break;
                case "-":
                    Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
                    break;
                case "*":
                    Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
                    break;
                case "/":
                    Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
                    break;
                default:
                    Console.WriteLine("Phép tính không hợp lệ.");
                    break;
            }
        }
    }
}

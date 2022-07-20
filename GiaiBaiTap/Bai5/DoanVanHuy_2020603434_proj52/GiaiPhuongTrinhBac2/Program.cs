using System;
using System.Text;

namespace GiaiPhuongTrinhBac2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Write("Nhập a: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập c: ");
            int c = Convert.ToInt32(Console.ReadLine());

            GiaiPhuongTrinhBac2 pt = new GiaiPhuongTrinhBac2(a, b, c);
        }
    }
}

using System;

namespace CanBacHai
{
    class Program
    {
        static double a;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Nhap so a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Can bac hai cua so {0} la: {1}", a, canBac2(a));
        }

        static double canBac2(double n)
        {
            if (n == 0)
                return 1;
            else 
                return (a / canBac2(n - 1) + canBac2(n - 1)) / 2;
        }

    }
}

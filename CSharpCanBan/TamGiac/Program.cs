using System;

namespace TamGiac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            double a, b, c;

            Console.Write("Nhập cạnh a: ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập cạnh b: ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập cạnh c: ");
            c = Convert.ToDouble(Console.ReadLine());

            if (a >= b + c || b >= a + c || c >= a + b)
                Console.WriteLine("Ba cạnh vừa nhập không phải là cạnh của tam giác!");
            else
                Console.WriteLine("Diện tích tam giác = " + dienTich(a, b, c));
        }

        static double chuVi(double a, double b, double c)
        {
            return a + b + c;
        }

        static double dienTich(double a, double b, double c)
        {
            double nuaChuVi = chuVi(a, b, c) / 2.0;
            return Math.Sqrt(nuaChuVi * (nuaChuVi - a) * (nuaChuVi - b) * (nuaChuVi - c));
        }
    }
}

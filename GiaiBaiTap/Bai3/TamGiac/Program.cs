using System;

namespace TamGiac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            double a, b, c;
            Console.WriteLine("Nhập độ dài 3 cạnh của tam giác.");
            a = Convert.ToDouble(Console.ReadLine());
            b = System.Double.Parse(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());

            if (a > 0 && b > 0 && c > 0
                && a + b > c && c + c > b && b + c > a)
            {
                double cv = a + b + c;
                double p = cv / 2;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                Console.WriteLine(cv);
                Console.WriteLine(s);
            }
            else
            {
                Console.WriteLine("Không phải là tam giác.");
            }
        }
    }
}

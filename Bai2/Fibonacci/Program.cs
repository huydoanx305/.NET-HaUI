using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int n;
            Console.Write("Nhập số nguyên n = ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
                Console.WriteLine(fibonacci(i));
        }

        static int fibonacci(int n)
        {
            if (n < 0)
                return -1;
            else if (n == 0 || n == 1)
                return n;
            else
                return fibonacci(n - 1) + fibonacci(n - 2);
        }
    }
}

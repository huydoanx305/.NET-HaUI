using System;

namespace GiaiThua
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int n;
            Console.Write("Nhập số nguyên n = ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Giai thừa" + giaiThua(n));
        }

        static int giaiThua(int n)
        {
            if (n <= 0)
                return -1;
            else
            {
                if (n == 1)
                    return 1;
                else
                    return n * giaiThua(n - 1);
            }
        }
    }
}

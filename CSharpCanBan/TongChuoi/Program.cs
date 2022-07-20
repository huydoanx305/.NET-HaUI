using System;

namespace TongChuoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int n;

            Console.Write("Nhập n = ");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                    Console.Write("n không hợp lệ! Nhập lại n = ");
            } while (n <= 0);
            // a) S = 1 + 2 + 3 + ... + n
            Console.WriteLine("Câu a) S = " + tongA(n));

            // b) S = 1 + 1 / 2 + 1 / 3 + ... + 1 / n
            Console.WriteLine("Câu b) S = " + tongB(n));
        }

        static public int tongA(int n)
        {
            if (n == 1)
                return 1;
            return tongA(n - 1) + n;
        }

        static public double tongB(int n)
        {
            if (n == 1)
                return 1;
            return tongB(n - 1) + 1.0 / n;
        }

    }
}

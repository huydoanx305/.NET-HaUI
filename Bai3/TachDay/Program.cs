using System;
using System.Collections.Generic;

namespace TachDay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            List<int> list = new List<int>();

            Console.Write("Nhập n = ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("a[" + i + "] = ");
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }

            list.FindAll(elem => elem % 2 == 0).ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            list.FindAll(elem => elem % 2 != 0).ForEach(e => Console.Write(e + " "));
        }
    }
}

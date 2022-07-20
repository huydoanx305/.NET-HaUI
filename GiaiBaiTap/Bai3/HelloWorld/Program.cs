using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.Write("a = ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("b = ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} + {1} = {2}" ,a ,b , a + b);
        }
    }
}

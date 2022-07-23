using System;

namespace TimUSCLN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.Write("Số lượng đối tượng: ");
            int n = Convert.ToInt32(Console.ReadLine());

            TimUSCLN[] array = new TimUSCLN[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new TimUSCLN();
                Console.WriteLine("Nhập đối tượng " + (i + 1));
                array[i].Nhap();
            }

            Console.WriteLine($"{"Số thứ 1",25} {"Số thứ 2",20} {"Uơc chung lớn nhất",20}");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{"Đối tượng thứ " + (i + 1),5}");
                array[i].Xuat();
            }
        }
    }
}

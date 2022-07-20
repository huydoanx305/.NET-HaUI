using System;
using System.Collections.Generic;

namespace HeCoSo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Nhap co so 10: ");
            int n = Convert.ToInt16(Console.ReadLine());

            Console.Write("Nhap co so muon chuyen sang: ");
            int b = Convert.ToInt16(Console.ReadLine());

            if (n < 0 || b < 2 || b > 16)
            {
                Console.Write("He co so hoac gia tri chuyen doi khong hop le!");
            }
            char[] arr = new char[50];
            int count = 0;
            int m;
            int remainder = n;
            while (remainder > 0)
            {
                if (b > 10)
                {
                    m = remainder % b;
                    if (m >= 10)
                    {
                        arr[count] = (char)(m + 55);
                        count++;
                    }
                    else
                    {
                        arr[count] = (char)(m + 48);
                        count++;
                    }
                }
                else
                {
                    arr[count] = (char)((remainder % b) + 48);
                    count++;
                }
                remainder = remainder / b;
            }
            // hien thi he co so
            for (int i = count - 1; i >= 0; i--)
            {
                Console.Write(arr[i]);
            }

        }
    }
}

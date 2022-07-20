using System;
using System.Collections;
using System.Collections.Generic;

namespace DanhSach
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

            Console.Write("\nCác số chẵn: ");
            showChanLeNgTo(list, "chan").ForEach(elem => Console.Write(elem + " "));

            Console.Write("\nCác số lẽ: ");
            showChanLeNgTo(list, "le").ForEach(elem => Console.Write(elem + " "));

            Console.Write("\nCác số nguyên tố: ");
            showChanLeNgTo(list, "nguyento").ForEach(elem => Console.Write(elem + " "));

        }
        static List<int> showChanLeNgTo(List<int> oldList, String key)
        {
            List<int> newList = new List<int>();
            foreach (int elem in oldList)
            {
                if (soNguyenTo(elem) == true && key == "nguyento")
                    newList.Add(elem);
                else
                {
                    if (checkCL(elem) == true && key == "chan")
                        newList.Add(elem);
                    else if (checkCL(elem) == false && key == "le")
                        newList.Add(elem);
                }
            }
            return newList;
        }

        static Boolean checkCL(int n)
        {
            if (n % 2 == 0)
                return true;
            return false;
        }

        static Boolean soNguyenTo(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TimUSCLN
{
    class TimUSCLN
    {
        public int sothu1 { get; set; }
        public int sothu2 { get; set; }

        public TimUSCLN()
        {

        }

        public TimUSCLN(int sothu1, int sothu2)
        {
            this.sothu1 = sothu1;
            this.sothu2 = sothu2;
        }

        public void Nhap()
        {
            Console.Write("Số thứ 1: ");
            sothu1 = int.Parse(Console.ReadLine());
            Console.Write("Số thứ 2: ");
            sothu2 = int.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine($"{sothu1,10} {sothu2,20} {USCLN(),20}");
        }

        public int USCLN()
        {
            if (sothu1 == 0 || sothu2 == 0)
                return sothu1 + sothu2;
            while (sothu1 != sothu2)
            {
                if (sothu1 > sothu2)
                {
                    sothu1 -= sothu2;
                }
                else
                {
                    sothu2 -= sothu1;
                }
            }
            return sothu1;
        }
    }
}

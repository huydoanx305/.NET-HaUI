using System;
using System.Collections.Generic;
using System.Text;

namespace GiaiPhuongTrinhBac2
{
    class GiaiPhuongTrinhBac2
    {
        public int a { get; set; }

        public int b { get; set; }

        public int c { get; set; }

        public GiaiPhuongTrinhBac2() {}

        public GiaiPhuongTrinhBac2(int a1, int b1, int c1)
        {
            a = a1;
            b = b1;
            c = c1;

            if(a == 0)
            {
                // a == 0 => phương trình bậc 1 bx + c = 0
                if(b == 0)
                {
                    if(c == 0)
                    {
                        Console.WriteLine("Phương tình vô số nghiệm");
                    }
                    else
                    {
                        Console.WriteLine("Phương trình vô nghiệm");
                    } 
                } 
                else
                {
                    Console.WriteLine("Phương trình có nghiệm duy nhất: {0}", -c / (b * 1.0));
                }
            } else
            {
                double delta = b * b - 4 * a * c;
                if(delta > 0)
                {
                    double x1 = Math.Round((-b + Math.Sqrt(delta)) / (2 * a), 3);
                    double x2 = Math.Round((-b - Math.Sqrt(delta)) / (2 * a), 3); ;
                    Console.WriteLine("Phương trình có 2 nghiệm: x1 = {0}, x2 = {1}", x1, x2);
                }
                else if(delta == 0)
                {
                    Console.WriteLine("Phương trình có nghiệm kép: x1 = x2 = {0}", -b / (2.0 * a));
                }
                else
                {
                    Console.WriteLine("Phương trình vô nghiệm");
                }
            }
        }

    }
}

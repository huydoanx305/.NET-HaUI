using System;
using System.Collections.Generic;
using System.Text;

namespace DoanVanHuy_2020603434_proj52
{
    class Employee
    {
        public String id { get; set; }

        public String name { get; set; }

        public int age { get; set; }

        public int workingdays { get; set; }

        private const int PRICE = 50;
        public double getSalary()
        {
            return workingdays * PRICE;
        }

        public void input()
        {
            Console.Write("Nhập Id nhân viên: ");
            id = Convert.ToString(Console.ReadLine());

            Console.Write("Nhập tên nhân viên: ");
            name = Convert.ToString(Console.ReadLine());

            Console.Write("Nhập tuổi: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập số ngày làm việc: ");
            workingdays = Convert.ToInt32(Console.ReadLine());
        }

        public void output()
        {
            Console.WriteLine($"{id,5} {name,25} {age,15} {workingdays,15} {getSalary(),15}");
        }
    }
}

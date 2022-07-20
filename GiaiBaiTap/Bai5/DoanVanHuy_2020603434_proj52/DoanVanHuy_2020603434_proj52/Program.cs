using System;
using System.Text;

namespace DoanVanHuy_2020603434_proj52
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Employee employee = new Employee();
            employee.input();
            Console.WriteLine($"{"Id",5} {"Họ Tên",25} {"Tuổi",15} {"Số ngày làm",15} {"Lương",15}");
            employee.output();
        }
    }
}

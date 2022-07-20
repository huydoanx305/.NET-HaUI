using System;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Person person = new Person("Doãn Văn Huy", 20, "huydoanx305", "Thanh Hóa");
            //person.input();
            Console.WriteLine($"{"Id",5} {"Name",15} {"Age",15} {"Email",15} {"Address",15}");
            person.output();
        }
    }
}

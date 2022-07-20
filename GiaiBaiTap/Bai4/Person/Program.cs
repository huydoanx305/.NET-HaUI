using System;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Person person = new Person("Doan Van Huy", 20, "huycntt", "thanh hoa");
            Person person2 = new Person("Doan Van Huy", 20, "huycntt", "thanh hoa");
            Person person3 = new Person("Doan Van Huy", 20, "huycntt", "thanh hoa");
            //person.input();
            Console.WriteLine($"{"Id",5} {"Name",10} {"Age",10} {"Email",10} {"Address",10}");
            Console.WriteLine($"{person.id,5} {person.name,10} {person.age,10} {person.email,10} {person.address,10}");
            Console.WriteLine(person.id);
            Console.WriteLine(person2.id);
            Console.WriteLine(person3.id);
        }
    }
}

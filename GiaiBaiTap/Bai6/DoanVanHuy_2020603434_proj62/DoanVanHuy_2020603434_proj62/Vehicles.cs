using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DoanVanHuy_2020603434_proj62
{
    class Vehicle : IVehicle, IComparable<Vehicle>
    {
        public String id { get; set; }
        public String maker { get; set; }
        public String model { get; set; }
        public int year { get; set; }
        public double price { get; set; }


        public Vehicle() { }

        public Vehicle(String id)
        {
            this.id = id;
        }
        public Vehicle(String id, String maker, String model, int year, double price)
        {
            this.id = id;
            this.maker = maker;
            this.model = model;
            this.year = year;
            this.price = price;
        }

        public virtual void Input()
        {
            Console.Write("Enter Id: ");
            id = Console.ReadLine();
            Console.Write("Enter maker: ");
            maker = Console.ReadLine();
            Console.Write("Enter model: ");
            model = Console.ReadLine();
            Console.Write("Enter price: ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Enter year: ");
            year = int.Parse(Console.ReadLine());
        }

        public virtual void Output()
        {
            Console.Write($"{id,10} {maker,15} {model,15} {year,15} {price,15}");
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicle = (Vehicle)obj;
            return this.id.Equals(vehicle.id);
        }

        public override string ToString()
        {
            var str = String.Format($"{id,10} {maker,15} {model,15} {year,15} {price,15}");
            return str;
        }

        public int CompareTo(Vehicle other)
        {
            if (this.price == other.price)
            {
                if (year > other.year)
                    return 1;
                if (year < other.year)
                    return -1;
                return 0;
            }
            return this.price.CompareTo(other.price);
        }
    }
}

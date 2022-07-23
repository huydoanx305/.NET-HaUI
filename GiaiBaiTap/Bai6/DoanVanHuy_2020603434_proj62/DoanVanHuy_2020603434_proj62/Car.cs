using System;
using System.Collections.Generic;
using System.Text;

namespace DoanVanHuy_2020603434_proj62
{
    class Car : Vehicle
    {
        public String color { get; set; }

        public Car():base() { }

        public Car(String id, String maker, String model, int year, double price, String color)
            :base(id, maker, model, year, price)
        {
            this.color = color;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Enter color: ");
            color = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.Write($"{color,15} \n");
        }

    }
}

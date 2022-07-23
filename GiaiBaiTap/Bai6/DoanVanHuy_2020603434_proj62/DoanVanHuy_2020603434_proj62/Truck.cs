using System;
using System.Collections.Generic;
using System.Text;

namespace DoanVanHuy_2020603434_proj62
{
    class Truck : Vehicle
    {
        public int truckload { get; set; }

        public Truck():base() { }

        public Truck(String id, String maker, String model, int year, double price, int truckload)
            :base(id, maker, model, year, price)
        {
            this.truckload = truckload;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Enter truckload: ");
            truckload = int.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            base.Output();
            Console.Write($"{truckload,30} \n");
        }

    }
}

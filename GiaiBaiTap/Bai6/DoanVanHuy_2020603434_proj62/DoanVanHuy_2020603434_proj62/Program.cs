using System;
using System.Collections.Generic;

namespace DoanVanHuy_2020603434_proj62
{
    class Program
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        static int choose()
        {
            int choose;
            do
            {
                try
                {
                    choose = int.Parse(Console.ReadLine());
                    return choose;
                } catch (Exception e)
                {
                    Console.Write("Dữ liệu không hợp lệ! Nhập lại: ");
                }
            } while (true);
            
        }

        static void inputCar()
        {
            Car[] cars = new Car[1];
            foreach(Car elem in cars)
            {
                Car car = new Car();
                car.Input();
                vehicles.Add(car);
                Console.WriteLine("----------------------");
            }
        }
        static void inputTruck()
        {
            Truck[] trucks = new Truck[1];
            foreach (Truck elem in trucks)
            {
                Truck truck = new Truck();
                truck.Input();
                vehicles.Add(truck);
                Console.WriteLine("----------------------");
            }
        }

        static void title()
        {
            Console.WriteLine($"{"Id",10} {"Maker",15} {"Model",15} {"Year",15} {"Price",15} {"color",15} {"truckload",15}");
        }
        static void show()
        {
            title();
            vehicles.ForEach(elem => elem.Output());
        }

        static List<Vehicle> searchByKey(String key, String id, String maker)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            foreach (var elem in vehicles)
            {
                if(key.Equals("id") && elem.id.Equals(id))
                {
                    listVehicle.Add(elem);
                } 
                else if(key.Equals("maker") && elem.maker.Equals(maker))
                {
                    listVehicle.Add(elem);
                }
            }
            return listVehicle;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            do
            {
                Console.WriteLine("============Menu============");
                Console.WriteLine("1. Nhập dữ liệu");
                Console.WriteLine("2. Hiển thị dữ liệu");
                Console.WriteLine("3. Tìm kiếm theo Id");
                Console.WriteLine("4. Tìm kiếm theo maker");
                Console.WriteLine("5. Sắp xếp theo price");
                Console.WriteLine("6. Sắp xếp theo năm sx");
                Console.WriteLine("7. Kết thúc");
                Console.Write("Nhập chức năng cần dùng: ");

                switch (choose())
                {
                    case 1:
                        Console.WriteLine("Nhập thông tin 3 đối tượng car: ");
                        inputCar();
                        Console.WriteLine("Nhập thông tin 3 đối tượng truck: ");
                        inputTruck();
                        break;
                    case 2:
                        show();
                        break;
                    case 3:
                        Console.Write("Nhập id cần tìm kiếm: ");
                        String id = Console.ReadLine();

                        if (searchByKey("id", id, null).Count > 0)
                        {
                            title();
                            searchByKey("id", id, null).ForEach(elem => elem.Output());
                        } else
                        {
                            Console.WriteLine("Không tồn tại id: {0} trong danh sách", id);
                        }
                        break;
                    case 4:
                        Console.Write("Nhập maker cần tìm kiếm: ");
                        String maker = Console.ReadLine();

                        if (searchByKey("maker", null, maker).Count > 0)
                        {
                            title();
                            searchByKey("maker", null, maker).ForEach(elem => elem.Output());
                        }
                        else
                        {
                            Console.WriteLine("Không tồn tại maker: {0} trong danh sách", maker);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Danh sách trước khi sắp xếp theo price");
                        title();
                        vehicles.ForEach(elem => elem.Output());

                        Console.WriteLine("Danh sách sau khi sắp xếp tăng dần theo price");
                        vehicles.Sort((o1, o2) => {
                            if (o1.price > o2.price)
                                return 1;
                            if (o1.price < o2.price)
                                return -1;
                            return 0;
                        });
                        title();
                        vehicles.ForEach(elem => elem.Output());
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }

            } while (true);
        }
    }
}

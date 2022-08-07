using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static List<NhanVien> list = new List<NhanVien>();

        static int choose()
        {
            int choose;
            do
            {
                try
                {
                    choose = int.Parse(Console.ReadLine());
                    return choose;
                }
                catch (Exception e)
                {
                    Console.Write("Dữ liệu không hợp lệ! Nhập lại: ");
                }
            } while (true);

        }

        static void title()
        {
            string str = String.Format("{0, -10}{1, -25}{2, -25}{3, -25}{4, -25}{5, -25}", "Mã NV", "Họ tên", "Địa Chỉ", "Chức vụ", "Lương CB", "Hệ Số CV");
            Console.WriteLine(str);
        }


        static void input()
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.inputNguoi();
            list.Add(nhanVien);
        }

        static void output()
        {
            title();
            list.ForEach(elem => elem.output());
        }

        static List<NhanVien> searchByKey(String key, int id, String diaChi)
        {
            List<NhanVien> newList = new List<NhanVien>();
            foreach (var elem in list)
            {
                if (key.Equals("id") && elem.getMaNV() == id)
                {
                    newList.Add(elem);
                }
                else if (key.Equals("diachi") && elem.getDiaChi().Equals(diaChi))
                {
                    newList.Add(elem);
                }
            }
            return newList;
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
                Console.WriteLine("4. Tìm kiếm theo diachi");
                Console.WriteLine("5. Sắp xếp theo hệ số");
                Console.WriteLine("7. Kết thúc");
                Console.Write("Nhập chức năng cần dùng: ");

                switch (choose())
                {
                    case 1:
                        input();
                        break;
                    case 2:
                        output();
                        break;
                    case 3:
                        Console.Write("Nhập id cần tìm kiếm: ");
                        int id = int.Parse(Console.ReadLine());

                        if (searchByKey("id", id, null).Count > 0)
                        {
                            title();
                            searchByKey("id", id, null).ForEach(elem => elem.output());
                        }
                        else
                        {
                            Console.WriteLine("Không tồn tại id: {0} trong danh sách", id);
                        }
                        break;
                    case 4:
                        Console.Write("Nhập địa chỉ cần tìm kiếm: ");
                        String diaChi = Console.ReadLine();

                        if (searchByKey("maker", 0, diaChi).Count > 0)
                        {
                            title();
                            searchByKey("maker", 0, diaChi).ForEach(elem => elem.output());
                        }
                        else
                        {
                            Console.WriteLine("Không tồn tại diachi: {0} trong danh sách", diaChi);
                        }
                        break;
                    case 5:
                        /*Console.WriteLine("\t\tDanh sách trước khi sắp xếp theo price");
                        title();
                        list.ForEach(elem => elem.output());

                        Console.WriteLine("\t\tDanh sách sau khi sắp xếp tăng dần theo price");
                        list.Sort((o1, o2) => {
                            if (o1.getLuongCoBan() > o2.getLuongCoBan())
                                return 1;
                            if (o1.getLuongCoBan() < o2.getLuongCoBan())
                                return -1;
                            return 0;
                        });
                        title();*/
                        list.Sort();
                        list.ForEach(elem => elem.output());
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

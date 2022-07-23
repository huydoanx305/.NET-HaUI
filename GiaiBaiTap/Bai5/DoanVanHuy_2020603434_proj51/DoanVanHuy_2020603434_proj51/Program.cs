using System;
using System.Collections.Generic;
using System.Text;

namespace DoanVanHuy_2020603434_proj51
{
    class Program
    {
        static List<ThiSinhA> thiSinhs = new List<ThiSinhA>();
        public static void title()
        {
            Console.WriteLine($"{"SBD",5} {"Họ tên",25} {"Địa chỉ",15} {"Điểm toán",15} {"Điểm lý",15} {"Điểm hóa",15} {"Điểm ưu tiên",15} {"Tổng điểm",15}");
        }

        public static void addThiSinh()
        {
            ThiSinhA thiSinh = new ThiSinhA();
            thiSinh.nhapThiSinh();
            thiSinhs.Add(thiSinh);
        }

        public static void show()
        {
            title();
            thiSinhs.ForEach(elem => elem.xuatThiSinh());
        }

        public static void showByKey(String key, double tongDiem, String diaChi, int soBaoDanh)
        {
            title();
            foreach (ThiSinhA thiSinh in thiSinhs)
            {
                if (key == "tongdiem" && thiSinh.tongDiem() >= tongDiem)
                {
                    thiSinh.xuatThiSinh();
                }
                else if (key == "diachi" && thiSinh.diaChi.Equals(diaChi))
                {
                    thiSinh.xuatThiSinh();
                }
                else if (key == "SBD" && thiSinh.soBaoDanh == soBaoDanh)
                {
                    thiSinh.xuatThiSinh();
                }
            }
        }

        public static int Choose() {
            do
            {
                try
                {
                    int choose = Convert.ToInt32(Console.ReadLine());
                    return choose;
                }
                catch (Exception e)
                {
                    Console.Write("Dữ liệu không hợp lệ! Nhập lại: ");
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            do
            {
                Console.WriteLine("-------------------Menu--------------------");
                Console.WriteLine("1. Nhập thông tin 1 thí sinh");
                Console.WriteLine("2. Hiển thị danh sách các thí sinh");
                Console.WriteLine("3. Hiển thị các sinh viên theo tổng điểm");
                Console.WriteLine("4. Hiển thị các sinh viên theo địa chỉ");
                Console.WriteLine("5. Tìm kiếm theo số báo danh");
                Console.WriteLine("6. Kết thúc chương trình.");
                Console.Write("Chọn chức năng để sử dụng: ");
                
                switch (Choose())
                {
                    case 1:
                        addThiSinh();
                        break;
                    case 2:
                        show();
                        break;
                    case 3:
                        Console.Write("Nhập tổng điểm cần tìm: ");
                        double tongDiem = Convert.ToDouble(Console.ReadLine());
                        showByKey("tongdiem", tongDiem, null, 0);
                        break;
                    case 4:
                        Console.Write("Nhập địa chỉ cần tìm: ");
                        String diaChi = Convert.ToString(Console.ReadLine());
                        showByKey("diachi", 0, diaChi, 0);
                        break;
                    case 5:
                        Console.Write("Nhập số báo danh cần tìm: ");
                        int soBaoDanh = Convert.ToInt32(Console.ReadLine());
                        showByKey("SBD", 0, null, soBaoDanh);
                        break;
                    case 6:
                        Console.WriteLine("Đã thoát khỏi trương trình");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (true);
        }
    }
}

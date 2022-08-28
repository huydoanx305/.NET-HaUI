using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable

namespace DE01.Models
{
    public partial class BenhNhan
    {
        public int MaBn { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int? SoNgayNamVien { get; set; }
        public double? VienPhi { get; set; }
        public int? MaKhoa { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }

        public string vienPhi()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            int a = (int)SoNgayNamVien * 200000;
            string b = int.Parse(a.ToString()).ToString("#,###", cul.NumberFormat);
            return b;
        }
    }
}

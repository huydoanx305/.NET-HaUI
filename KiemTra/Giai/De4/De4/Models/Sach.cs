using System;
using System.Collections.Generic;

#nullable disable

namespace De4.Models
{
    public partial class Sach
    {
        public string Masach { get; set; }
        public string Tensach { get; set; }
        public string Manxb { get; set; }
        public int? Sotrang { get; set; }

        public virtual NhaXuatBan ManxbNavigation { get; set; }
    }
}

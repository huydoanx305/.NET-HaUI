using System;
using System.Collections.Generic;

#nullable disable

namespace De4.Models
{
    public partial class NhaXuatBan
    {
        public NhaXuatBan()
        {
            Saches = new HashSet<Sach>();
        }

        public string Manxb { get; set; }
        public string Tennhaxb { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}

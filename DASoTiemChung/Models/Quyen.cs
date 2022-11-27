using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class Quyen
    {
        public Quyen()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int MaQuyen { get; set; }
        public string TenQuyen { get; set; }
        public bool DaXoa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class XaPhuong
    {
        public int MaXaPhuong { get; set; }
        public string TenXaPhuong { get; set; }
        public int? MaQuanHuyen { get; set; }

        public virtual QuanHuyen MaQuanHuyenNavigation { get; set; }
    }
}

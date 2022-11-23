using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            
            VacXinTheoLos = new HashSet<VacXinTheoLo>();
        }

        public int MaNhaSanXuat { get; set; }
        public string TenNhaSanXuat { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChiHienTai { get; set; }

        
        public virtual ICollection<VacXinTheoLo> VacXinTheoLos { get; set; }
    }
}

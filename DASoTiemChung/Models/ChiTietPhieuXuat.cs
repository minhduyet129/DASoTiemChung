using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class ChiTietPhieuXuat
    {
        public int MaChiTietPhieuXuat { get; set; }
        public DateTime? ThoiGianXuat { get; set; }
        public int? SoLuong { get; set; }
        public int? MaPhieuXuat { get; set; }
        public int? MaVacXinTheoLo { get; set; }

        public virtual PhieuXuat MaPhieuXuatNavigation { get; set; }
        public virtual VacXinTheoLo MaVacXinTheoLoNavigation { get; set; }
    }
}

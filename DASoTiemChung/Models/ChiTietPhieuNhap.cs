using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class ChiTietPhieuNhap
    {
        public int MaChiTietPhieuNhap { get; set; }
        public DateTime? ThoiGianNhap { get; set; }
        public decimal? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }
        public int? MaPhieuNhap { get; set; }
        public int? MaVacXinTheoLo { get; set; }

        public virtual PhieuNhap MaPhieuNhapNavigation { get; set; }
        public virtual VacXinTheoLo MaVacXinTheoLoNavigation { get; set; }
    }
}

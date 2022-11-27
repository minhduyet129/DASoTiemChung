using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class VacXinTheoLo
    {
        public VacXinTheoLo()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            ChiTietPhieuXuats = new HashSet<ChiTietPhieuXuat>();
        }

        public int MaVacXinTheoLo { get; set; }
        public int? MaVacXin { get; set; }
        public int? MaLo { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public DateTime? NgaySanXuat { get; set; }
        public int? SoLuong { get; set; }
        public string XuatXu { get; set; }
        public int? MaNhaSanXuat { get; set; }
        public int? MaKho { get; set; }
        public string TenVacXinTheoLo { get; set; }
        public bool DaXoa { get; set; }

        public virtual Kho MaKhoNavigation { get; set; }
        public virtual Lo MaLoNavigation { get; set; }
        public virtual NhaSanXuat MaNhaSanXuatNavigation { get; set; }
        public virtual VacXin MaVacXinNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class PhieuXuat
    {
        public PhieuXuat()
        {
            ChiTietPhieuXuats = new HashSet<ChiTietPhieuXuat>();
        }

        public int MaPhieuXuat { get; set; }
        public int? MaVacXin { get; set; }
        public int? MaKho { get; set; }
        public int? MaDiemTiem { get; set; }
        public int? MaNhanVien { get; set; }
        public string GhiChu { get; set; }

        public virtual DiemTiem MaDiemTiemNavigation { get; set; }
        public virtual Kho MaKhoNavigation { get; set; }
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual VacXin MaVacXinNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}

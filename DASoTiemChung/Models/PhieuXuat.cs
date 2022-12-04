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
        public DateTime? ThoiGianXuat { get; set; }
        public int? MaKhoXuat { get; set; }
        public int? MaKhoNhan { get; set; }
        public int? MaNhanVien { get; set; }
        public string GhiChu { get; set; }
        public bool DaXoa { get; set; }

        public virtual Kho MaKhoXuatNavigation { get; set; }
        public virtual Kho MaKhoNhanNavigation { get; set; }
       
        public virtual NhanVien MaNhanVienNavigation { get; set; }
       
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}

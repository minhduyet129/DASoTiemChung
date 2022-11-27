using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class PhieuNhap
    {
        public PhieuNhap()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        public int MaPhieuNhap { get; set; }
        public decimal? Tongtien { get; set; }
        public DateTime? ThoiGianNhap { get; set; }
        public int? MaNhanVien { get; set; }
      
        public string GhiChu { get; set; }

        public bool DaXoa { get; set; }
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}

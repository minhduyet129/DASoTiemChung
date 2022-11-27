using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            PhieuNhaps = new HashSet<PhieuNhap>();
            PhieuXuats = new HashSet<PhieuXuat>();
        }

        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int? MaQuyen { get; set; }
        public bool DaXoa { get; set; }

        public virtual Quyen MaQuyenNavigation { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class PhieuTiem
    {
        public int MaPhieuTiem { get; set; }
        public int? MaNguoiDan { get; set; }
        public DateTime? ThoiGianTiem { get; set; }
        public int? MaMuiTiem { get; set; }
        public int? MaKho { get; set; }
        public int? MaVacXinTheoLo { get; set; }
        public string PhanUngSauTiem { get; set; }
        public int? MaNhanVien { get; set; }
        public bool DaXoa { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual ICollection<PhieuTiemBenhLy> PhieuTiemBenhLys { get; set; }
        public virtual Kho MaKhoNavigation { get; set; }
        public virtual MuiTiem MaMuiTiemNavigation { get; set; }
        public virtual NguoiDan MaNguoiDanNavigation { get; set; }
        public virtual VacXinTheoLo MaVacXinTheoLoNavigation { get; set; }
    }
}

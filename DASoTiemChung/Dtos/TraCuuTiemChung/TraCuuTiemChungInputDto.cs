using DASoTiemChung.Models;
using System;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos
{
    public class TraCuuTiemChungInputDto
    {
        public int MaPhieuTiem { get; set; }
        public string TenNguoiDan { get; set; }
        public string SoCccdhc { get; set; }
        public DateTime? ThoiGianTiem { get; set; }
        public int? MaMuiTiem { get; set; }
        public int? MaKho { get; set; }
        public int? MaVacXinTheoLo { get; set; }
        public int? MaNhanVien { get; set; }
        public string PhanUngSauTiem { get; set; }
        public virtual ICollection<PhieuTiemBenhLy> PhieuTiemBenhLys { get; set; }
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual Kho MaKhoNavigation { get; set; }
        public virtual MuiTiem MaMuiTiemNavigation { get; set; }
        public virtual NguoiDan MaNguoiDanNavigation { get; set; }
        public virtual VacXinTheoLo MaVacXinTheoLoNavigation { get; set; }
    }
}

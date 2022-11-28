using DASoTiemChung.Models;
using System;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos
{
    public class PhieuTiemInputDto
    {
        public int MaPhieuTiem { get; set; }
        public string TenNguoiDan { get; set; }
        public string SoCccdhc { get; set; }
        public DateTime? ThoiGianTiem { get; set; }
        public int? MaMuiTiem { get; set; }
        public int? MaDiemTiem { get; set; }
        public int? MaVacXin { get; set; }
        public string PhanUngSauTiem { get; set; }
        public virtual ICollection<PhieuTiemBenhLy> PhieuTiemBenhLys { get; set; }
        public virtual DiemTiem MaDiemTiemNavigation { get; set; }
        public virtual MuiTiem MaMuiTiemNavigation { get; set; }
        public virtual NguoiDan MaNguoiDanNavigation { get; set; }
        public virtual VacXin MaVacXinNavigation { get; set; }
    }
}

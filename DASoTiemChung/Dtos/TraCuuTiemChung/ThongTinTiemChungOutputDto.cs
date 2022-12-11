using System;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos
{
    public class ThongTinTiemChungOutputDto
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string BHYT { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public List<DanhSachPhieuTiem> DanhSachPhieuTiems { get; set; } = new List<DanhSachPhieuTiem>();
    }
    public class DanhSachPhieuTiem
    {
        public string MuiTiem { get; set; }
        public DateTime ThoiGianTiem { get; set; }
        public string  TenVacXin { get; set; }
        public string Lo { get; set; }
        public string DiemTiem { get; set; }
    }
}

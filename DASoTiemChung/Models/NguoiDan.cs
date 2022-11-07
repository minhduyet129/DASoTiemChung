using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class NguoiDan
    {
        public NguoiDan()
        {
            PhieuTiems = new HashSet<PhieuTiem>();
        }

        public int MaNguoiDan { get; set; }
        public string HoTen { get; set; }
        public string SoTheBaoHiemYte { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCccdhc { get; set; }
        public string NgheNghiep { get; set; }
        public string DonViCongTac { get; set; }
        public string SoNha { get; set; }
        public string Email { get; set; }
        public string DanTocQuocTich { get; set; }
        public string NguoiDamHo { get; set; }
        public string QuanHeNguoiDamHo { get; set; }
        public string SoDienThoaiNguoiDamHo { get; set; }
        public int? MaXaPhuong { get; set; }
        public int? MaQuanHuyen { get; set; }
        public int? MaTinhThanhPho { get; set; }

        public virtual ICollection<PhieuTiem> PhieuTiems { get; set; }
    }
}

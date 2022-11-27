using DASoTiemChung.Models;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos
{
    public class NguoiDanOutputDto
    {
        public int MaNguoiDan { get; set; }
        public int? MaXaPhuong { get; set; }
        public int? MaQuanHuyen { get; set; }
        public int? MaTinhThanhPho { get; set; }
        public string HoTen { get; set; }
        public string SoNha { get; set; }
        public XaPhuong XaPhuongNavigation { get; set; }
        public QuanHuyen QuanHuyenNavigation { get; set; }
        public TinhThanhPho TinhThanhPhoNavigation { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
        public virtual ICollection<VacXinTheoLo> VacXinTheoLos { get; set; }
        public string SoTheBaoHiemYte { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCccdhc { get; set; }
        public string NgheNghiep { get; set; }
        public string DonViCongTac { get; set; }
        public string Email { get; set; }
        public string DanTocQuocTich { get; set; }
        public string NguoiDamHo { get; set; }
        public string QuanHeNguoiDamHo { get; set; }
        public string SoDienThoaiNguoiDamHo { get; set; }

    }
}

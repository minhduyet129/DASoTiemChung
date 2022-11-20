using DASoTiemChung.Filter;

namespace DASoTiemChung.Dtos.NguoiDan
{
    public class SearchNguoiDanDto:PagedRequestDto
    {
        public string TenXaPhuong { get; set; }
        public string TenQuanHuyen { get; set; }
        public string TenTinhThanh { get; set; }
        public string HoTen { get; set; }
        public string SoNha { get; set; }
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

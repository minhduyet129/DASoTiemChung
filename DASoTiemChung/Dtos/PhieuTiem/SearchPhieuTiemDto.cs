using DASoTiemChung.Filter;

namespace DASoTiemChung.Dtos
{
    public class SearchPhieuTiemDto : PagedRequestDto
    {
        public string TenNguoiDan { get; set; }
        public string SoCccdhc { get; set; }
        public string TenDiemTiem { get; set; }
        public string TenVacXin { get; set; }

    }
}

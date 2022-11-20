using DASoTiemChung.Filter;

namespace DASoTiemChung.Dtos.DiemTiem
{
    public class SearchDiemTiemDto : PagedRequestDto
    {

        public string TenXaPhuong { get; set; }
        public string TenQuanHuyen { get; set; }
        public string TenTinhThanh { get; set; }
        public string TenDiemTiem { get; set; }
        public string SoNha { get; set; }
        public string NguoiDungDau { get; set; }
        public string NguoiTiem { get; set; }
    }
}

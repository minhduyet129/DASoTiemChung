using DASoTiemChung.Filter;

namespace DASoTiemChung.Dtos.Kho
{
    public class SearchKhoDto:PagedRequestDto
    {

        public string TenXaPhuong { get; set; }
        public string TenQuanHuyen { get; set; }
        public string TenTinhThanh { get; set; }
        public string TenKho { get; set; }
        public string SoNha { get; set; }
    }
}

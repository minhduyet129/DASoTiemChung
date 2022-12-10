using DASoTiemChung.Filter;

namespace DASoTiemChung.Dtos
{
    public class SearchNhanVienDto:PagedRequestDto
    {
        
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string TenTaiKhoan { get; set; }
        public int? MaKho { get; set; }
        public int? MaQuyen { get; set; }

    }
    
}

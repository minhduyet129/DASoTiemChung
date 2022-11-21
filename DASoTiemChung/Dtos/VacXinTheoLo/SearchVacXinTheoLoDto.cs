using DASoTiemChung.Filter;
using System;

namespace DASoTiemChung.Dtos.VacXinTheoLo
{
    public class SearchVacXinTheoLoDto :PagedRequestDto
    {
        
        public string TenVacXin { get; set; }
        public string TenLo { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public DateTime? NgaySanXuat { get; set; }
        
        public string XuatXu { get; set; }
        public string TenNhaSanXuat { get; set; }
        public string TenKho { get; set; }
        public string TenVacXinTheoLo { get; set; }
    }
}

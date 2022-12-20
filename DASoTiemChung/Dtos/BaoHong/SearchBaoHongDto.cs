using DASoTiemChung.Filter;
using System;

namespace DASoTiemChung.Dtos
{
    public class SearchBaoHongDto : PagedRequestDto
    {
        public string TenKho { get; set; }
        public string TenVacXin { get; set; }
        public DateTime? NgayThongKe { get; set; }
    }
}

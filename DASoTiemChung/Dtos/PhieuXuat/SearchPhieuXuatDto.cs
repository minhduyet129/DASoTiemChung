using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using System;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos

{
    public class SearchPhieuXuatDto : PagedRequestDto
    {
        public string MaPhieuXuat { get; set; }
        public string TenDiemTiem { get; set; }


        public DateTime? ThoiGianXuat { get; set; }
        public string TenNhanVien { get; set; }

    }
}

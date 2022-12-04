using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using System;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos

{
    public class SearchPhieuXuatDto : PagedRequestDto
    {
        public string MaPhieuXuat { get; set; }
        public string TenDiemXuat { get; set; }
        public string TenDiemNhan { get; set; }


        public DateTime? ThoiGianXuat { get; set; }
        public string TenNhanVien { get; set; }

    }
}

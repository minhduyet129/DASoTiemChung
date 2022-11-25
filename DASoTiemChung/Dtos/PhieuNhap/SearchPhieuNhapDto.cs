using DASoTiemChung.Filter;
using DASoTiemChung.Models;
using System;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos
{
    public class SearchPhieuNhapDto : PagedRequestDto
    {
        public string MaPhieuNhap { get; set; }
        
        public DateTime? ThoiGianNhap { get; set; }
        public string TenNhanVien { get; set; }

        


    }
}

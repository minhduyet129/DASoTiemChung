﻿using DASoTiemChung.Filter;

namespace DASoTiemChung.Dtos.NhanVien
{
    public class SearchNhanVienDto:PagedRequestDto
    {
        
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string TenTaiKhoan { get; set; }
        
        public int? MaQuyen { get; set; }

    }
    
}
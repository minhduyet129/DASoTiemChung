using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class ThongKeVacXinTaiDiemTiem
    {
        public int MaThongKe { get; set; }
        public int? MaDiemTiem { get; set; }
        public int? SoLuongTiem { get; set; }
        public int? SoLuongHong { get; set; }
        public int? SoLuongThua { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }

        public virtual DiemTiem MaDiemTiemNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class ThongKeVacXinTaiDiemTiem
    {
        public int MaThongKe { get; set; }
        public int? MaKho { get; set; }
        public long? SoLuongTiem { get; set; }
        public long? SoLuongHong { get; set; }
        public long? SoLuongThua { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }

        public virtual Kho MaKhoNavigation { get; set; }
    }
}

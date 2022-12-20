using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class ThongKeVacXinTaiDiemTiem
    {
        public int MaThongKe { get; set; }
        public int? MaKho { get; set; }
        public int? MaVacXinTheoLo { get; set; }
        
        public long? SoLuongTrongKho { get; set; }
        public long? SoLuongHong { get; set; }
        public long? SoLuongThucTe { get; set; }
        public DateTime? NgayThongKe { get; set; }
        

        public virtual Kho MaKhoNavigation { get; set; }
        public virtual VacXinTheoLo MaVacXinTheoLoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class Kho
    {
        public Kho()
        {
            
            VacXinTheoLos = new HashSet<VacXinTheoLo>();
        }

        public int MaKho { get; set; }
        public int? MaXaPhuong { get; set; }
        public int? MaQuanHuyen { get; set; }
        public int? MaTinhThanhPho { get; set; }
        public string TenKho { get; set; }
        public string SoNha { get; set; }
        public string NguoiDungDau { get; set; }
        public string NguoiTiem { get; set; }
        public bool Kieu { get; set; }
        public bool DaXoa { get; set; }

        public virtual ICollection<PhieuTiem> PhieuTiems { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats1 { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats2 { get; set; }
        public virtual ICollection<VacXinTheoLo> VacXinTheoLos { get; set; }
        public virtual ICollection<ThongKeVacXinTaiDiemTiem> ThongKeVacXinTaiDiems { get; set; }

        
    }
}

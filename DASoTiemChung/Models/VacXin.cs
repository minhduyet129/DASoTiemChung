using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class VacXin
    {
        public VacXin()
        {
            PhieuTiems = new HashSet<PhieuTiem>();
            PhieuXuats = new HashSet<PhieuXuat>();
            VacXinTheoLos = new HashSet<VacXinTheoLo>();
        }

        public int MaVacXin { get; set; }
        public string TenVacXin { get; set; }

        public virtual ICollection<PhieuTiem> PhieuTiems { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
        public virtual ICollection<VacXinTheoLo> VacXinTheoLos { get; set; }
    }
}

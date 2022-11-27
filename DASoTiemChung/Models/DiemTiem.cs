using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class DiemTiem
    {
        public DiemTiem()
        {
            PhieuTiems = new HashSet<PhieuTiem>();
            PhieuXuats = new HashSet<PhieuXuat>();
            ThongKeVacXinTaiDiemTiems = new HashSet<ThongKeVacXinTaiDiemTiem>();
        }

        public int MaDiemTiem { get; set; }
        public string TenDiemTiem { get; set; }
        public int? MaXaPhuong { get; set; }
        public int? MaQuanHuyen { get; set; }
        public int? MaTinhThanhPho { get; set; }
        public string NguoiDungDau { get; set; }
        public string NguoiTiem { get; set; }
        public string SoNha { get; set; }
        public bool DaXoa { get; set; }

        public virtual ICollection<PhieuTiem> PhieuTiems { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
        public virtual ICollection<ThongKeVacXinTaiDiemTiem> ThongKeVacXinTaiDiemTiems { get; set; }
    }
}

using DASoTiemChung.Models;
using System.Collections.Generic;

namespace DASoTiemChung.Dtos.Kho
{
    public class KhoOutputDto
    {
        public int MaKho { get; set; }
        public int? MaXaPhuong { get; set; }
        public int? MaQuanHuyen { get; set; }
        public int? MaTinhThanhPho { get; set; }
        public string TenKho { get; set; }
        public string SoNha { get; set; }
        public XaPhuong XaPhuongNavigation { get; set; }
        public QuanHuyen QuanHuyenNavigation { get; set; }
        public TinhThanhPho TinhThanhPhoNavigation { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
        public virtual ICollection<VacXinTheoLo> VacXinTheoLos { get; set; }
    }
}

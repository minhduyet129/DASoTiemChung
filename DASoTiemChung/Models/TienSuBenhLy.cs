using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class TienSuBenhLy
    {
        public TienSuBenhLy()
        {
            PhieuTiems = new HashSet<PhieuTiem>();
        }

        public int MaBenhLy { get; set; }
        public string TenBenhLy { get; set; }
        public string TrieuChung { get; set; }
        public string TinhTrang { get; set; }

        public virtual ICollection<PhieuTiem> PhieuTiems { get; set; }
    }
}

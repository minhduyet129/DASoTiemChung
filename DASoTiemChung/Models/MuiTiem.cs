using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class MuiTiem
    {
        public MuiTiem()
        {
            PhieuTiems = new HashSet<PhieuTiem>();
        }

        public int MaMuiTiem { get; set; }
        public string TenMuiTiem { get; set; }

        public virtual ICollection<PhieuTiem> PhieuTiems { get; set; }
    }
}

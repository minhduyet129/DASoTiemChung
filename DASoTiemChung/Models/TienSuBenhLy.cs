using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class TienSuBenhLy
    {
        public TienSuBenhLy()
        {
            PhieuTiemBenhLys = new HashSet<PhieuTiemBenhLy>();
        }

        public int MaBenhLy { get; set; }
        public string TenBenhLy { get; set; }
        
        public bool DaXoa { get; set; }

        public virtual ICollection<PhieuTiemBenhLy> PhieuTiemBenhLys { get; set; }
        
    }
}

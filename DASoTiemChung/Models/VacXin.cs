using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class VacXin
    {
        public VacXin()
        {
            
            
            VacXinTheoLos = new HashSet<VacXinTheoLo>();
        }

        public int MaVacXin { get; set; }
        public string TenVacXin { get; set; }
        public bool DaXoa { get; set; }

        
        
        public virtual ICollection<VacXinTheoLo> VacXinTheoLos { get; set; }
    }
}

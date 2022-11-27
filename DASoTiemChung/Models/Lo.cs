using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class Lo
    {
        public Lo()
        {
            VacXinTheoLos = new HashSet<VacXinTheoLo>();
        }

        public int MaLo { get; set; }
        public string Code { get; set; }
        public string TenLo { get; set; }
        public bool DaXoa { get; set; }

        public virtual ICollection<VacXinTheoLo> VacXinTheoLos { get; set; }
    }
}

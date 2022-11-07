using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class TinhThanhPho
    {
        public TinhThanhPho()
        {
            QuanHuyens = new HashSet<QuanHuyen>();
        }

        public int MaTinhThanhPho { get; set; }
        public string TenTinhThanhPho { get; set; }

        public virtual ICollection<QuanHuyen> QuanHuyens { get; set; }
    }
}

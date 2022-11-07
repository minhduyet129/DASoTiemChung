using System;
using System.Collections.Generic;

#nullable disable

namespace DASoTiemChung.Models
{
    public partial class QuanHuyen
    {
        public QuanHuyen()
        {
            XaPhuongs = new HashSet<XaPhuong>();
        }

        public int MaQuanHuyen { get; set; }
        public string TenQuanHuyen { get; set; }
        public int? MaTinhThanhPho { get; set; }

        public virtual TinhThanhPho MaTinhThanhPhoNavigation { get; set; }
        public virtual ICollection<XaPhuong> XaPhuongs { get; set; }
    }
}

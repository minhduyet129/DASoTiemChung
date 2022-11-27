namespace DASoTiemChung.Models
{
    public class PhieuTiemBenhLy
    {
        
            public PhieuTiemBenhLy()
            {
               
            }

            public int MaPhieuTiemBenhLy { get; set; }
            public int? MaBenhLy { get; set; }
            public int? MaPhieuTiem { get; set; }

            public string TrieuChung { get; set; }
            public string TinhTrang { get; set; }



            public string GhiChu { get; set; }

            public bool DaXoa { get; set; }
            public virtual TienSuBenhLy MaTienSuBenhLyNavigation { get; set; }
            public virtual PhieuTiem MaPhieuTiemNavigation { get; set; }
        }
    
}

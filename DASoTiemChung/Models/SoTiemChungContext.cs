using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DASoTiemChung.Models
{
    public  class SoTiemChungContext : DbContext
    {
        public SoTiemChungContext()
        {
        }

        public SoTiemChungContext(DbContextOptions<SoTiemChungContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public virtual DbSet<DiemTiem> DiemTiems { get; set; }
        public virtual DbSet<Kho> Khos { get; set; }
        public virtual DbSet<Lo> Los { get; set; }
        public virtual DbSet<MuiTiem> MuiTiems { get; set; }
        public virtual DbSet<NguoiDan> NguoiDans { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuTiem> PhieuTiems { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<ThongKeVacXinTaiDiemTiem> ThongKeVacXinTaiDiemTiems { get; set; }
        public virtual DbSet<TienSuBenhLy> TienSuBenhLies { get; set; }
        public virtual DbSet<TinhThanhPho> TinhThanhPhos { get; set; }
        public virtual DbSet<VacXin> VacXins { get; set; }
        public virtual DbSet<VacXinTheoLo> VacXinTheoLos { get; set; }
        public virtual DbSet<XaPhuong> XaPhuongs { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaChiTietPhieuNhap)
                    .HasName("PK__ChiTietP__8908D283F6F91901");

                entity.ToTable("ChiTietPhieuNhap");

                entity.HasIndex(e => e.MaPhieuNhap, "IX_ChiTietPhieuNhap_MaPhieuNhap");

                entity.HasIndex(e => e.MaVacXinTheoLo, "IX_ChiTietPhieuNhap_MaVacXinTheoLo");

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ThoiGianNhap).HasColumnType("datetime");

                entity.HasOne(d => d.MaPhieuNhapNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaPhieuNhap)
                    .HasConstraintName("FK__ChiTietPh__MaPhi__4AB81AF0");

                entity.HasOne(d => d.MaVacXinTheoLoNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaVacXinTheoLo)
                    .HasConstraintName("FK_ChiTietPhieuNhap_VacXinTheoLo");
            });

            modelBuilder.Entity<ChiTietPhieuXuat>(entity =>
            {
                entity.HasKey(e => e.MaChiTietPhieuXuat)
                    .HasName("PK__ChiTietP__965B223B23BBEABE");

                entity.ToTable("ChiTietPhieuXuat");

                entity.HasIndex(e => e.MaPhieuXuat, "IX_ChiTietPhieuXuat_MaPhieuXuat");

                entity.HasIndex(e => e.MaVacXinTheoLo, "IX_ChiTietPhieuXuat_MaVacXinTheoLo");

                entity.Property(e => e.ThoiGianXuat).HasColumnType("datetime");

                entity.HasOne(d => d.MaPhieuXuatNavigation)
                    .WithMany(p => p.ChiTietPhieuXuats)
                    .HasForeignKey(d => d.MaPhieuXuat)
                    .HasConstraintName("FK__ChiTietPh__MaPhi__4CA06362");

                entity.HasOne(d => d.MaVacXinTheoLoNavigation)
                    .WithMany(p => p.ChiTietPhieuXuats)
                    .HasForeignKey(d => d.MaVacXinTheoLo)
                    .HasConstraintName("FK_ChiTietPhieuXuat_VacXinTheoLo");
            });

            modelBuilder.Entity<DiemTiem>(entity =>
            {
                entity.HasKey(e => e.MaDiemTiem)
                    .HasName("PK__DiemTiem__749732C4605D5519");

                entity.ToTable("DiemTiem");

                entity.Property(e => e.NguoiDungDau).HasMaxLength(50);

                entity.Property(e => e.NguoiTiem).HasMaxLength(50);

                entity.Property(e => e.SoNha).HasMaxLength(40);
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(e => e.MaKho)
                    .HasName("PK__Kho__3BDA9350EA7E3CF4");

                entity.ToTable("Kho");

                entity.Property(e => e.SoNha).HasMaxLength(40);

                entity.Property(e => e.TenKho).HasMaxLength(50);
            });

            modelBuilder.Entity<Lo>(entity =>
            {
                entity.HasKey(e => e.MaLo)
                    .HasName("PK__Lo__2725C75681A945BD");

                entity.ToTable("Lo");

                entity.Property(e => e.Code)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenLo).HasMaxLength(30);
            });

            modelBuilder.Entity<MuiTiem>(entity =>
            {
                entity.HasKey(e => e.MaMuiTiem)
                    .HasName("PK__MuiTiem__8685ED46CBF763BD");

                entity.ToTable("MuiTiem");

                entity.Property(e => e.TenMuiTiem).HasMaxLength(20);
            });

            modelBuilder.Entity<NguoiDan>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDan)
                    .HasName("PK__NguoiDan__8ECA8DBF2D466220");

                entity.ToTable("NguoiDan");

                entity.Property(e => e.DanTocQuocTich).HasMaxLength(40);

                entity.Property(e => e.DonViCongTac).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.NgheNghiep).HasMaxLength(40);

                entity.Property(e => e.NguoiDamHo).HasMaxLength(40);

                entity.Property(e => e.QuanHeNguoiDamHo).HasMaxLength(40);

                entity.Property(e => e.SoCccdhc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SoCCCDHC")
                    .IsFixedLength(true);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SoDienThoaiNguoiDamHo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SoNha).HasMaxLength(40);

                entity.Property(e => e.SoTheBaoHiemYte)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SoTheBaoHiemYTe")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<NhaSanXuat>(entity =>
            {
                entity.HasKey(e => e.MaNhaSanXuat)
                    .HasName("PK__NhaSanXu__838C17A19310DD9D");

                entity.ToTable("NhaSanXuat");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNhaSanXuat).HasMaxLength(30);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA47B95F8472");

                entity.ToTable("NhanVien");

                entity.HasIndex(e => e.MaQuyen, "IX_NhanVien_MaQuyen");

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNhanVien).HasMaxLength(30);

                entity.Property(e => e.TenTaiKhoan).HasMaxLength(50);

                entity.HasOne(d => d.MaQuyenNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaQuyen)
                    .HasConstraintName("FK__NhanVien__MaQuye__5629CD9C");
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap)
                    .HasName("PK__PhieuNha__1470EF3BE08B534D");

                entity.ToTable("PhieuNhap");

                entity.HasIndex(e => e.MaNhanVien, "IX_PhieuNhap_MaNhanVien");

                entity.Property(e => e.Tongtien).HasColumnType("decimal(18, 0)");

                
                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__PhieuNhap__MaNha__59063A47");
            });

            modelBuilder.Entity<PhieuTiem>(entity =>
            {
                entity.HasKey(e => e.MaPhieuTiem)
                    .HasName("PK__PhieuTie__0B08C00122297BB2");

                entity.ToTable("PhieuTiem");

                entity.HasIndex(e => e.MaBenhLy, "IX_PhieuTiem_MaBenhLy");

                entity.HasIndex(e => e.MaDiemTiem, "IX_PhieuTiem_MaDiemTiem");

                entity.HasIndex(e => e.MaMuiTiem, "IX_PhieuTiem_MaMuiTiem");

                entity.HasIndex(e => e.MaNguoiDan, "IX_PhieuTiem_MaNguoiDan");

                entity.HasIndex(e => e.MaVacXin, "IX_PhieuTiem_MaVacXin");

                entity.Property(e => e.ThoiGianTiem).HasColumnType("datetime");

                entity.HasOne(d => d.MaBenhLyNavigation)
                    .WithMany(p => p.PhieuTiems)
                    .HasForeignKey(d => d.MaBenhLy)
                    .HasConstraintName("FK__PhieuTiem__MaBen__59FA5E80");

                entity.HasOne(d => d.MaDiemTiemNavigation)
                    .WithMany(p => p.PhieuTiems)
                    .HasForeignKey(d => d.MaDiemTiem)
                    .HasConstraintName("FK__PhieuTiem__MaDie__5AEE82B9");

                entity.HasOne(d => d.MaMuiTiemNavigation)
                    .WithMany(p => p.PhieuTiems)
                    .HasForeignKey(d => d.MaMuiTiem)
                    .HasConstraintName("FK__PhieuTiem__MaMui__5BE2A6F2");

                entity.HasOne(d => d.MaNguoiDanNavigation)
                    .WithMany(p => p.PhieuTiems)
                    .HasForeignKey(d => d.MaNguoiDan)
                    .HasConstraintName("FK__PhieuTiem__MaNgu__5CD6CB2B");

                entity.HasOne(d => d.MaVacXinNavigation)
                    .WithMany(p => p.PhieuTiems)
                    .HasForeignKey(d => d.MaVacXin)
                    .HasConstraintName("FK__PhieuTiem__MaVac__5DCAEF64");
            });

            modelBuilder.Entity<PhieuXuat>(entity =>
            {
                entity.HasKey(e => e.MaPhieuXuat)
                    .HasName("PK__PhieuXua__26C4B5A233CD9D8B");

                entity.ToTable("PhieuXuat");

                entity.HasIndex(e => e.MaDiemTiem, "IX_PhieuXuat_MaDiemTiem");

                

                entity.HasIndex(e => e.MaNhanVien, "IX_PhieuXuat_MaNhanVien");

                

                entity.HasOne(d => d.MaDiemTiemNavigation)
                    .WithMany(p => p.PhieuXuats)
                    .HasForeignKey(d => d.MaDiemTiem)
                    .HasConstraintName("FK__PhieuXuat__MaDie__5EBF139D");

                

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.PhieuXuats)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__PhieuXuat__MaNha__60A75C0F");

                
            });

            modelBuilder.Entity<QuanHuyen>(entity =>
            {
                entity.HasKey(e => e.MaQuanHuyen)
                    .HasName("PK__QuanHuye__B86B827AA8B52899");

                entity.ToTable("QuanHuyen");

                entity.HasIndex(e => e.MaTinhThanhPho, "IX_QuanHuyen_MaTinhThanhPho");

                entity.Property(e => e.TenQuanHuyen).HasMaxLength(40);

                entity.HasOne(d => d.MaTinhThanhPhoNavigation)
                    .WithMany(p => p.QuanHuyens)
                    .HasForeignKey(d => d.MaTinhThanhPho)
                    .HasConstraintName("FK__QuanHuyen__MaTin__628FA481");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.HasKey(e => e.MaQuyen)
                    .HasName("PK__Quyen__1D4B7ED41A555413");

                entity.ToTable("Quyen");

                entity.Property(e => e.TenQuyen).HasMaxLength(30);
            });

            modelBuilder.Entity<ThongKeVacXinTaiDiemTiem>(entity =>
            {
                entity.HasKey(e => e.MaThongKe)
                    .HasName("PK__ThongKeV__60E521F491002700");

                entity.ToTable("ThongKeVacXinTaiDiemTiem");

                entity.HasIndex(e => e.MaDiemTiem, "IX_ThongKeVacXinTaiDiemTiem_MaDiemTiem");

                entity.Property(e => e.DenNgay).HasColumnType("date");

                entity.Property(e => e.TuNgay).HasColumnType("date");

                entity.HasOne(d => d.MaDiemTiemNavigation)
                    .WithMany(p => p.ThongKeVacXinTaiDiemTiems)
                    .HasForeignKey(d => d.MaDiemTiem)
                    .HasConstraintName("FK__ThongKeVa__MaDie__6383C8BA");
            });

            modelBuilder.Entity<TienSuBenhLy>(entity =>
            {
                entity.HasKey(e => e.MaBenhLy)
                    .HasName("PK__TienSuBe__4AA71879F7FA85E0");

                entity.ToTable("TienSuBenhLy");

                entity.Property(e => e.TenBenhLy).HasMaxLength(50);
            });

            modelBuilder.Entity<TinhThanhPho>(entity =>
            {
                entity.HasKey(e => e.MaTinhThanhPho)
                    .HasName("PK__TinhThan__71269D9798D3D383");

                entity.ToTable("TinhThanhPho");

                entity.Property(e => e.TenTinhThanhPho).HasMaxLength(40);
            });

            modelBuilder.Entity<VacXin>(entity =>
            {
                entity.HasKey(e => e.MaVacXin)
                    .HasName("PK__VacXin__92F66267C4D5D6AF");

                entity.ToTable("VacXin");

                entity.Property(e => e.TenVacXin).HasMaxLength(100);
            });

            modelBuilder.Entity<VacXinTheoLo>(entity =>
            {
                entity.HasKey(e => e.MaVacXinTheoLo)
                    .HasName("PK__VacXinTh__A4ECC6F7CB5F9CC0");

                entity.ToTable("VacXinTheoLo");

                entity.HasIndex(e => e.MaKho, "IX_VacXinTheoLo_MaKho");

                entity.HasIndex(e => e.MaLo, "IX_VacXinTheoLo_MaLo");

                entity.HasIndex(e => e.MaNhaSanXuat, "IX_VacXinTheoLo_MaNhaSanXuat");

                entity.HasIndex(e => e.MaVacXin, "IX_VacXinTheoLo_MaVacXin");

                entity.Property(e => e.NgayHetHan).HasColumnType("datetime");

                entity.Property(e => e.NgaySanXuat).HasColumnType("datetime");

                entity.Property(e => e.TenVacXinTheoLo).HasMaxLength(50);

                entity.Property(e => e.XuatXu).HasMaxLength(50);

                entity.HasOne(d => d.MaKhoNavigation)
                    .WithMany(p => p.VacXinTheoLos)
                    .HasForeignKey(d => d.MaKho)
                    .HasConstraintName("FK__VacXinThe__MaKho__6477ECF3");

                entity.HasOne(d => d.MaLoNavigation)
                    .WithMany(p => p.VacXinTheoLos)
                    .HasForeignKey(d => d.MaLo)
                    .HasConstraintName("FK__VacXinTheo__MaLo__6754599E");

                entity.HasOne(d => d.MaNhaSanXuatNavigation)
                    .WithMany(p => p.VacXinTheoLos)
                    .HasForeignKey(d => d.MaNhaSanXuat)
                    .HasConstraintName("FK__VacXinThe__MaNha__656C112C");

                entity.HasOne(d => d.MaVacXinNavigation)
                    .WithMany(p => p.VacXinTheoLos)
                    .HasForeignKey(d => d.MaVacXin)
                    .HasConstraintName("FK__VacXinThe__MaVac__66603565");
            });

            modelBuilder.Entity<XaPhuong>(entity =>
            {
                entity.HasKey(e => e.MaXaPhuong)
                    .HasName("PK__XaPhuong__92E67F27D21145DB");

                entity.ToTable("XaPhuong");

                entity.HasIndex(e => e.MaQuanHuyen, "IX_XaPhuong_MaQuanHuyen");

                entity.Property(e => e.TenXaPhuong).HasMaxLength(40);

                entity.HasOne(d => d.MaQuanHuyenNavigation)
                    .WithMany(p => p.XaPhuongs)
                    .HasForeignKey(d => d.MaQuanHuyen)
                    .HasConstraintName("FK__XaPhuong__MaQuan__68487DD7");
            });

            
        }

        
    }
}

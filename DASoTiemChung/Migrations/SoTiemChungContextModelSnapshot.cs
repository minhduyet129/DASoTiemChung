﻿// <auto-generated />
using System;
using DASoTiemChung.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DASoTiemChung.Migrations
{
    [DbContext(typeof(SoTiemChungContext))]
    partial class SoTiemChungContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DASoTiemChung.Models.ChiTietPhieuNhap", b =>
                {
                    b.Property<int>("MaChiTietPhieuNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("DonGia")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("MaPhieuNhap")
                        .HasColumnType("int");

                    b.Property<int?>("MaVacXinTheoLo")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaChiTietPhieuNhap")
                        .HasName("PK__ChiTietP__8908D283F6F91901");

                    b.HasIndex(new[] { "MaPhieuNhap" }, "IX_ChiTietPhieuNhap_MaPhieuNhap");

                    b.HasIndex(new[] { "MaVacXinTheoLo" }, "IX_ChiTietPhieuNhap_MaVacXinTheoLo");

                    b.ToTable("ChiTietPhieuNhap");
                });

            modelBuilder.Entity("DASoTiemChung.Models.ChiTietPhieuXuat", b =>
                {
                    b.Property<int>("MaChiTietPhieuXuat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaPhieuXuat")
                        .HasColumnType("int");

                    b.Property<int?>("MaVacXinTheoLo")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietPhieuXuat")
                        .HasName("PK__ChiTietP__965B223B23BBEABE");

                    b.HasIndex(new[] { "MaPhieuXuat" }, "IX_ChiTietPhieuXuat_MaPhieuXuat");

                    b.HasIndex(new[] { "MaVacXinTheoLo" }, "IX_ChiTietPhieuXuat_MaVacXinTheoLo");

                    b.ToTable("ChiTietPhieuXuat");
                });

            modelBuilder.Entity("DASoTiemChung.Models.DiemTiem", b =>
                {
                    b.Property<int>("MaDiemTiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaQuanHuyen")
                        .HasColumnType("int");

                    b.Property<int?>("MaTinhThanhPho")
                        .HasColumnType("int");

                    b.Property<int?>("MaXaPhuong")
                        .HasColumnType("int");

                    b.Property<string>("NguoiDungDau")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NguoiTiem")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SoNha")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TenDiemTiem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDiemTiem")
                        .HasName("PK__DiemTiem__749732C4605D5519");

                    b.ToTable("DiemTiem");
                });

            modelBuilder.Entity("DASoTiemChung.Models.Kho", b =>
                {
                    b.Property<int>("MaKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaQuanHuyen")
                        .HasColumnType("int");

                    b.Property<int?>("MaTinhThanhPho")
                        .HasColumnType("int");

                    b.Property<int?>("MaXaPhuong")
                        .HasColumnType("int");

                    b.Property<string>("SoNha")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TenKho")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaKho")
                        .HasName("PK__Kho__3BDA9350EA7E3CF4");

                    b.ToTable("Kho");
                });

            modelBuilder.Entity("DASoTiemChung.Models.Lo", b =>
                {
                    b.Property<int>("MaLo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("char(40)")
                        .IsFixedLength(true);

                    b.Property<string>("TenLo")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaLo")
                        .HasName("PK__Lo__2725C75681A945BD");

                    b.ToTable("Lo");
                });

            modelBuilder.Entity("DASoTiemChung.Models.MuiTiem", b =>
                {
                    b.Property<int>("MaMuiTiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenMuiTiem")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MaMuiTiem")
                        .HasName("PK__MuiTiem__8685ED46CBF763BD");

                    b.ToTable("MuiTiem");
                });

            modelBuilder.Entity("DASoTiemChung.Models.NguoiDan", b =>
                {
                    b.Property<int>("MaNguoiDan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DanTocQuocTich")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("DonViCongTac")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaQuanHuyen")
                        .HasColumnType("int");

                    b.Property<int?>("MaTinhThanhPho")
                        .HasColumnType("int");

                    b.Property<int?>("MaXaPhuong")
                        .HasColumnType("int");

                    b.Property<string>("NgheNghiep")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("NguoiDamHo")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("QuanHeNguoiDamHo")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("SoCccdhc")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("SoCCCDHC")
                        .IsFixedLength(true);

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength(true);

                    b.Property<string>("SoDienThoaiNguoiDamHo")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("char(40)")
                        .IsFixedLength(true);

                    b.Property<string>("SoNha")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("SoTheBaoHiemYte")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .HasColumnName("SoTheBaoHiemYTe")
                        .IsFixedLength(true);

                    b.HasKey("MaNguoiDan")
                        .HasName("PK__NguoiDan__8ECA8DBF2D466220");

                    b.ToTable("NguoiDan");
                });

            modelBuilder.Entity("DASoTiemChung.Models.NhaSanXuat", b =>
                {
                    b.Property<int>("MaNhaSanXuat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChiHienTai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .IsFixedLength(true);

                    b.Property<string>("TenNhaSanXuat")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaNhaSanXuat")
                        .HasName("PK__NhaSanXu__838C17A19310DD9D");

                    b.ToTable("NhaSanXuat");
                });

            modelBuilder.Entity("DASoTiemChung.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaQuyen")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .IsFixedLength(true);

                    b.Property<string>("TenNhanVien")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TenTaiKhoan")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaNhanVien")
                        .HasName("PK__NhanVien__77B2CA47B95F8472");

                    b.HasIndex(new[] { "MaQuyen" }, "IX_NhanVien_MaQuyen");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuNhap", b =>
                {
                    b.Property<int>("MaPhieuNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGianNhap")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Tongtien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaPhieuNhap")
                        .HasName("PK__PhieuNha__1470EF3BE08B534D");

                    b.HasIndex(new[] { "MaNhanVien" }, "IX_PhieuNhap_MaNhanVien");

                    b.ToTable("PhieuNhap");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuTiem", b =>
                {
                    b.Property<int>("MaPhieuTiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaBenhLy")
                        .HasColumnType("int");

                    b.Property<int?>("MaDiemTiem")
                        .HasColumnType("int");

                    b.Property<int?>("MaMuiTiem")
                        .HasColumnType("int");

                    b.Property<int?>("MaNguoiDan")
                        .HasColumnType("int");

                    b.Property<int?>("MaVacXin")
                        .HasColumnType("int");

                    b.Property<string>("PhanUngSauTiem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ThoiGianTiem")
                        .HasColumnType("datetime");

                    b.HasKey("MaPhieuTiem")
                        .HasName("PK__PhieuTie__0B08C00122297BB2");

                    b.HasIndex(new[] { "MaBenhLy" }, "IX_PhieuTiem_MaBenhLy");

                    b.HasIndex(new[] { "MaDiemTiem" }, "IX_PhieuTiem_MaDiemTiem");

                    b.HasIndex(new[] { "MaMuiTiem" }, "IX_PhieuTiem_MaMuiTiem");

                    b.HasIndex(new[] { "MaNguoiDan" }, "IX_PhieuTiem_MaNguoiDan");

                    b.HasIndex(new[] { "MaVacXin" }, "IX_PhieuTiem_MaVacXin");

                    b.ToTable("PhieuTiem");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuXuat", b =>
                {
                    b.Property<int>("MaPhieuXuat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaDiemTiem")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGianXuat")
                        .HasColumnType("datetime");

                    b.HasKey("MaPhieuXuat")
                        .HasName("PK__PhieuXua__26C4B5A233CD9D8B");

                    b.HasIndex(new[] { "MaDiemTiem" }, "IX_PhieuXuat_MaDiemTiem");

                    b.HasIndex(new[] { "MaNhanVien" }, "IX_PhieuXuat_MaNhanVien");

                    b.ToTable("PhieuXuat");
                });

            modelBuilder.Entity("DASoTiemChung.Models.QuanHuyen", b =>
                {
                    b.Property<int>("MaQuanHuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaTinhThanhPho")
                        .HasColumnType("int");

                    b.Property<string>("TenQuanHuyen")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("MaQuanHuyen")
                        .HasName("PK__QuanHuye__B86B827AA8B52899");

                    b.HasIndex(new[] { "MaTinhThanhPho" }, "IX_QuanHuyen_MaTinhThanhPho");

                    b.ToTable("QuanHuyen");
                });

            modelBuilder.Entity("DASoTiemChung.Models.Quyen", b =>
                {
                    b.Property<int>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenQuyen")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaQuyen")
                        .HasName("PK__Quyen__1D4B7ED41A555413");

                    b.ToTable("Quyen");
                });

            modelBuilder.Entity("DASoTiemChung.Models.ThongKeVacXinTaiDiemTiem", b =>
                {
                    b.Property<int>("MaThongKe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DenNgay")
                        .HasColumnType("date");

                    b.Property<int?>("MaDiemTiem")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongHong")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongThua")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongTiem")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TuNgay")
                        .HasColumnType("date");

                    b.HasKey("MaThongKe")
                        .HasName("PK__ThongKeV__60E521F491002700");

                    b.HasIndex(new[] { "MaDiemTiem" }, "IX_ThongKeVacXinTaiDiemTiem_MaDiemTiem");

                    b.ToTable("ThongKeVacXinTaiDiemTiem");
                });

            modelBuilder.Entity("DASoTiemChung.Models.TienSuBenhLy", b =>
                {
                    b.Property<int>("MaBenhLy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenBenhLy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TinhTrang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrieuChung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaBenhLy")
                        .HasName("PK__TienSuBe__4AA71879F7FA85E0");

                    b.ToTable("TienSuBenhLy");
                });

            modelBuilder.Entity("DASoTiemChung.Models.TinhThanhPho", b =>
                {
                    b.Property<int>("MaTinhThanhPho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenTinhThanhPho")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("MaTinhThanhPho")
                        .HasName("PK__TinhThan__71269D9798D3D383");

                    b.ToTable("TinhThanhPho");
                });

            modelBuilder.Entity("DASoTiemChung.Models.VacXin", b =>
                {
                    b.Property<int>("MaVacXin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenVacXin")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaVacXin")
                        .HasName("PK__VacXin__92F66267C4D5D6AF");

                    b.ToTable("VacXin");
                });

            modelBuilder.Entity("DASoTiemChung.Models.VacXinTheoLo", b =>
                {
                    b.Property<int>("MaVacXinTheoLo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaKho")
                        .HasColumnType("int");

                    b.Property<int?>("MaLo")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhaSanXuat")
                        .HasColumnType("int");

                    b.Property<int?>("MaVacXin")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayHetHan")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgaySanXuat")
                        .HasColumnType("datetime");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenVacXinTheoLo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("XuatXu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaVacXinTheoLo")
                        .HasName("PK__VacXinTh__A4ECC6F7CB5F9CC0");

                    b.HasIndex(new[] { "MaKho" }, "IX_VacXinTheoLo_MaKho");

                    b.HasIndex(new[] { "MaLo" }, "IX_VacXinTheoLo_MaLo");

                    b.HasIndex(new[] { "MaNhaSanXuat" }, "IX_VacXinTheoLo_MaNhaSanXuat");

                    b.HasIndex(new[] { "MaVacXin" }, "IX_VacXinTheoLo_MaVacXin");

                    b.ToTable("VacXinTheoLo");
                });

            modelBuilder.Entity("DASoTiemChung.Models.XaPhuong", b =>
                {
                    b.Property<int>("MaXaPhuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaQuanHuyen")
                        .HasColumnType("int");

                    b.Property<string>("TenXaPhuong")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("MaXaPhuong")
                        .HasName("PK__XaPhuong__92E67F27D21145DB");

                    b.HasIndex(new[] { "MaQuanHuyen" }, "IX_XaPhuong_MaQuanHuyen");

                    b.ToTable("XaPhuong");
                });

            modelBuilder.Entity("DASoTiemChung.Models.ChiTietPhieuNhap", b =>
                {
                    b.HasOne("DASoTiemChung.Models.PhieuNhap", "MaPhieuNhapNavigation")
                        .WithMany("ChiTietPhieuNhaps")
                        .HasForeignKey("MaPhieuNhap")
                        .HasConstraintName("FK__ChiTietPh__MaPhi__4AB81AF0");

                    b.HasOne("DASoTiemChung.Models.VacXinTheoLo", "MaVacXinTheoLoNavigation")
                        .WithMany("ChiTietPhieuNhaps")
                        .HasForeignKey("MaVacXinTheoLo")
                        .HasConstraintName("FK_ChiTietPhieuNhap_VacXinTheoLo");

                    b.Navigation("MaPhieuNhapNavigation");

                    b.Navigation("MaVacXinTheoLoNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.ChiTietPhieuXuat", b =>
                {
                    b.HasOne("DASoTiemChung.Models.PhieuXuat", "MaPhieuXuatNavigation")
                        .WithMany("ChiTietPhieuXuats")
                        .HasForeignKey("MaPhieuXuat")
                        .HasConstraintName("FK__ChiTietPh__MaPhi__4CA06362");

                    b.HasOne("DASoTiemChung.Models.VacXinTheoLo", "MaVacXinTheoLoNavigation")
                        .WithMany("ChiTietPhieuXuats")
                        .HasForeignKey("MaVacXinTheoLo")
                        .HasConstraintName("FK_ChiTietPhieuXuat_VacXinTheoLo");

                    b.Navigation("MaPhieuXuatNavigation");

                    b.Navigation("MaVacXinTheoLoNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.NhanVien", b =>
                {
                    b.HasOne("DASoTiemChung.Models.Quyen", "MaQuyenNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("MaQuyen")
                        .HasConstraintName("FK__NhanVien__MaQuye__5629CD9C");

                    b.Navigation("MaQuyenNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuNhap", b =>
                {
                    b.HasOne("DASoTiemChung.Models.NhanVien", "MaNhanVienNavigation")
                        .WithMany("PhieuNhaps")
                        .HasForeignKey("MaNhanVien")
                        .HasConstraintName("FK__PhieuNhap__MaNha__59063A47");

                    b.Navigation("MaNhanVienNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuTiem", b =>
                {
                    b.HasOne("DASoTiemChung.Models.TienSuBenhLy", "MaBenhLyNavigation")
                        .WithMany("PhieuTiems")
                        .HasForeignKey("MaBenhLy")
                        .HasConstraintName("FK__PhieuTiem__MaBen__59FA5E80");

                    b.HasOne("DASoTiemChung.Models.DiemTiem", "MaDiemTiemNavigation")
                        .WithMany("PhieuTiems")
                        .HasForeignKey("MaDiemTiem")
                        .HasConstraintName("FK__PhieuTiem__MaDie__5AEE82B9");

                    b.HasOne("DASoTiemChung.Models.MuiTiem", "MaMuiTiemNavigation")
                        .WithMany("PhieuTiems")
                        .HasForeignKey("MaMuiTiem")
                        .HasConstraintName("FK__PhieuTiem__MaMui__5BE2A6F2");

                    b.HasOne("DASoTiemChung.Models.NguoiDan", "MaNguoiDanNavigation")
                        .WithMany("PhieuTiems")
                        .HasForeignKey("MaNguoiDan")
                        .HasConstraintName("FK__PhieuTiem__MaNgu__5CD6CB2B");

                    b.HasOne("DASoTiemChung.Models.VacXin", "MaVacXinNavigation")
                        .WithMany("PhieuTiems")
                        .HasForeignKey("MaVacXin")
                        .HasConstraintName("FK__PhieuTiem__MaVac__5DCAEF64");

                    b.Navigation("MaBenhLyNavigation");

                    b.Navigation("MaDiemTiemNavigation");

                    b.Navigation("MaMuiTiemNavigation");

                    b.Navigation("MaNguoiDanNavigation");

                    b.Navigation("MaVacXinNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuXuat", b =>
                {
                    b.HasOne("DASoTiemChung.Models.DiemTiem", "MaDiemTiemNavigation")
                        .WithMany("PhieuXuats")
                        .HasForeignKey("MaDiemTiem")
                        .HasConstraintName("FK__PhieuXuat__MaDie__5EBF139D");

                    b.HasOne("DASoTiemChung.Models.NhanVien", "MaNhanVienNavigation")
                        .WithMany("PhieuXuats")
                        .HasForeignKey("MaNhanVien")
                        .HasConstraintName("FK__PhieuXuat__MaNha__60A75C0F");

                    b.Navigation("MaDiemTiemNavigation");

                    b.Navigation("MaNhanVienNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.QuanHuyen", b =>
                {
                    b.HasOne("DASoTiemChung.Models.TinhThanhPho", "MaTinhThanhPhoNavigation")
                        .WithMany("QuanHuyens")
                        .HasForeignKey("MaTinhThanhPho")
                        .HasConstraintName("FK__QuanHuyen__MaTin__628FA481");

                    b.Navigation("MaTinhThanhPhoNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.ThongKeVacXinTaiDiemTiem", b =>
                {
                    b.HasOne("DASoTiemChung.Models.DiemTiem", "MaDiemTiemNavigation")
                        .WithMany("ThongKeVacXinTaiDiemTiems")
                        .HasForeignKey("MaDiemTiem")
                        .HasConstraintName("FK__ThongKeVa__MaDie__6383C8BA");

                    b.Navigation("MaDiemTiemNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.VacXinTheoLo", b =>
                {
                    b.HasOne("DASoTiemChung.Models.Kho", "MaKhoNavigation")
                        .WithMany("VacXinTheoLos")
                        .HasForeignKey("MaKho")
                        .HasConstraintName("FK__VacXinThe__MaKho__6477ECF3");

                    b.HasOne("DASoTiemChung.Models.Lo", "MaLoNavigation")
                        .WithMany("VacXinTheoLos")
                        .HasForeignKey("MaLo")
                        .HasConstraintName("FK__VacXinTheo__MaLo__6754599E");

                    b.HasOne("DASoTiemChung.Models.NhaSanXuat", "MaNhaSanXuatNavigation")
                        .WithMany("VacXinTheoLos")
                        .HasForeignKey("MaNhaSanXuat")
                        .HasConstraintName("FK__VacXinThe__MaNha__656C112C");

                    b.HasOne("DASoTiemChung.Models.VacXin", "MaVacXinNavigation")
                        .WithMany("VacXinTheoLos")
                        .HasForeignKey("MaVacXin")
                        .HasConstraintName("FK__VacXinThe__MaVac__66603565");

                    b.Navigation("MaKhoNavigation");

                    b.Navigation("MaLoNavigation");

                    b.Navigation("MaNhaSanXuatNavigation");

                    b.Navigation("MaVacXinNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.XaPhuong", b =>
                {
                    b.HasOne("DASoTiemChung.Models.QuanHuyen", "MaQuanHuyenNavigation")
                        .WithMany("XaPhuongs")
                        .HasForeignKey("MaQuanHuyen")
                        .HasConstraintName("FK__XaPhuong__MaQuan__68487DD7");

                    b.Navigation("MaQuanHuyenNavigation");
                });

            modelBuilder.Entity("DASoTiemChung.Models.DiemTiem", b =>
                {
                    b.Navigation("PhieuTiems");

                    b.Navigation("PhieuXuats");

                    b.Navigation("ThongKeVacXinTaiDiemTiems");
                });

            modelBuilder.Entity("DASoTiemChung.Models.Kho", b =>
                {
                    b.Navigation("VacXinTheoLos");
                });

            modelBuilder.Entity("DASoTiemChung.Models.Lo", b =>
                {
                    b.Navigation("VacXinTheoLos");
                });

            modelBuilder.Entity("DASoTiemChung.Models.MuiTiem", b =>
                {
                    b.Navigation("PhieuTiems");
                });

            modelBuilder.Entity("DASoTiemChung.Models.NguoiDan", b =>
                {
                    b.Navigation("PhieuTiems");
                });

            modelBuilder.Entity("DASoTiemChung.Models.NhaSanXuat", b =>
                {
                    b.Navigation("VacXinTheoLos");
                });

            modelBuilder.Entity("DASoTiemChung.Models.NhanVien", b =>
                {
                    b.Navigation("PhieuNhaps");

                    b.Navigation("PhieuXuats");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuNhap", b =>
                {
                    b.Navigation("ChiTietPhieuNhaps");
                });

            modelBuilder.Entity("DASoTiemChung.Models.PhieuXuat", b =>
                {
                    b.Navigation("ChiTietPhieuXuats");
                });

            modelBuilder.Entity("DASoTiemChung.Models.QuanHuyen", b =>
                {
                    b.Navigation("XaPhuongs");
                });

            modelBuilder.Entity("DASoTiemChung.Models.Quyen", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("DASoTiemChung.Models.TienSuBenhLy", b =>
                {
                    b.Navigation("PhieuTiems");
                });

            modelBuilder.Entity("DASoTiemChung.Models.TinhThanhPho", b =>
                {
                    b.Navigation("QuanHuyens");
                });

            modelBuilder.Entity("DASoTiemChung.Models.VacXin", b =>
                {
                    b.Navigation("PhieuTiems");

                    b.Navigation("VacXinTheoLos");
                });

            modelBuilder.Entity("DASoTiemChung.Models.VacXinTheoLo", b =>
                {
                    b.Navigation("ChiTietPhieuNhaps");

                    b.Navigation("ChiTietPhieuXuats");
                });
#pragma warning restore 612, 618
        }
    }
}

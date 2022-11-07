using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiemTiem",
                columns: table => new
                {
                    MaDiemTiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDiemTiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaXaPhuong = table.Column<int>(type: "int", nullable: true),
                    MaQuanHuyen = table.Column<int>(type: "int", nullable: true),
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: true),
                    NguoiDungDau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NguoiTiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoNha = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DiemTiem__749732C4605D5519", x => x.MaDiemTiem);
                });

            migrationBuilder.CreateTable(
                name: "Kho",
                columns: table => new
                {
                    MaKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaXaPhuong = table.Column<int>(type: "int", nullable: true),
                    MaQuanHuyen = table.Column<int>(type: "int", nullable: true),
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: true),
                    TenKho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoNha = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kho__3BDA9350EA7E3CF4", x => x.MaKho);
                });

            migrationBuilder.CreateTable(
                name: "Lo",
                columns: table => new
                {
                    MaLo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "char(40)", unicode: false, fixedLength: true, maxLength: 40, nullable: true),
                    TenLo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lo__2725C75681A945BD", x => x.MaLo);
                });

            migrationBuilder.CreateTable(
                name: "MuiTiem",
                columns: table => new
                {
                    MaMuiTiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMuiTiem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MuiTiem__8685ED46CBF763BD", x => x.MaMuiTiem);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDan",
                columns: table => new
                {
                    MaNguoiDan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoTheBaoHiemYTe = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    SoCCCDHC = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    NgheNghiep = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DonViCongTac = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SoNha = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DanTocQuocTich = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    NguoiDamHo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    QuanHeNguoiDamHo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SoDienThoaiNguoiDamHo = table.Column<string>(type: "char(40)", unicode: false, fixedLength: true, maxLength: 40, nullable: true),
                    MaXaPhuong = table.Column<int>(type: "int", nullable: true),
                    MaQuanHuyen = table.Column<int>(type: "int", nullable: true),
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NguoiDan__8ECA8DBF2D466220", x => x.MaNguoiDan);
                });

            migrationBuilder.CreateTable(
                name: "NhaSanXuat",
                columns: table => new
                {
                    MaNhaSanXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhaSanXuat = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DiaChiHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhaSanXu__838C17A19310DD9D", x => x.MaNhaSanXuat);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quyen__1D4B7ED41A555413", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "TienSuBenhLy",
                columns: table => new
                {
                    MaBenhLy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBenhLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrieuChung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TienSuBe__4AA71879F7FA85E0", x => x.MaBenhLy);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanhPho",
                columns: table => new
                {
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhThanhPho = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TinhThan__71269D9798D3D383", x => x.MaTinhThanhPho);
                });

            migrationBuilder.CreateTable(
                name: "VacXin",
                columns: table => new
                {
                    MaVacXin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVacXin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VacXin__92F66267C4D5D6AF", x => x.MaVacXin);
                });

            migrationBuilder.CreateTable(
                name: "ThongKeVacXinTaiDiemTiem",
                columns: table => new
                {
                    MaThongKe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDiemTiem = table.Column<int>(type: "int", nullable: true),
                    SoLuongTiem = table.Column<int>(type: "int", nullable: true),
                    SoLuongHong = table.Column<int>(type: "int", nullable: true),
                    SoLuongThua = table.Column<int>(type: "int", nullable: true),
                    TuNgay = table.Column<DateTime>(type: "date", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThongKeV__60E521F491002700", x => x.MaThongKe);
                    table.ForeignKey(
                        name: "FK__ThongKeVa__MaDie__6383C8BA",
                        column: x => x.MaDiemTiem,
                        principalTable: "DiemTiem",
                        principalColumn: "MaDiemTiem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaQuyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA47B95F8472", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK__NhanVien__MaQuye__5629CD9C",
                        column: x => x.MaQuyen,
                        principalTable: "Quyen",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    MaQuanHuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuanHuye__B86B827AA8B52899", x => x.MaQuanHuyen);
                    table.ForeignKey(
                        name: "FK__QuanHuyen__MaTin__628FA481",
                        column: x => x.MaTinhThanhPho,
                        principalTable: "TinhThanhPho",
                        principalColumn: "MaTinhThanhPho",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuTiem",
                columns: table => new
                {
                    MaPhieuTiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDan = table.Column<int>(type: "int", nullable: true),
                    ThoiGianTiem = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaMuiTiem = table.Column<int>(type: "int", nullable: true),
                    MaDiemTiem = table.Column<int>(type: "int", nullable: true),
                    MaVacXin = table.Column<int>(type: "int", nullable: true),
                    PhanUngSauTiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaBenhLy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhieuTie__0B08C00122297BB2", x => x.MaPhieuTiem);
                    table.ForeignKey(
                        name: "FK__PhieuTiem__MaBen__59FA5E80",
                        column: x => x.MaBenhLy,
                        principalTable: "TienSuBenhLy",
                        principalColumn: "MaBenhLy",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuTiem__MaDie__5AEE82B9",
                        column: x => x.MaDiemTiem,
                        principalTable: "DiemTiem",
                        principalColumn: "MaDiemTiem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuTiem__MaMui__5BE2A6F2",
                        column: x => x.MaMuiTiem,
                        principalTable: "MuiTiem",
                        principalColumn: "MaMuiTiem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuTiem__MaNgu__5CD6CB2B",
                        column: x => x.MaNguoiDan,
                        principalTable: "NguoiDan",
                        principalColumn: "MaNguoiDan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuTiem__MaVac__5DCAEF64",
                        column: x => x.MaVacXin,
                        principalTable: "VacXin",
                        principalColumn: "MaVacXin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacXinTheoLo",
                columns: table => new
                {
                    MaVacXinTheoLo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVacXin = table.Column<int>(type: "int", nullable: true),
                    MaLo = table.Column<int>(type: "int", nullable: true),
                    NgayHetHan = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgaySanXuat = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    XuatXu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaNhaSanXuat = table.Column<int>(type: "int", nullable: true),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    TenVacXinTheoLo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VacXinTh__A4ECC6F7CB5F9CC0", x => x.MaVacXinTheoLo);
                    table.ForeignKey(
                        name: "FK__VacXinThe__MaKho__6477ECF3",
                        column: x => x.MaKho,
                        principalTable: "Kho",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VacXinThe__MaNha__656C112C",
                        column: x => x.MaNhaSanXuat,
                        principalTable: "NhaSanXuat",
                        principalColumn: "MaNhaSanXuat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VacXinThe__MaVac__66603565",
                        column: x => x.MaVacXin,
                        principalTable: "VacXin",
                        principalColumn: "MaVacXin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VacXinTheo__MaLo__6754599E",
                        column: x => x.MaLo,
                        principalTable: "Lo",
                        principalColumn: "MaLo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tongtien = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MaNhaSanXuat = table.Column<int>(type: "int", nullable: true),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhieuNha__1470EF3BE08B534D", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK__PhieuNhap__MaKho__571DF1D5",
                        column: x => x.MaKho,
                        principalTable: "Kho",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuNhap__MaNha__5812160E",
                        column: x => x.MaNhaSanXuat,
                        principalTable: "NhaSanXuat",
                        principalColumn: "MaNhaSanXuat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuNhap__MaNha__59063A47",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuat",
                columns: table => new
                {
                    MaPhieuXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVacXin = table.Column<int>(type: "int", nullable: true),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    MaDiemTiem = table.Column<int>(type: "int", nullable: true),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhieuXua__26C4B5A233CD9D8B", x => x.MaPhieuXuat);
                    table.ForeignKey(
                        name: "FK__PhieuXuat__MaDie__5EBF139D",
                        column: x => x.MaDiemTiem,
                        principalTable: "DiemTiem",
                        principalColumn: "MaDiemTiem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuXuat__MaKho__5FB337D6",
                        column: x => x.MaKho,
                        principalTable: "Kho",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuXuat__MaNha__60A75C0F",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PhieuXuat__MaVac__619B8048",
                        column: x => x.MaVacXin,
                        principalTable: "VacXin",
                        principalColumn: "MaVacXin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuong",
                columns: table => new
                {
                    MaXaPhuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenXaPhuong = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    MaQuanHuyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__XaPhuong__92E67F27D21145DB", x => x.MaXaPhuong);
                    table.ForeignKey(
                        name: "FK__XaPhuong__MaQuan__68487DD7",
                        column: x => x.MaQuanHuyen,
                        principalTable: "QuanHuyen",
                        principalColumn: "MaQuanHuyen",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhap",
                columns: table => new
                {
                    MaChiTietPhieuNhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianNhap = table.Column<DateTime>(type: "datetime", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: true),
                    MaVacXinTheoLo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietP__8908D283F6F91901", x => x.MaChiTietPhieuNhap);
                    table.ForeignKey(
                        name: "FK__ChiTietPh__MaPhi__4AB81AF0",
                        column: x => x.MaPhieuNhap,
                        principalTable: "PhieuNhap",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_VacXinTheoLo",
                        column: x => x.MaVacXinTheoLo,
                        principalTable: "VacXinTheoLo",
                        principalColumn: "MaVacXinTheoLo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuXuat",
                columns: table => new
                {
                    MaChiTietPhieuXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianXuat = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    MaPhieuXuat = table.Column<int>(type: "int", nullable: true),
                    MaVacXinTheoLo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietP__965B223B23BBEABE", x => x.MaChiTietPhieuXuat);
                    table.ForeignKey(
                        name: "FK__ChiTietPh__MaPhi__4CA06362",
                        column: x => x.MaPhieuXuat,
                        principalTable: "PhieuXuat",
                        principalColumn: "MaPhieuXuat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_VacXinTheoLo",
                        column: x => x.MaVacXinTheoLo,
                        principalTable: "VacXinTheoLo",
                        principalColumn: "MaVacXinTheoLo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaPhieuNhap",
                table: "ChiTietPhieuNhap",
                column: "MaPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaVacXinTheoLo",
                table: "ChiTietPhieuNhap",
                column: "MaVacXinTheoLo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_MaPhieuXuat",
                table: "ChiTietPhieuXuat",
                column: "MaPhieuXuat");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_MaVacXinTheoLo",
                table: "ChiTietPhieuXuat",
                column: "MaVacXinTheoLo");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaQuyen",
                table: "NhanVien",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaKho",
                table: "PhieuNhap",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaNhanVien",
                table: "PhieuNhap",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaNhaSanXuat",
                table: "PhieuNhap",
                column: "MaNhaSanXuat");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiem_MaBenhLy",
                table: "PhieuTiem",
                column: "MaBenhLy");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiem_MaDiemTiem",
                table: "PhieuTiem",
                column: "MaDiemTiem");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiem_MaMuiTiem",
                table: "PhieuTiem",
                column: "MaMuiTiem");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiem_MaNguoiDan",
                table: "PhieuTiem",
                column: "MaNguoiDan");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiem_MaVacXin",
                table: "PhieuTiem",
                column: "MaVacXin");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_MaDiemTiem",
                table: "PhieuXuat",
                column: "MaDiemTiem");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_MaKho",
                table: "PhieuXuat",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_MaNhanVien",
                table: "PhieuXuat",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_MaVacXin",
                table: "PhieuXuat",
                column: "MaVacXin");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_MaTinhThanhPho",
                table: "QuanHuyen",
                column: "MaTinhThanhPho");

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeVacXinTaiDiemTiem_MaDiemTiem",
                table: "ThongKeVacXinTaiDiemTiem",
                column: "MaDiemTiem");

            migrationBuilder.CreateIndex(
                name: "IX_VacXinTheoLo_MaKho",
                table: "VacXinTheoLo",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_VacXinTheoLo_MaLo",
                table: "VacXinTheoLo",
                column: "MaLo");

            migrationBuilder.CreateIndex(
                name: "IX_VacXinTheoLo_MaNhaSanXuat",
                table: "VacXinTheoLo",
                column: "MaNhaSanXuat");

            migrationBuilder.CreateIndex(
                name: "IX_VacXinTheoLo_MaVacXin",
                table: "VacXinTheoLo",
                column: "MaVacXin");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuong_MaQuanHuyen",
                table: "XaPhuong",
                column: "MaQuanHuyen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhap");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuXuat");

            migrationBuilder.DropTable(
                name: "PhieuTiem");

            migrationBuilder.DropTable(
                name: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.DropTable(
                name: "XaPhuong");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "PhieuXuat");

            migrationBuilder.DropTable(
                name: "VacXinTheoLo");

            migrationBuilder.DropTable(
                name: "TienSuBenhLy");

            migrationBuilder.DropTable(
                name: "MuiTiem");

            migrationBuilder.DropTable(
                name: "NguoiDan");

            migrationBuilder.DropTable(
                name: "QuanHuyen");

            migrationBuilder.DropTable(
                name: "DiemTiem");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Kho");

            migrationBuilder.DropTable(
                name: "NhaSanXuat");

            migrationBuilder.DropTable(
                name: "VacXin");

            migrationBuilder.DropTable(
                name: "Lo");

            migrationBuilder.DropTable(
                name: "TinhThanhPho");

            migrationBuilder.DropTable(
                name: "Quyen");
        }
    }
}

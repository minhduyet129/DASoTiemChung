using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class ChangeEntity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PhieuTiem__MaBen__59FA5E80",
                table: "PhieuTiem");

            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "TienSuBenhLy");

            migrationBuilder.DropColumn(
                name: "TrieuChung",
                table: "TienSuBenhLy");

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "VacXinTheoLo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "VacXin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "TienSuBenhLy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "Quyen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "PhieuXuat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "PhieuTiem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "PhieuNhap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "NhaSanXuat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "NhanVien",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "NguoiDan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "MuiTiem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "Lo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "Kho",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "DiemTiem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PhieuTiemBenhLy",
                columns: table => new
                {
                    MaPhieuTiemBenhLy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBenhLy = table.Column<int>(type: "int", nullable: true),
                    MaPhieuTiem = table.Column<int>(type: "int", nullable: true),
                    TrieuChung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuTiemBenhLy", x => x.MaPhieuTiemBenhLy);
                    table.ForeignKey(
                        name: "FK_PhieuTiemBenhLy_PhieuTiem_MaPhieuTiem",
                        column: x => x.MaPhieuTiem,
                        principalTable: "PhieuTiem",
                        principalColumn: "MaPhieuTiem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuTiemBenhLy_TienSuBenhLy_MaBenhLy",
                        column: x => x.MaBenhLy,
                        principalTable: "TienSuBenhLy",
                        principalColumn: "MaBenhLy",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiemBenhLy_MaBenhLy",
                table: "PhieuTiemBenhLy",
                column: "MaBenhLy");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiemBenhLy_MaPhieuTiem",
                table: "PhieuTiemBenhLy",
                column: "MaPhieuTiem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuTiemBenhLy");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "VacXinTheoLo");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "VacXin");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "TienSuBenhLy");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "Quyen");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "PhieuTiem");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "NhaSanXuat");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "NguoiDan");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "MuiTiem");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "Lo");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "Kho");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "DiemTiem");

            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "TienSuBenhLy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrieuChung",
                table: "TienSuBenhLy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuTiem__MaBen__59FA5E80",
                table: "PhieuTiem",
                column: "MaBenhLy",
                principalTable: "TienSuBenhLy",
                principalColumn: "MaBenhLy",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

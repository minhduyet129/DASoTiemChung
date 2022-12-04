using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class ChangeEntities4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PhieuTiem__MaDie__5AEE82B9",
                table: "PhieuTiem");

            migrationBuilder.DropForeignKey(
                name: "FK__PhieuTiem__MaVac__5DCAEF64",
                table: "PhieuTiem");

            migrationBuilder.DropForeignKey(
                name: "FK__PhieuXuat__MaDie__5EBF139D",
                table: "PhieuXuat");

            migrationBuilder.DropForeignKey(
                name: "FK__ThongKeVa__MaDie__6383C8BA",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.DropTable(
                name: "DiemTiem");

            migrationBuilder.RenameColumn(
                name: "MaDiemTiem",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "MaKho");

            migrationBuilder.RenameIndex(
                name: "IX_ThongKeVacXinTaiDiemTiem_MaDiemTiem",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "IX_ThongKeVacXinTaiDiemTiem_MaKho");

            migrationBuilder.RenameColumn(
                name: "MaDiemTiem",
                table: "PhieuXuat",
                newName: "MaKhoXuat");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuXuat_MaDiemTiem",
                table: "PhieuXuat",
                newName: "IX_PhieuXuat_MaKhoXuat");

            migrationBuilder.RenameColumn(
                name: "MaVacXin",
                table: "PhieuTiem",
                newName: "MaVacXinTheoLo");

            migrationBuilder.RenameColumn(
                name: "MaDiemTiem",
                table: "PhieuTiem",
                newName: "MaKho");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuTiem_MaVacXin",
                table: "PhieuTiem",
                newName: "IX_PhieuTiem_MaVacXinTheoLo");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuTiem_MaDiemTiem",
                table: "PhieuTiem",
                newName: "IX_PhieuTiem_MaKho");

            migrationBuilder.AlterColumn<long>(
                name: "SoLuong",
                table: "VacXinTheoLo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SoLuongTiem",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SoLuongThua",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SoLuongHong",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaKhoNhan",
                table: "PhieuXuat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaKho",
                table: "NhanVien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Kieu",
                table: "Kho",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NguoiDungDau",
                table: "Kho",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTiem",
                table: "Kho",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SoLuong",
                table: "ChiTietPhieuXuat",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SoLuong",
                table: "ChiTietPhieuNhap",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_MaKhoNhan",
                table: "PhieuXuat",
                column: "MaKhoNhan");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuTiem_Kho_MaKho1",
                table: "PhieuTiem",
                column: "MaKho",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuTiem_VacXinTheoLo_MaVacXinTheoLo",
                table: "PhieuTiem",
                column: "MaVacXinTheoLo",
                principalTable: "VacXinTheoLo",
                principalColumn: "MaVacXinTheoLo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuXuat_Kho_MaKhoNhan",
                table: "PhieuXuat",
                column: "MaKhoNhan",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuXuat_Kho_MaKhoXuat",
                table: "PhieuXuat",
                column: "MaKhoXuat",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeVacXinTaiDiemTiem_Kho_MaKho",
                table: "ThongKeVacXinTaiDiemTiem",
                column: "MaKho",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuTiem_Kho_MaKho",
                table: "PhieuTiem");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuTiem_VacXinTheoLo_MaVacXinTheoLo",
                table: "PhieuTiem");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuXuat_Kho_MaKhoNhan",
                table: "PhieuXuat");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuXuat_Kho_MaKhoXuat",
                table: "PhieuXuat");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeVacXinTaiDiemTiem_Kho_MaKho",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.DropIndex(
                name: "IX_PhieuXuat_MaKhoNhan",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "MaKhoNhan",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "MaKho",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "Kieu",
                table: "Kho");

            migrationBuilder.DropColumn(
                name: "NguoiDungDau",
                table: "Kho");

            migrationBuilder.DropColumn(
                name: "NguoiTiem",
                table: "Kho");

            migrationBuilder.RenameColumn(
                name: "MaKho",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "MaDiemTiem");

            migrationBuilder.RenameIndex(
                name: "IX_ThongKeVacXinTaiDiemTiem_MaKho",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "IX_ThongKeVacXinTaiDiemTiem_MaDiemTiem");

            migrationBuilder.RenameColumn(
                name: "MaKhoXuat",
                table: "PhieuXuat",
                newName: "MaDiemTiem");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuXuat_MaKhoXuat",
                table: "PhieuXuat",
                newName: "IX_PhieuXuat_MaDiemTiem");

            migrationBuilder.RenameColumn(
                name: "MaVacXinTheoLo",
                table: "PhieuTiem",
                newName: "MaVacXin");

            migrationBuilder.RenameColumn(
                name: "MaKho",
                table: "PhieuTiem",
                newName: "MaDiemTiem");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuTiem_MaVacXinTheoLo",
                table: "PhieuTiem",
                newName: "IX_PhieuTiem_MaVacXin");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuTiem_MaKho",
                table: "PhieuTiem",
                newName: "IX_PhieuTiem_MaDiemTiem");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuong",
                table: "VacXinTheoLo",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongTiem",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongThua",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongHong",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuong",
                table: "ChiTietPhieuXuat",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuong",
                table: "ChiTietPhieuNhap",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DiemTiem",
                columns: table => new
                {
                    MaDiemTiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    MaQuanHuyen = table.Column<int>(type: "int", nullable: true),
                    MaTinhThanhPho = table.Column<int>(type: "int", nullable: true),
                    MaXaPhuong = table.Column<int>(type: "int", nullable: true),
                    NguoiDungDau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NguoiTiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoNha = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TenDiemTiem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DiemTiem__749732C4605D5519", x => x.MaDiemTiem);
                });

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuTiem__MaDie__5AEE82B9",
                table: "PhieuTiem",
                column: "MaDiemTiem",
                principalTable: "DiemTiem",
                principalColumn: "MaDiemTiem",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuTiem__MaVac__5DCAEF64",
                table: "PhieuTiem",
                column: "MaVacXin",
                principalTable: "VacXin",
                principalColumn: "MaVacXin",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuXuat__MaDie__5EBF139D",
                table: "PhieuXuat",
                column: "MaDiemTiem",
                principalTable: "DiemTiem",
                principalColumn: "MaDiemTiem",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__ThongKeVa__MaDie__6383C8BA",
                table: "ThongKeVacXinTaiDiemTiem",
                column: "MaDiemTiem",
                principalTable: "DiemTiem",
                principalColumn: "MaDiemTiem",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

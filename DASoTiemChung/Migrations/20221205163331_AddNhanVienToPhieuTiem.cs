using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class AddNhanVienToPhieuTiem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaNhanVien",
                table: "PhieuTiem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuTiem_MaNhanVien",
                table: "PhieuTiem",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaKho",
                table: "NhanVien",
                column: "MaKho");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_Kho_MaKho",
                table: "NhanVien",
                column: "MaKho",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuTiem_NhanVien_MaNhanVien",
                table: "PhieuTiem",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_Kho_MaKho",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuTiem_NhanVien_MaNhanVien",
                table: "PhieuTiem");

            migrationBuilder.DropIndex(
                name: "IX_PhieuTiem_MaNhanVien",
                table: "PhieuTiem");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_MaKho",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "MaNhanVien",
                table: "PhieuTiem");
        }
    }
}

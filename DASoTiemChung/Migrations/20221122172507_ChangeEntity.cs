using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class ChangeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PhieuNhap__MaKho__571DF1D5",
                table: "PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK__PhieuNhap__MaNha__5812160E",
                table: "PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK__PhieuXuat__MaKho__5FB337D6",
                table: "PhieuXuat");

            migrationBuilder.DropForeignKey(
                name: "FK__PhieuXuat__MaVac__619B8048",
                table: "PhieuXuat");

            migrationBuilder.DropIndex(
                name: "IX_PhieuXuat_MaKho",
                table: "PhieuXuat");

            migrationBuilder.DropIndex(
                name: "IX_PhieuXuat_MaVacXin",
                table: "PhieuXuat");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_MaKho",
                table: "PhieuNhap");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_MaNhaSanXuat",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "MaKho",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "MaVacXin",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "MaKho",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "MaNhaSanXuat",
                table: "PhieuNhap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaKho",
                table: "PhieuXuat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaVacXin",
                table: "PhieuXuat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaKho",
                table: "PhieuNhap",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaNhaSanXuat",
                table: "PhieuNhap",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_MaKho",
                table: "PhieuXuat",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_MaVacXin",
                table: "PhieuXuat",
                column: "MaVacXin");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaKho",
                table: "PhieuNhap",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaNhaSanXuat",
                table: "PhieuNhap",
                column: "MaNhaSanXuat");

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuNhap__MaKho__571DF1D5",
                table: "PhieuNhap",
                column: "MaKho",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuNhap__MaNha__5812160E",
                table: "PhieuNhap",
                column: "MaNhaSanXuat",
                principalTable: "NhaSanXuat",
                principalColumn: "MaNhaSanXuat",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuXuat__MaKho__5FB337D6",
                table: "PhieuXuat",
                column: "MaKho",
                principalTable: "Kho",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PhieuXuat__MaVac__619B8048",
                table: "PhieuXuat",
                column: "MaVacXin",
                principalTable: "VacXin",
                principalColumn: "MaVacXin",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

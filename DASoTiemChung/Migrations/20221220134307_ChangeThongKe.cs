using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class ChangeThongKe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoLuongThua",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "SoLuongTrongKho");

            migrationBuilder.AddColumn<int>(
                name: "MaVacXinTheoLo",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SoLuongThucTe",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongKeVacXinTaiDiemTiem_MaVacXinTheoLo",
                table: "ThongKeVacXinTaiDiemTiem",
                column: "MaVacXinTheoLo");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongKeVacXinTaiDiemTiem_VacXinTheoLo_MaVacXinTheoLo",
                table: "ThongKeVacXinTaiDiemTiem",
                column: "MaVacXinTheoLo",
                principalTable: "VacXinTheoLo",
                principalColumn: "MaVacXinTheoLo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongKeVacXinTaiDiemTiem_VacXinTheoLo_MaVacXinTheoLo",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.DropIndex(
                name: "IX_ThongKeVacXinTaiDiemTiem_MaVacXinTheoLo",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.DropColumn(
                name: "MaVacXinTheoLo",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.DropColumn(
                name: "SoLuongThucTe",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.RenameColumn(
                name: "SoLuongTrongKho",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "SoLuongThua");
        }
    }
}

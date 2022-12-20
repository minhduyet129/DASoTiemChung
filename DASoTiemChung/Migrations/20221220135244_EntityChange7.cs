using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DASoTiemChung.Migrations
{
    public partial class EntityChange7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DenNgay",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.DropColumn(
                name: "SoLuongTiem",
                table: "ThongKeVacXinTaiDiemTiem");

            migrationBuilder.RenameColumn(
                name: "TuNgay",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "NgayThongKe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NgayThongKe",
                table: "ThongKeVacXinTaiDiemTiem",
                newName: "TuNgay");

            migrationBuilder.AddColumn<DateTime>(
                name: "DenNgay",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SoLuongTiem",
                table: "ThongKeVacXinTaiDiemTiem",
                type: "bigint",
                nullable: true);
        }
    }
}
